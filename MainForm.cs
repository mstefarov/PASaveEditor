using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileModel;

namespace PASaveEditor {
    public partial class MainForm : Form {
        string fileName;
        Prison prison;

        public MainForm() {
            InitializeComponent();
            clbResearch.Items.AddRange(ResearchData.GetInGameNames());
            Enabled = false;
        }


        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            miFileOpen.PerformClick();
        }


        void miFileOpen_Click(object sender, EventArgs e) {
            FileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                fileName = openFileDialog.FileName;
                using (FileStream fs = File.OpenRead(openFileDialog.FileName)) {
                    Text = String.Format("Loading {0} | Prison Architect Save Editor", Path.GetFileName(fileName));
                    prison = new Parser().Load(fs);
                    LoadPrisonToGui();
                    Enabled = true;
                    Text = String.Format("{0} | Prison Architect Save Editor", Path.GetFileName(fileName));
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

            // Load finances tab
            xUnlimitedFunds.Checked = prison.UnlimitedFunds;
            nBalance.Value = prison.Finance.Balance;
            nBankLoanAmount.Value = prison.Finance.BankLoan;
            nCreditRating.Value = Convert.ToDecimal(prison.Finance.BankCreditRating*100);
            nOwnership.Value = Convert.ToDecimal(prison.Finance.Ownership);

            // Load research tab
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

            UpdatePrisonerCounts();
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

        private void miReleaseProtectiveCustody_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "Protected");
            MessageBox.Show(released + " Protective Custody prisoners released.");
            UpdatePrisonerCounts();
        }

        private void miReleaseMinimumSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "MinSec");
            MessageBox.Show(string.Format("{0} Minimum Security prisoners released.", released));
            UpdatePrisonerCounts();
        }

        private void miReleaseNormalSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "Normal");
            MessageBox.Show(string.Format("{0} Normal Security prisoners released.", released));
            UpdatePrisonerCounts();
        }

        private void miReleaseMaximumSecurity_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "MaxSec");
            MessageBox.Show(string.Format("{0} Maximum Security prisoners released.", released));
            UpdatePrisonerCounts();
        }

        private void miReleaseSuperMax_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => prisoner.Category == "SuperMax");
            MessageBox.Show(string.Format("{0} SuperMax prisoners released.", released));
            UpdatePrisonerCounts();
        }

        private void miReleaseAll_Click(object sender, EventArgs e) {
            int released = PrisonerUtil.Release(prison, prisoner => true);
            MessageBox.Show(string.Format("All {0} prisoners released.", released));
            UpdatePrisonerCounts();
        }


        void UpdatePrisonerCounts() {
            int countProtected = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "Protected").Length;
            miReleaseProtectiveCustody.Text = string.Format("Protective Custody ({0})", countProtected);
            miReleaseProtectiveCustody.Enabled = (countProtected > 0);

            int countMinSec = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "MinSec").Length;
            miReleaseMinimumSecurity.Text = string.Format("Minimum Security ({0})",countMinSec);
            miReleaseMinimumSecurity.Enabled = (countMinSec > 0);

            int countNormal = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "Normal").Length;
            miReleaseNormalSecurity.Text = string.Format("Normal Security ({0})",countNormal);
            miReleaseNormalSecurity.Enabled = (countNormal > 0);

            int countMaxSec = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "MaxSec").Length;
            miReleaseMaximumSecurity.Text = string.Format("Maximum Security ({0})",countMaxSec);
            miReleaseMaximumSecurity.Enabled = (countMaxSec > 0);

            int countSuperMax = PrisonerUtil.FindPrisoners(prison, prisoner => prisoner.Category == "SuperMax").Length;
            miReleaseSuperMax.Text = string.Format("SuperMax ({0})", countSuperMax);
            miReleaseSuperMax.Enabled = (countSuperMax > 0);

            int countAll = prison.Objects.Prisoners.Count;
            miReleaseAll.Text = string.Format("All ({0})", countAll);
            miReleaseAll.Enabled = (countAll > 0);
        }
    }
}