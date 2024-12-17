using System.Text;
using TimeCheckerClasses;

namespace TimeChecker {
    public partial class MainForm : Form {
        private Clock? _clock;
        private MenuAttrs _menuAttrs;
        private readonly object _locker = new();

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            // Инициализация атрибутов меню
            _menuAttrs = new() {

            };
            UpdateFont();

            // Инициализация контекстного меню
            dateSettingToolStripMenuItem.Checked = false;
            // Инициализация часов
            _clock = new() {
                Condition = CallCondition
            };

            _clock.CurTimeChanged += OnCurTimeChanged;
            _clock.TrueCondition += OnTrueCondition;

            _clock.StartClock();
        }

        private void UpdateFont() {
            TimeLabel.Font = _menuAttrs.Font;
            TimeLabel.Refresh();
        }

        private void OnCurTimeChanged(DateTime dt) {
            if (InvokeRequired) {
                Invoke(new Action<DateTime>(OnCurTimeChanged), dt);
                return;
            }
            lock (_locker) {
                if (_menuAttrs.PrintDate) {
                    StringBuilder output = new();
                    output.AppendLine(dt.ToShortDateString());
                    output.Append(dt.ToLongTimeString());
                    TimeLabel.Text = output.ToString();
                }
                else {
                    TimeLabel.Text = dt.ToLongTimeString();
                }
            }
        }

        private async void OnTrueCondition(DateTime dt) {
            if (InvokeRequired) {
                Invoke(new Action<DateTime>(OnTrueCondition), dt);
                return;
            }
            TimeLabel.ForeColor = Color.Red;
            TimeLabel.Refresh();
            await Task.Delay(10000);
            TimeLabel.ForeColor = Color.White;
            TimeLabel.Refresh();
        }

        private bool CallCondition(DateTime dt) => dt.Second % 30 == 0;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            _clock?.Dispose();
        }

        private void dateSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) { _menuAttrs.PrintDate = !_menuAttrs.PrintDate; }
            dateSettingToolStripMenuItem.Checked = !dateSettingToolStripMenuItem.Checked;
            OnCurTimeChanged(DateTime.Now);
        }

        private void selectFontToolStripMenuItem_Click(object sender, EventArgs e) {
            fontDialog.ShowDialog();
            lock (_locker) {
                _menuAttrs.Font = fontDialog.Font;
                UpdateFont();
            }
        }
    }
}
