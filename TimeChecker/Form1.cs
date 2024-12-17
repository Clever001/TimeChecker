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
            _clock = new();

            InitClockCondition();

            _clock.CurTimeChanged += OnCurTimeChanged;
            _clock.TrueCondition += OnTrueCondition;

            _clock.StartClock();
        }

        public void InitClockCondition() {
            if (_clock is null) throw new ArgumentNullException(nameof(_clock));
            int waitTime = _menuAttrs.WaitTime, repeatFreq = (int)_menuAttrs.RepeatFreq;
            _clock.ChangeCondition((dt) => (dt.Hour * 60 + dt.Minute + waitTime) % repeatFreq == 0 && dt.Second == 0);
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
            int waitTime;
            lock(_locker) { waitTime = _menuAttrs.WaitTime; }
            TimeLabel.ForeColor = Color.Red;
            TimeLabel.Refresh();
            await Task.Delay(1000 * 60 * waitTime);
            TimeLabel.ForeColor = Color.White;
            TimeLabel.Refresh();
        }

        private bool CallCondition(DateTime dt) => dt.Second % 30 == 0;

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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings settingsForm;
            lock (_locker) { settingsForm = new((MenuAttrs)_menuAttrs.Clone()); }
            settingsForm.ShowDialog();
            if (settingsForm.ApplySuccess) {
                lock (_locker) {
                    _menuAttrs = settingsForm.MenuAttrs;
                    try {
                        InitClockCondition();
                    }
                    catch (ArgumentNullException) {
                        MessageBox.Show("Не удалось применить настройки.", "Настройки");
                        Close();
                        return;
                    }
                }
                MessageBox.Show("Настройки успешно сохранены.", "Настройки");
            }
            else {
                MessageBox.Show("Настройки НЕ были применены!", "Настройки");
            }
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e) {
            _clock?.Dispose();
        }
    }
}
