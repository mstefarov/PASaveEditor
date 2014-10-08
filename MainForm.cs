using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileModel;

namespace PASaveEditor {
    public partial class MainForm : Form {
        const string FileFilter = "Prison Architect saves (*.prison)|*.prison|All Files (*.*)|*.*";
        const string AppName = "Prison Architect Save Editor";
        string fileName;
        Prison prison;
        string[] prisonerNames;
        Prisoner selectedPrisoner;

        readonly OpenFileDialog openDialog;
        readonly SaveFileDialog saveAsDialog;

        Dictionary<string, string> CategoryNames = new Dictionary<string, string> {
            { "Protected", "Protective Custody" },
            { "MinSec", "Minimum Security" },
            { "Normal", "Normal Security" },
            { "MaxSec", "Maximum Security" },
            { "SuperMax", "SuperMax" }
        };


        public MainForm() {
            InitializeComponent();
            tPrisonerSearch.SetWatermark("Search");

            string paSavePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Introversion", "Prison Architect", "saves");

            openDialog = new OpenFileDialog {
                Filter = FileFilter,
                InitialDirectory = paSavePath
            };
            saveAsDialog = new SaveFileDialog {
                Filter = FileFilter,
                InitialDirectory = paSavePath
            };
            Enabled = false;
        }


        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            miFileOpen.PerformClick();
        }


        void miFileOpen_Click(object sender, EventArgs e) {
            if (openDialog.ShowDialog() == DialogResult.OK) {
                fileName = openDialog.FileName;
                using (FileStream fs = File.OpenRead(openDialog.FileName)) {
                    Text = String.Format("Loading {0} | {1}", Path.GetFileName(fileName), AppName);
                    prison = new Parser().Load(fs);
                    LoadPrisonToGui();
                    Enabled = true;
                    Text = String.Format("{0} | {1}", Path.GetFileName(fileName), AppName);
                }
            } else {
                if (prison == null) {
                    Close();
                }
            }
        }


        void LoadPrisonToGui() {
            // Load general tab
            nDay.Value = TimeConversion.IndexToDay(prison.TimeIndex);
            tTime.Text = String.Format("{0:00}:{1:00}",
                                       TimeConversion.IndexTo12Hour(prison.TimeIndex),
                                       TimeConversion.IndexToMinute(prison.TimeIndex));
            cAmPm.SelectedIndex = (TimeConversion.IsPm(prison.TimeIndex) ? 1 : 0);

            xMisconduct.Checked = prison.EnabledMisconduct;
            xContinuousIntake.Checked = prison.EnabledIntake;
            xFogOfWar.Checked = prison.EnabledVisibility;
            xFailureConditions.Checked = prison.FailureConditions;
            xDecay.Checked = prison.EnabledDecay;

            // Load finances tab
            xUnlimitedFunds.Checked = prison.UnlimitedFunds;
            nBalance.Value = prison.Finance.Balance;
            nBankLoanAmount.Value = prison.Finance.BankLoan;
            nCreditRating.Value = Convert.ToDecimal(prison.Finance.BankCreditRating*100);
            nOwnership.Value = Convert.ToDecimal(prison.Finance.Ownership);

            // Load prisoners tab
            UpdatePrisoners();
            SelectedPrisoner = null;

            // Load research tab
            clbResearch.Items.Clear();
            clbResearch.Items.AddRange(ResearchData.GetInGameNames());
            if (prison.Research != null) {
                foreach (ResearchItem item in prison.Research.Items) {
                    if (item.Label == "None") continue;
                    int idx = ResearchData.GetIndex(item.Label);
                    if (idx < 0) {
                        idx = ResearchData.AddItem(item.Label);
                        clbResearch.Items.Add(item.Label);
                    }
                    if (item.Progress > .999) {
                        clbResearch.SetItemChecked(idx, true);
                    }
                }
            }
        }


