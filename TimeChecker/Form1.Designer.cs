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
            TimeLabel = new Label();
            contextMenuStrip = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            dateSettingToolStripMenuItem = new ToolStripMenuItem();
            selectFontToolStripMenuItem = new ToolStripMenuItem();
            fontDialog = new FontDialog();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TimeLabel
            // 
            TimeLabel.Dock = DockStyle.Fill;
            TimeLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TimeLabel.ForeColor = Color.White;
            TimeLabel.Location = new Point(0, 0);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(248, 128);
            TimeLabel.TabIndex = 0;
            TimeLabel.Text = "label1";
            TimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, dateSettingToolStripMenuItem, selectFontToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(165, 70);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(164, 22);
            settingsToolStripMenuItem.Text = "Настройки";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // dateSettingToolStripMenuItem
            // 
            dateSettingToolStripMenuItem.Name = "dateSettingToolStripMenuItem";
            dateSettingToolStripMenuItem.Size = new Size(164, 22);
            dateSettingToolStripMenuItem.Text = "Отобразить дату";
            dateSettingToolStripMenuItem.Click += dateSettingToolStripMenuItem_Click;
            // 
            // selectFontToolStripMenuItem
            // 
            selectFontToolStripMenuItem.Name = "selectFontToolStripMenuItem";
            selectFontToolStripMenuItem.Size = new Size(164, 22);
            selectFontToolStripMenuItem.Text = "Выбрать шрифт";
            selectFontToolStripMenuItem.Click += selectFontToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(248, 128);
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(TimeLabel);
            MinimumSize = new Size(160, 80);
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "TimeChecker";
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
    }
}
