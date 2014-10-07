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
                    Text = String.Format("Loading {0} | PASaveEditor", Path.GetFileName(fileName));
                    prison = new Parser().Load(fs);
                    LoadPrisonToGui();
                    Enabled = true;
                    Text = String.Format("{0} | PASaveEditor", Path.GetFileName(fileName));
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
            nCreditRating.Value = Convert.ToDecimal(prison.Finance.BankCreditRating);
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
        }
    }
}