        void SaveGuiToPrison() {
            // Store general tab
            prison.TimeIndex = TimeConversion.ToIndex(
                Convert.ToInt32(nDay.Value), tTime.Text, cAmPm.SelectedIndex == 1);

            prison.EnabledMisconduct = xMisconduct.Checked;
            prison.EnabledIntake = xContinuousIntake.Checked;
            prison.EnabledVisibility = xFogOfWar.Checked;
            prison.FailureConditions = xFailureConditions.Checked;
            prison.EnabledDecay = xDecay.Checked;

            // Store finances tab
            prison.UnlimitedFunds = xUnlimitedFunds.Checked;
            prison.Finance.Balance = Convert.ToInt32(nBalance.Value);
            prison.Finance.BankLoan = Convert.ToInt32(nBankLoanAmount.Value);
            prison.Finance.BankCreditRating = Convert.ToDouble(nCreditRating.Value)/100;
            prison.Finance.Ownership = Convert.ToInt32(nOwnership.Value);

            // Prisoner tab is continuously saved already

            // Store research tab
            foreach (string itemName in ResearchData.AllResearch) {
                if (itemName == "None") continue;
                int idx = ResearchData.GetIndex(itemName);
                bool isUnlocked = clbResearch.GetItemChecked(idx);
                if (isUnlocked) {
                    prison.Research.Unlock(itemName);
                } else {
                    prison.Research.Lock(itemName);
                }
            }
        }


        void miRemoveAllTrees_Click(object sender, EventArgs e) {
            var idsToRemove = prison.Objects.OtherObjects
                                    .Values
                                    .Where(obj => obj.Type == "Tree")
                                    .Select(obj => obj.Id)
                                    .ToList();

            idsToRemove.ForEach(id => prison.Objects.OtherObjects.Remove(id));

            MessageBox.Show(idsToRemove.Count + " trees removed.");
        }


        void miUnlockAllResearch_Click(object sender, EventArgs e) {
            foreach (ResearchItem item in prison.Research.Items) {
                item.Progress = 1;
            }
            for (int i = 0; i < clbResearch.Items.Count; i++) {
                clbResearch.SetItemChecked(i, true);
            }
        }


