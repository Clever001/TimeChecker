using System.Text;
using System.Threading;
using TimeCheckerClasses;

namespace TimeChecker {
    public partial class MainForm : Form {
        private MainFormAttrs _mainFormAttrs;
        private Clock? _clock;
        private MenuAttrs _menuAttrs;
        private readonly object _locker = new();
        CancellationTokenSource _cancellationTokenSource = new();

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            _mainFormAttrs = MainFormAttrs.Load();
            ClientSize = _mainFormAttrs.Size;
            Location = _mainFormAttrs.Point;

            // Инициализация атрибутов меню
            _menuAttrs = MenuAttrs.Load();
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
            _clock.ChangeCondition((dt) => (dt.Second == 0 && (dt.Hour * 60 + dt.Minute + waitTime) % repeatFreq == 0));
        }

        private void UpdateFont() {
            TimeLabel.Font = _menuAttrs.Font;
            TimeLabel.Refresh();
        }

        private void OnCurTimeChanged(DateTime dt, CancellationToken? token) {
            if (token?.IsCancellationRequested == true) return;

            if (InvokeRequired) {
                if (IsHandleCreated && !IsDisposed) {
                    BeginInvoke(new Action<DateTime, CancellationToken?>(OnCurTimeChanged), dt, token);
                }
                return;
            }

            lock (_locker) {
                TimeLabel.Text = _menuAttrs.PrintDate
                    ? $"{dt.ToShortDateString()}\n{dt.ToLongTimeString()}"
                    : dt.ToLongTimeString();
            }
        }

        private async void OnTrueCondition(DateTime dt, CancellationToken? token) {
            if (token?.IsCancellationRequested == true) return;

            if (InvokeRequired) {
                if (IsHandleCreated && !IsDisposed) {
                    BeginInvoke(new Action<DateTime, CancellationToken?>(OnTrueCondition), dt, token);
                }
                return;
            }

            int waitTime;
            lock(_locker) { waitTime = _menuAttrs.WaitTime; }
            TimeLabel.ForeColor = Color.Red;
            TimeLabel.Refresh();
            try {
                await Task.Delay(Math.Max(1000 * 60 * waitTime, 60000), _cancellationTokenSource.Token);
            } catch (TaskCanceledException) {
                // Программа закрывается.
            }
            if (!_cancellationTokenSource.IsCancellationRequested) {
                TimeLabel.ForeColor = Color.White;
                TimeLabel.Refresh();
            }
        }

        private bool CallCondition(DateTime dt) => dt.Second % 30 == 0;

        private void dateSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) { _menuAttrs.PrintDate = !_menuAttrs.PrintDate; }
            dateSettingToolStripMenuItem.Checked = !dateSettingToolStripMenuItem.Checked;
            OnCurTimeChanged(DateTime.Now, null);
        }

        private void selectFontToolStripMenuItem_Click(object sender, EventArgs e) {
            fontDialog.Font = _menuAttrs.Font;
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
                //Task.Run(() => {
                //    MenuAttrs.Save(_menuAttrs);
                //});

                MessageBox.Show("Настройки успешно сохранены.", "Настройки");
            }
            else {
                MessageBox.Show("Настройки НЕ были применены!", "Настройки");
            }
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e) {
            _mainFormAttrs.Size = ClientSize;
            _mainFormAttrs.Point = Location;
            MainFormAttrs.Save(_mainFormAttrs);
            MenuAttrs.Save(_menuAttrs);
            _cancellationTokenSource.Cancel();
            _clock?.Dispose();
        }
    }
}
