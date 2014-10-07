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
            miFileOpen.PerformClick();
        }


        void miFileOpen_Click(object sender, EventArgs e) {
            FileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                fileName = openFileDialog.FileName;
                using (FileStream fs = File.OpenRead(openFileDialog.FileName)) {
                    Text = String.Format("Loading {0} | PASaveEditor", Path.GetFileName(fileName));
                    prison = new Parser().Load(fs);
                    LoadPrisonToGUI();
                    Enabled = true;
                    Text = String.Format("{0} | PASaveEditor", Path.GetFileName(fileName));
                }
            }
        }


        void LoadPrisonToGUI() {
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