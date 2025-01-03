using System.Media;
using TimeCheckerClasses;

namespace TimeChecker {
    public partial class MainForm : Form {
        private bool _isMoving = false;
        private Point _oldPosition;

        private MainFormAttrs _mainFormAttrs;
        private Clock? _clock;
        private MenuAttrs _menuAttrs;
        private SoundPlayer? _soundPlayer;
        private readonly object _locker = new();
        CancellationTokenSource _cancellationTokenSource = new();

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            _mainFormAttrs = MainFormAttrs.Load();
            ClientSize = _mainFormAttrs.Size;
            Location = _mainFormAttrs.Point;

            // ������������� ��������� ����
            _menuAttrs = MenuAttrs.Load();
            UpdateFont();
            BackColor = _menuAttrs.Color;
            Refresh();

            // ������������� ������������ ����
            dateSettingToolStripMenuItem.Checked = false;
            // ������������� �����
            _clock = new();

            InitClockCondition();

            _clock.CurTimeChanged += OnCurTimeChanged;
            _clock.TrueCondition += OnTrueCondition;

            _clock.StartClock();

            try {
                _soundPlayer = new SoundPlayer("alarm.wav");
            }
            catch {
                MessageBox.Show("��������� ����� ������� ��� ���������������!", "ERROR");
            }
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
            lock (_locker) { waitTime = _menuAttrs.WaitTime; }
            TimeLabel.ForeColor = Color.Red;
            TimeLabel.Refresh();

            _soundPlayer?.Play();

            try {
                await Task.Delay(Math.Max(1000 * 60 * waitTime, 60000), _cancellationTokenSource.Token);
            }
            catch (TaskCanceledException) {
                // ��������� �����������.
            }

            _soundPlayer?.Stop();

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
                        MessageBox.Show("�� ������� ��������� ���������.", "���������");
                        Close();
                        return;
                    }
                }
                //Task.Run(() => {
                //    MenuAttrs.Save(_menuAttrs);
                //});

                MessageBox.Show("��������� ������� ���������.", "���������");
            }
            else {
                MessageBox.Show("��������� �� ���� ���������!", "���������");
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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void TimeLabel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                _isMoving = true;
                _oldPosition = e.Location;
            }
        }

        private void TimeLabel_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                _isMoving = false;
            }
        }

        private void TimeLabel_MouseMove(object sender, MouseEventArgs e) {
            if (_isMoving) {
                Point p = e.Location;
                int dx = p.X - _oldPosition.X;
                int dy = p.Y - _oldPosition.Y;
                p = Location;
                p.Offset(dx, dy);
                Location = p;
            }
        }

        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            if (m.Msg == NativeMethods.WM_NCHITTEST) {
                base.WndProc(ref m);

                Point cursor = PointToClient(new Point(m.LParam.ToInt32()));
                if (cursor.X <= RESIZE_HANDLE_SIZE) {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)NativeMethods.HTTOPLEFT;
                    else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)NativeMethods.HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)NativeMethods.HTLEFT;
                }
                else if (cursor.X >= this.ClientSize.Width - RESIZE_HANDLE_SIZE) {
                    if (cursor.Y <= RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)NativeMethods.HTTOPRIGHT;
                    else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE)
                        m.Result = (IntPtr)NativeMethods.HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)NativeMethods.HTRIGHT;
                }
                else if (cursor.Y <= RESIZE_HANDLE_SIZE) {
                    m.Result = (IntPtr)NativeMethods.HTTOP;
                }
                else if (cursor.Y >= this.ClientSize.Height - RESIZE_HANDLE_SIZE) {
                    m.Result = (IntPtr)NativeMethods.HTBOTTOM;
                }

                return;
            }

            base.WndProc(ref m);
        }

        private void selectColorToolStripMenuItem_Click(object sender, EventArgs e) {
            colorDialog.Color = _menuAttrs.Color;
            colorDialog.ShowDialog();
            lock (_locker) {
                _menuAttrs.Color = colorDialog.Color;
                BackColor = _menuAttrs.Color;
                Refresh();
            }
        }
    }
}