        void miReleaseProtectiveCustody_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "Protected");
            MessageBox.Show(released + " Protective Custody prisoners released.");
            UpdatePrisoners();
        }


        void miReleaseMinimumSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "MinSec");
            MessageBox.Show(string.Format("{0} Minimum Security prisoners released.", released));
            UpdatePrisoners();
        }


        void miReleaseNormalSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "Normal");
            MessageBox.Show(string.Format("{0} Normal Security prisoners released.", released));
            UpdatePrisoners();
        }


        void miReleaseMaximumSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "MaxSec");
            MessageBox.Show(string.Format("{0} Maximum Security prisoners released.", released));
            UpdatePrisoners();
        }


        void miReleaseSuperMax_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "SuperMax");
            MessageBox.Show(string.Format("{0} SuperMax prisoners released.", released));
            UpdatePrisoners();
        }


        void miReleaseAll_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => true);
            MessageBox.Show(string.Format("All {0} prisoners released.", released));
            UpdatePrisoners();
        }


        void UpdatePrisonerCounts() {
            int countProtected = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "Protected").Length;
            miReleaseProtectiveCustody.Text = string.Format("Protective Custody ({0})", countProtected);
            miReleaseProtectiveCustody.Enabled = (countProtected > 0);

            int countMinSec = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "MinSec").Length;
            miReleaseMinimumSecurity.Text = string.Format("Minimum Security ({0})", countMinSec);
            miReleaseMinimumSecurity.Enabled = (countMinSec > 0);

            int countNormal = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "Normal").Length;
            miReleaseNormalSecurity.Text = string.Format("Normal Security ({0})", countNormal);
            miReleaseNormalSecurity.Enabled = (countNormal > 0);

            int countMaxSec = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "MaxSec").Length;
            miReleaseMaximumSecurity.Text = string.Format("Maximum Security ({0})", countMaxSec);
            miReleaseMaximumSecurity.Enabled = (countMaxSec > 0);

            int countSuperMax = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "SuperMax").Length;
            miReleaseSuperMax.Text = string.Format("SuperMax ({0})", countSuperMax);
            miReleaseSuperMax.Enabled = (countSuperMax > 0);

            int countAll = prison.Objects.Prisoners.Count;
            miReleaseAll.Text = string.Format("All ({0})", countAll);
            miReleaseAll.Enabled = (countAll > 0);
        }



        void UpdatePrisoners() {
            lbPrisoners.Items.Clear();
            prisonerNames =
                prison.Objects.Prisoners.Values
                      .Select(prisoner => prisoner.Bio.Forname + " " + prisoner.Bio.Surname)
                      .ToArray();
            lbPrisoners.Items.AddRange(prisonerNames);
            UpdatePrisonerCounts();
        }


        void lbPrisoners_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedPrisoner = prison.Objects.Prisoners.Values.ToArray()[lbPrisoners.SelectedIndex];
        }


        static bool ContainsIgnoreCase(string haystack, string needle) {
            return CultureInfo.InvariantCulture.CompareInfo
                              .IndexOf(haystack, needle, CompareOptions.IgnoreCase) >= 0;
        }


        void tPrisonerSearch_TextChanged(object sender, EventArgs e) {
            lbPrisoners.Items.Clear();
            lbPrisoners.Items.AddRange(
                prisonerNames.Where(name => ContainsIgnoreCase(name, tPrisonerSearch.Text)).ToArray());
        }


        void tName_TextChanged(object sender, EventArgs e) {
            if (SelectedPrisoner != null) {
                SelectedPrisoner.Bio.Forname = tName.Text;
            }
        }


        void tSurname_TextChanged(object sender, EventArgs e) {
            if (SelectedPrisoner != null) {
                SelectedPrisoner.Bio.Surname = tSurname.Text;
            }
        }


        void cCategory_SelectedIndexChanged(object sender, EventArgs e) {
            if (SelectedPrisoner != null) {
                SelectedPrisoner.Category = CategoryNames.Keys.ToArray()[cCategory.SelectedIndex];
            }
        }


        void bRelease_Click(object sender, EventArgs e) {
            PrisonerUtil.ReleasePrisoner(prison, SelectedPrisoner.Id);
            SelectedPrisoner = null;
            UpdatePrisoners();
        }


        Prisoner SelectedPrisoner {
            get { return selectedPrisoner; }
            set {
                selectedPrisoner = value;
                if (value == null) {
                    tName.Text = "";
                    tSurname.Text = "";
                    cCategory.SelectedIndex = -1;
                    tName.Enabled = false;
                    tSurname.Enabled = false;
                    cCategory.Enabled = false;
                    bRelease.Enabled = false;
                } else {
                    tName.Enabled = true;
                    tSurname.Enabled = true;
                    cCategory.Enabled = true;
                    bRelease.Enabled = true;
                    tName.Text = selectedPrisoner.Bio.Forname;
                    tSurname.Text = selectedPrisoner.Bio.Surname;
                    cCategory.SelectedIndex = Array.IndexOf(CategoryNames.Keys.ToArray(), selectedPrisoner.Category);
                }
            }
        }


        void miFileSaveAs_Click(object sender, EventArgs e) {
            if (saveAsDialog.ShowDialog() == DialogResult.OK) {
                fileName = saveAsDialog.FileName;
                miFileSave.PerformClick();
            }
        }


        void miFileSave_Click(object sender, EventArgs e) {
            Enabled = false;
            Text = String.Format("Saving {0} | {1}", Path.GetFileName(fileName), AppName);
            SaveGuiToPrison();

            string tempFileName = Path.GetTempFileName();
            using (FileStream fs = File.Create(tempFileName)) {
                using (var writer = new Writer(fs)) {
                    writer.WritePrison(prison);
                }
            }
            if (File.Exists(fileName)) {
                File.Replace(tempFileName, fileName, fileName + ".bak");
            } else {
                File.Move(tempFileName, fileName);
            }

            Text = String.Format("{0} | {1}", Path.GetFileName(fileName), AppName);
            Enabled = true;
        }
    }
}