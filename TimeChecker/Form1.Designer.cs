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
            dateSettingToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TimeLabel
            // 
            TimeLabel.Anchor = AnchorStyles.None;
            TimeLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TimeLabel.ForeColor = Color.White;
            TimeLabel.Location = new Point(12, 9);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(224, 110);
            TimeLabel.TabIndex = 0;
            TimeLabel.Text = "label1";
            TimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { dateSettingToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(165, 26);
            // 
            // dateSettingToolStripMenuItem
            // 
            dateSettingToolStripMenuItem.Name = "dateSettingToolStripMenuItem";
            dateSettingToolStripMenuItem.Size = new Size(164, 22);
            dateSettingToolStripMenuItem.Text = "Отобразить дату";
            dateSettingToolStripMenuItem.Click += dateSettingToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(248, 128);
            ContextMenuStrip = contextMenuStrip;
            Controls.Add(TimeLabel);
            MinimumSize = new Size(200, 150);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeChecker";
            Load += MainForm_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label TimeLabel;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem dateSettingToolStripMenuItem;
    }
}
