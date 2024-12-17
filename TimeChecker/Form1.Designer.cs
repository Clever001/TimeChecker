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
            makeBoldToolStripMenuItem = new ToolStripMenuItem();
            fontSizeMenu = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            bigToolStripMenuItem = new ToolStripMenuItem();
            hugeToolStripMenuItem = new ToolStripMenuItem();
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
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { dateSettingToolStripMenuItem, makeBoldToolStripMenuItem, fontSizeMenu });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(172, 70);
            // 
            // dateSettingToolStripMenuItem
            // 
            dateSettingToolStripMenuItem.Name = "dateSettingToolStripMenuItem";
            dateSettingToolStripMenuItem.Size = new Size(171, 22);
            dateSettingToolStripMenuItem.Text = "Отобразить дату";
            dateSettingToolStripMenuItem.Click += dateSettingToolStripMenuItem_Click;
            // 
            // makeBoldToolStripMenuItem
            // 
            makeBoldToolStripMenuItem.Name = "makeBoldToolStripMenuItem";
            makeBoldToolStripMenuItem.Size = new Size(171, 22);
            makeBoldToolStripMenuItem.Text = "Сделать жирным";
            makeBoldToolStripMenuItem.Click += makeBoldToolStripMenuItem_Click;
            // 
            // fontSizeMenu
            // 
            fontSizeMenu.DropDownItems.AddRange(new ToolStripItem[] { smallToolStripMenuItem, mediumToolStripMenuItem, bigToolStripMenuItem, hugeToolStripMenuItem });
            fontSizeMenu.Name = "fontSizeMenu";
            fontSizeMenu.Size = new Size(171, 22);
            fontSizeMenu.Text = "Изменить размер";
            // 
            // smallToolStripMenuItem
            // 
            smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            smallToolStripMenuItem.Size = new Size(180, 22);
            smallToolStripMenuItem.Text = "Маленький";
            smallToolStripMenuItem.Click += smallToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem
            // 
            mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            mediumToolStripMenuItem.Size = new Size(180, 22);
            mediumToolStripMenuItem.Text = "Стандартный";
            mediumToolStripMenuItem.Click += mediumToolStripMenuItem_Click;
            // 
            // bigToolStripMenuItem
            // 
            bigToolStripMenuItem.Name = "bigToolStripMenuItem";
            bigToolStripMenuItem.Size = new Size(180, 22);
            bigToolStripMenuItem.Text = "Большой";
            bigToolStripMenuItem.Click += bigToolStripMenuItem_Click;
            // 
            // hugeToolStripMenuItem
            // 
            hugeToolStripMenuItem.Name = "hugeToolStripMenuItem";
            hugeToolStripMenuItem.Size = new Size(180, 22);
            hugeToolStripMenuItem.Text = "Самый большой";
            hugeToolStripMenuItem.Click += hugeToolStripMenuItem_Click;
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
        private ToolStripMenuItem fontSizeMenu;
        private ToolStripMenuItem smallToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem bigToolStripMenuItem;
        private ToolStripMenuItem hugeToolStripMenuItem;
        private ToolStripMenuItem makeBoldToolStripMenuItem;
    }
}
