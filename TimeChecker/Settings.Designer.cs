namespace TimeChecker {
    partial class Settings {
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            checkedListBox1 = new CheckedListBox();
            panel1 = new Panel();
            applyButton = new Button();
            groupBox2 = new GroupBox();
            comboBox = new ComboBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(474, 53);
            label1.TabIndex = 0;
            label1.Text = "Настройки";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(0, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(474, 132);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Настройте периодичность срабатывания";
            // 
            // checkedListBox1
            // 
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Каждые 5 минут", "Каждые 15 минут", "Каждые 30 минут", "Каждый час", "Каждые 4 часа" });
            checkedListBox1.Location = new Point(3, 25);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(468, 104);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // panel1
            // 
            panel1.Controls.Add(applyButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 254);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 100);
            panel1.TabIndex = 2;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(161, 25);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(148, 46);
            applyButton.TabIndex = 0;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(0, 185);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(474, 63);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "За сколько минут включать оповещение?";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "0", "1", "2", "3", "4" });
            comboBox.Location = new Point(12, 28);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 29);
            comboBox.TabIndex = 0;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 354);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Settings";
            Text = "Настройки";
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Button applyButton;
        private GroupBox groupBox2;
        private ComboBox comboBox;
        private CheckedListBox checkedListBox1;
    }
}