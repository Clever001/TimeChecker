using System.Text;
using TimeCheckerClasses;

namespace TimeChecker {
    public partial class MainForm : Form {
        private Clock? _clock;
        private MenuAttrs _menuAttrs;
        private readonly object _locker = new();

        private readonly ToolStripMenuItem[] _fontSizeMenus;

        public MainForm() {
            InitializeComponent();
            _fontSizeMenus = [
                smallToolStripMenuItem,
                mediumToolStripMenuItem,
                bigToolStripMenuItem,
                hugeToolStripMenuItem
            ];
        }

        private void MainForm_Load(object sender, EventArgs e) {
            // Инициализация атрибутов меню
            _menuAttrs = new() {
                //PrintDate = true
            };
            UpdateFont();

            // Инициализация контекстного меню
            dateSettingToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;

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
            Array.ForEach(_fontSizeMenus, menu => menu.Checked = false);
            switch (_menuAttrs.FontSize) {
                case (float)FontSize.Small:
                    smallToolStripMenuItem.Checked = true;
                    break;
                case (float)FontSize.Medium:
                    mediumToolStripMenuItem.Checked = true;
                    break;
                case (float)FontSize.Big:
                    bigToolStripMenuItem.Checked = true;
                    break;
                case (float)FontSize.Huge:
                    hugeToolStripMenuItem.Checked = true;
                    break;
                default:
                    MessageBox.Show("Возникла проблема с установкой размера шрифта.", "ERROR");
                    throw new ArgumentOutOfRangeException(nameof(_menuAttrs.FontSize));
            }
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

        private void smallToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) {
                _menuAttrs.FontSize = (float)FontSize.Small;
                UpdateFont();
            }
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) {
                _menuAttrs.FontSize = (float)FontSize.Medium;
                UpdateFont();
            }
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) {
                _menuAttrs.FontSize = (float)FontSize.Big;
                UpdateFont();
            }
        }

        private void hugeToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) {
                _menuAttrs.FontSize = (float)FontSize.Huge;
                UpdateFont();
            }
        }

        private void makeBoldToolStripMenuItem_Click(object sender, EventArgs e) {
            lock (_locker) {
                _menuAttrs.Bold = !_menuAttrs.Bold;
                UpdateFont();
            }
            makeBoldToolStripMenuItem.Checked = !makeBoldToolStripMenuItem.Checked;
        }
    }
}
