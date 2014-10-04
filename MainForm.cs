using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PASaveEditor {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }


        void miFileOpen_Click(object sender, EventArgs e) {
            FileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                using (FileStream fs = File.OpenRead(openFileDialog.FileName)) {
                    new Parser().Load(fs);
                }
            }
        }
    }
}