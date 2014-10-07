namespace PASaveEditor {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Label lOwnershipUnits;
            System.Windows.Forms.Label lBankLoanAmontUnits;
            System.Windows.Forms.Label lBankLoanAmount;
            System.Windows.Forms.Label lCreditRating;
            System.Windows.Forms.Label lCreditRatingUnits;
            System.Windows.Forms.Label lOwnership;
            System.Windows.Forms.Label lBalance;
            System.Windows.Forms.Label lBalanceUnits;
            this.tabs = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xMisconduct = new System.Windows.Forms.CheckBox();
            this.xFogOfWar = new System.Windows.Forms.CheckBox();
            this.xFailureConditions = new System.Windows.Forms.CheckBox();
            this.xContinuousIntake = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cAmPm = new System.Windows.Forms.ComboBox();
            this.tTime = new System.Windows.Forms.MaskedTextBox();
            this.nDay = new System.Windows.Forms.NumericUpDown();
            this.lDay = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.tpPrisoners = new System.Windows.Forms.TabPage();
            this.tpResearch = new System.Windows.Forms.TabPage();
            this.clbResearch = new System.Windows.Forms.CheckedListBox();
            this.tpFinance = new System.Windows.Forms.TabPage();
            this.nOwnership = new System.Windows.Forms.NumericUpDown();
            this.xUnlimitedFunds = new System.Windows.Forms.CheckBox();
            this.nBankLoanAmount = new System.Windows.Forms.NumericUpDown();
            this.nCreditRating = new System.Windows.Forms.NumericUpDown();
            this.nBalance = new System.Windows.Forms.NumericUpDown();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasePrisonersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimumSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximumSecurityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTunnelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unlockAllResearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lOwnershipUnits = new System.Windows.Forms.Label();
            lBankLoanAmontUnits = new System.Windows.Forms.Label();
            lBankLoanAmount = new System.Windows.Forms.Label();
            lCreditRating = new System.Windows.Forms.Label();
            lCreditRatingUnits = new System.Windows.Forms.Label();
            lOwnership = new System.Windows.Forms.Label();
            lBalance = new System.Windows.Forms.Label();
            lBalanceUnits = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDay)).BeginInit();
            this.tpResearch.SuspendLayout();
            this.tpFinance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOwnership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBankLoanAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCreditRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBalance)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tpGeneral);
            this.tabs.Controls.Add(this.tpFinance);
            this.tabs.Controls.Add(this.tpPrisoners);
            this.tabs.Controls.Add(this.tpResearch);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 24);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(584, 388);
            this.tabs.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Controls.Add(this.groupBox1);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(576, 362);
            this.tpGeneral.TabIndex = 4;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xMisconduct);
            this.groupBox2.Controls.Add(this.xFogOfWar);
            this.groupBox2.Controls.Add(this.xFailureConditions);
            this.groupBox2.Controls.Add(this.xContinuousIntake);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prison Settings";
            // 
            // xMisconduct
            // 
            this.xMisconduct.AutoSize = true;
            this.xMisconduct.Location = new System.Drawing.Point(23, 88);
            this.xMisconduct.Name = "xMisconduct";
            this.xMisconduct.Size = new System.Drawing.Size(81, 17);
            this.xMisconduct.TabIndex = 3;
            this.xMisconduct.Text = "Misconduct";
            this.xMisconduct.UseVisualStyleBackColor = true;
            // 
            // xFogOfWar
            // 
            this.xFogOfWar.AutoSize = true;
            this.xFogOfWar.Location = new System.Drawing.Point(23, 65);
            this.xFogOfWar.Name = "xFogOfWar";
            this.xFogOfWar.Size = new System.Drawing.Size(76, 17);
            this.xFogOfWar.TabIndex = 2;
            this.xFogOfWar.Text = "Fog of war";
            this.xFogOfWar.UseVisualStyleBackColor = true;
            // 
            // xFailureConditions
            // 
            this.xFailureConditions.AutoSize = true;
            this.xFailureConditions.Location = new System.Drawing.Point(23, 42);
            this.xFailureConditions.Name = "xFailureConditions";
            this.xFailureConditions.Size = new System.Drawing.Size(108, 17);
            this.xFailureConditions.TabIndex = 1;
            this.xFailureConditions.Text = "Failure conditions";
            this.xFailureConditions.UseVisualStyleBackColor = true;
            // 
            // xContinuousIntake
            // 
            this.xContinuousIntake.AutoSize = true;
            this.xContinuousIntake.Location = new System.Drawing.Point(23, 19);
            this.xContinuousIntake.Name = "xContinuousIntake";
            this.xContinuousIntake.Size = new System.Drawing.Size(111, 17);
            this.xContinuousIntake.TabIndex = 0;
            this.xContinuousIntake.Text = "Continuous intake";
            this.xContinuousIntake.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cAmPm);
            this.groupBox1.Controls.Add(this.tTime);
            this.groupBox1.Controls.Add(this.nDay);
            this.groupBox1.Controls.Add(this.lDay);
            this.groupBox1.Controls.Add(this.lTime);
            this.groupBox1.Location = new System.Drawing.Point(8, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 95);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "In-game time";
            // 
            // cAmPm
            // 
            this.cAmPm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cAmPm.FormattingEnabled = true;
            this.cAmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cAmPm.Location = new System.Drawing.Point(108, 53);
            this.cAmPm.Name = "cAmPm";
            this.cAmPm.Size = new System.Drawing.Size(44, 21);
            this.cAmPm.TabIndex = 4;
            // 
            // tTime
            // 
            this.tTime.Location = new System.Drawing.Point(52, 53);
            this.tTime.Mask = "90:00";
            this.tTime.Name = "tTime";
            this.tTime.Size = new System.Drawing.Size(50, 20);
            this.tTime.TabIndex = 3;
            this.tTime.ValidatingType = typeof(System.DateTime);
            // 
            // nDay
            // 
            this.nDay.Location = new System.Drawing.Point(52, 27);
            this.nDay.Name = "nDay";
            this.nDay.Size = new System.Drawing.Size(50, 20);
            this.nDay.TabIndex = 2;
            // 
            // lDay
            // 
            this.lDay.AutoSize = true;
            this.lDay.Location = new System.Drawing.Point(20, 29);
            this.lDay.Name = "lDay";
            this.lDay.Size = new System.Drawing.Size(26, 13);
            this.lDay.TabIndex = 0;
            this.lDay.Text = "Day";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(16, 56);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(30, 13);
            this.lTime.TabIndex = 1;
            this.lTime.Text = "Time";
            // 
            // tpPrisoners
            // 
            this.tpPrisoners.Location = new System.Drawing.Point(4, 22);
            this.tpPrisoners.Name = "tpPrisoners";
            this.tpPrisoners.Size = new System.Drawing.Size(576, 362);
            this.tpPrisoners.TabIndex = 2;
            this.tpPrisoners.Text = "Prisoners";
            this.tpPrisoners.UseVisualStyleBackColor = true;
            // 
            // tpResearch
            // 
            this.tpResearch.Controls.Add(this.clbResearch);
            this.tpResearch.Location = new System.Drawing.Point(4, 22);
            this.tpResearch.Name = "tpResearch";
            this.tpResearch.Size = new System.Drawing.Size(576, 362);
            this.tpResearch.TabIndex = 3;
            this.tpResearch.Text = "Research";
            this.tpResearch.UseVisualStyleBackColor = true;
            // 
            // clbResearch
            // 
            this.clbResearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbResearch.FormattingEnabled = true;
            this.clbResearch.Location = new System.Drawing.Point(0, 0);
            this.clbResearch.Name = "clbResearch";
            this.clbResearch.Size = new System.Drawing.Size(576, 362);
            this.clbResearch.TabIndex = 0;
            // 
            // tpFinance
            // 
            this.tpFinance.Controls.Add(lOwnershipUnits);
            this.tpFinance.Controls.Add(this.nOwnership);
            this.tpFinance.Controls.Add(this.xUnlimitedFunds);
            this.tpFinance.Controls.Add(lBankLoanAmontUnits);
            this.tpFinance.Controls.Add(lBankLoanAmount);
            this.tpFinance.Controls.Add(this.nBankLoanAmount);
            this.tpFinance.Controls.Add(lCreditRating);
            this.tpFinance.Controls.Add(lCreditRatingUnits);
            this.tpFinance.Controls.Add(lOwnership);
            this.tpFinance.Controls.Add(this.nCreditRating);
            this.tpFinance.Controls.Add(lBalance);
            this.tpFinance.Controls.Add(lBalanceUnits);
            this.tpFinance.Controls.Add(this.nBalance);
            this.tpFinance.Location = new System.Drawing.Point(4, 22);
            this.tpFinance.Name = "tpFinance";
            this.tpFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tpFinance.Size = new System.Drawing.Size(576, 362);
            this.tpFinance.TabIndex = 5;
            this.tpFinance.Text = "Finance";
            this.tpFinance.UseVisualStyleBackColor = true;
            // 
            // lOwnershipUnits
            // 
            lOwnershipUnits.AutoSize = true;
            lOwnershipUnits.Location = new System.Drawing.Point(178, 121);
            lOwnershipUnits.Name = "lOwnershipUnits";
            lOwnershipUnits.Size = new System.Drawing.Size(15, 13);
            lOwnershipUnits.TabIndex = 15;
            lOwnershipUnits.Text = "%";
            // 
            // nOwnership
            // 
            this.nOwnership.Location = new System.Drawing.Point(110, 119);
            this.nOwnership.Name = "nOwnership";
            this.nOwnership.Size = new System.Drawing.Size(62, 20);
            this.nOwnership.TabIndex = 14;
            this.nOwnership.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // xUnlimitedFunds
            // 
            this.xUnlimitedFunds.AutoSize = true;
            this.xUnlimitedFunds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xUnlimitedFunds.Location = new System.Drawing.Point(26, 17);
            this.xUnlimitedFunds.Name = "xUnlimitedFunds";
            this.xUnlimitedFunds.Size = new System.Drawing.Size(98, 17);
            this.xUnlimitedFunds.TabIndex = 7;
            this.xUnlimitedFunds.Text = "Unlimited funds";
            this.xUnlimitedFunds.UseVisualStyleBackColor = true;
            // 
            // lBankLoanAmontUnits
            // 
            lBankLoanAmontUnits.AutoSize = true;
            lBankLoanAmontUnits.Location = new System.Drawing.Point(178, 69);
            lBankLoanAmontUnits.Name = "lBankLoanAmontUnits";
            lBankLoanAmontUnits.Size = new System.Drawing.Size(13, 13);
            lBankLoanAmontUnits.TabIndex = 13;
            lBankLoanAmontUnits.Text = "$";
            // 
            // lBankLoanAmount
            // 
            lBankLoanAmount.AutoSize = true;
            lBankLoanAmount.Location = new System.Drawing.Point(11, 69);
            lBankLoanAmount.Name = "lBankLoanAmount";
            lBankLoanAmount.Size = new System.Drawing.Size(93, 13);
            lBankLoanAmount.TabIndex = 5;
            lBankLoanAmount.Text = "Bank loan amount";
            // 
            // nBankLoanAmount
            // 
            this.nBankLoanAmount.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nBankLoanAmount.Location = new System.Drawing.Point(110, 67);
            this.nBankLoanAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nBankLoanAmount.Name = "nBankLoanAmount";
            this.nBankLoanAmount.Size = new System.Drawing.Size(62, 20);
            this.nBankLoanAmount.TabIndex = 12;
            // 
            // lCreditRating
            // 
            lCreditRating.AutoSize = true;
            lCreditRating.Location = new System.Drawing.Point(41, 95);
            lCreditRating.Name = "lCreditRating";
            lCreditRating.Size = new System.Drawing.Size(63, 13);
            lCreditRating.TabIndex = 4;
            lCreditRating.Text = "Credit rating";
            // 
            // lCreditRatingUnits
            // 
            lCreditRatingUnits.AutoSize = true;
            lCreditRatingUnits.Location = new System.Drawing.Point(178, 95);
            lCreditRatingUnits.Name = "lCreditRatingUnits";
            lCreditRatingUnits.Size = new System.Drawing.Size(15, 13);
            lCreditRatingUnits.TabIndex = 11;
            lCreditRatingUnits.Text = "%";
            // 
            // lOwnership
            // 
            lOwnership.AutoSize = true;
            lOwnership.Location = new System.Drawing.Point(47, 121);
            lOwnership.Name = "lOwnership";
            lOwnership.Size = new System.Drawing.Size(57, 13);
            lOwnership.TabIndex = 6;
            lOwnership.Text = "Ownership";
            // 
            // nCreditRating
            // 
            this.nCreditRating.Location = new System.Drawing.Point(110, 93);
            this.nCreditRating.Name = "nCreditRating";
            this.nCreditRating.Size = new System.Drawing.Size(62, 20);
            this.nCreditRating.TabIndex = 10;
            this.nCreditRating.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lBalance
            // 
            lBalance.AutoSize = true;
            lBalance.Location = new System.Drawing.Point(58, 43);
            lBalance.Name = "lBalance";
            lBalance.Size = new System.Drawing.Size(46, 13);
            lBalance.TabIndex = 3;
            lBalance.Text = "Balance";
            // 
            // lBalanceUnits
            // 
            lBalanceUnits.AutoSize = true;
            lBalanceUnits.Location = new System.Drawing.Point(178, 43);
            lBalanceUnits.Name = "lBalanceUnits";
            lBalanceUnits.Size = new System.Drawing.Size(13, 13);
            lBalanceUnits.TabIndex = 9;
            lBalanceUnits.Text = "$";
            // 
            // nBalance
            // 
            this.nBalance.Location = new System.Drawing.Point(110, 41);
            this.nBalance.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nBalance.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nBalance.Name = "nBalance";
            this.nBalance.Size = new System.Drawing.Size(62, 20);
            this.nBalance.TabIndex = 8;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.shortcutsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(584, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileOpen,
            this.miFileSave,
            this.miFileSaveAs,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miFileOpen
            // 
            this.miFileOpen.Name = "miFileOpen";
            this.miFileOpen.Size = new System.Drawing.Size(123, 22);
            this.miFileOpen.Text = "Open...";
            this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
            // 
            // miFileSave
            // 
            this.miFileSave.Name = "miFileSave";
            this.miFileSave.Size = new System.Drawing.Size(123, 22);
            this.miFileSave.Text = "Save";
            // 
            // miFileSaveAs
            // 
            this.miFileSaveAs.Name = "miFileSaveAs";
            this.miFileSaveAs.Size = new System.Drawing.Size(123, 22);
            this.miFileSaveAs.Text = "Save As...";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(123, 22);
            this.miExit.Text = "Exit";
            // 
            // shortcutsToolStripMenuItem
            // 
            this.shortcutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.releasePrisonersToolStripMenuItem,
            this.removeTunnelsToolStripMenuItem,
            this.unlockAllResearchToolStripMenuItem,
            this.removeAllTreesToolStripMenuItem});
            this.shortcutsToolStripMenuItem.Name = "shortcutsToolStripMenuItem";
            this.shortcutsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.shortcutsToolStripMenuItem.Text = "Shortcuts";
            // 
            // releasePrisonersToolStripMenuItem
            // 
            this.releasePrisonersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minToolStripMenuItem,
            this.minimumSecurityToolStripMenuItem,
            this.normalSecurityToolStripMenuItem,
            this.maximumSecurityToolStripMenuItem,
            this.superMaxToolStripMenuItem,
            this.toolStripSeparator1,
            this.allToolStripMenuItem});
            this.releasePrisonersToolStripMenuItem.Name = "releasePrisonersToolStripMenuItem";
            this.releasePrisonersToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.releasePrisonersToolStripMenuItem.Text = "Release prisoners";
            // 
            // minToolStripMenuItem
            // 
            this.minToolStripMenuItem.Name = "minToolStripMenuItem";
            this.minToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.minToolStripMenuItem.Text = "Protective Custody";
            // 
            // minimumSecurityToolStripMenuItem
            // 
            this.minimumSecurityToolStripMenuItem.Name = "minimumSecurityToolStripMenuItem";
            this.minimumSecurityToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.minimumSecurityToolStripMenuItem.Text = "Minimum Security";
            // 
            // normalSecurityToolStripMenuItem
            // 
            this.normalSecurityToolStripMenuItem.Name = "normalSecurityToolStripMenuItem";
            this.normalSecurityToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.normalSecurityToolStripMenuItem.Text = "Normal Security";
            // 
            // maximumSecurityToolStripMenuItem
            // 
            this.maximumSecurityToolStripMenuItem.Name = "maximumSecurityToolStripMenuItem";
            this.maximumSecurityToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.maximumSecurityToolStripMenuItem.Text = "Maximum Security";
            // 
            // superMaxToolStripMenuItem
            // 
            this.superMaxToolStripMenuItem.Name = "superMaxToolStripMenuItem";
            this.superMaxToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.superMaxToolStripMenuItem.Text = "SuperMax";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.allToolStripMenuItem.Text = "All";
            // 
            // removeTunnelsToolStripMenuItem
            // 
            this.removeTunnelsToolStripMenuItem.Name = "removeTunnelsToolStripMenuItem";
            this.removeTunnelsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.removeTunnelsToolStripMenuItem.Text = "Remove tunnels";
            // 
            // unlockAllResearchToolStripMenuItem
            // 
            this.unlockAllResearchToolStripMenuItem.Name = "unlockAllResearchToolStripMenuItem";
            this.unlockAllResearchToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.unlockAllResearchToolStripMenuItem.Text = "Unlock all research";
            // 
            // removeAllTreesToolStripMenuItem
            // 
            this.removeAllTreesToolStripMenuItem.Name = "removeAllTreesToolStripMenuItem";
            this.removeAllTreesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.removeAllTreesToolStripMenuItem.Text = "Remove all trees";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Prison Architect Save Editor";
            this.tabs.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDay)).EndInit();
            this.tpResearch.ResumeLayout(false);
            this.tpFinance.ResumeLayout(false);
            this.tpFinance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nOwnership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBankLoanAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCreditRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBalance)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpPrisoners;
        private System.Windows.Forms.TabPage tpResearch;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cAmPm;
        private System.Windows.Forms.MaskedTextBox tTime;
        private System.Windows.Forms.NumericUpDown nDay;
        private System.Windows.Forms.Label lDay;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.TabPage tpFinance;
        private System.Windows.Forms.NumericUpDown nOwnership;
        private System.Windows.Forms.CheckBox xUnlimitedFunds;
        private System.Windows.Forms.NumericUpDown nBankLoanAmount;
        private System.Windows.Forms.NumericUpDown nCreditRating;
        private System.Windows.Forms.NumericUpDown nBalance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox xFailureConditions;
        private System.Windows.Forms.CheckBox xContinuousIntake;
        private System.Windows.Forms.CheckBox xFogOfWar;
        private System.Windows.Forms.CheckBox xMisconduct;
        private System.Windows.Forms.ToolStripMenuItem shortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasePrisonersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimumSecurityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalSecurityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximumSecurityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem superMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTunnelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unlockAllResearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllTreesToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox clbResearch;
    }
}

