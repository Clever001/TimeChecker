namespace TimeChecker {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            TimeLabel = new Label();
            contextMenuStrip = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            dateSettingToolStripMenuItem = new ToolStripMenuItem();
            selectFontToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            fontDialog = new FontDialog();
            panel1 = new Panel();
            colorDialog = new ColorDialog();
            selectColorToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TimeLabel
            // 
            resources.ApplyResources(TimeLabel, "TimeLabel");
            TimeLabel.ForeColor = Color.White;
            TimeLabel.Name = "TimeLabel";
            TimeLabel.MouseDown += TimeLabel_MouseDown;
            TimeLabel.MouseMove += TimeLabel_MouseMove;
            TimeLabel.MouseUp += TimeLabel_MouseUp;
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(contextMenuStrip, "contextMenuStrip");
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, dateSettingToolStripMenuItem, selectFontToolStripMenuItem, selectColorToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // dateSettingToolStripMenuItem
            // 
            resources.ApplyResources(dateSettingToolStripMenuItem, "dateSettingToolStripMenuItem");
            dateSettingToolStripMenuItem.Name = "dateSettingToolStripMenuItem";
            dateSettingToolStripMenuItem.Click += dateSettingToolStripMenuItem_Click;
            // 
            // selectFontToolStripMenuItem
            // 
            resources.ApplyResources(selectFontToolStripMenuItem, "selectFontToolStripMenuItem");
            selectFontToolStripMenuItem.Name = "selectFontToolStripMenuItem";
            selectFontToolStripMenuItem.Click += selectFontToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(closeToolStripMenuItem, "closeToolStripMenuItem");
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.White;
            panel1.Name = "panel1";
            panel1.MouseDown += TimeLabel_MouseDown;
            panel1.MouseMove += TimeLabel_MouseMove;
            panel1.MouseUp += TimeLabel_MouseUp;
            // 
            // selectColorToolStripMenuItem
            // 
            resources.ApplyResources(selectColorToolStripMenuItem, "selectColorToolStripMenuItem");
            selectColorToolStripMenuItem.Name = "selectColorToolStripMenuItem";
            selectColorToolStripMenuItem.Click += selectColorToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.LightSteelBlue;
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(panel1);
            Controls.Add(TimeLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            TopMost = true;
            FormClosing += MainForm_FormClosing_1;
            Load += MainForm_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label TimeLabel;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem dateSettingToolStripMenuItem;
        private ToolStripMenuItem selectFontToolStripMenuItem;
        private FontDialog fontDialog;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Panel panel1;
        private ColorDialog colorDialog;
        private ToolStripMenuItem selectColorToolStripMenuItem;
    }
}
