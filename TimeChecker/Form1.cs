using TimeCheckerClasses;

namespace TimeChecker {
    public partial class MainForm : Form {
        private Clock? _clock;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            _clock = new() {

            };

            _clock.CurTimeChanged += OnCurTimeChanged;

            _clock.StartClock();
        }

        private void OnCurTimeChanged(DateTime dt) {
            if (InvokeRequired) {
                Invoke(new Action<DateTime>(OnCurTimeChanged), dt);
                return;
            }
            TimeLabel.Text = dt.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            _clock?.Dispose();
        }
    }
}
