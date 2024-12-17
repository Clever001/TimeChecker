using TimeCheckerClasses;

namespace TimeChecker {
    public partial class Settings : Form {
        public bool ApplySuccess { get; set; } = false;
        public MenuAttrs MenuAttrs { get => _menuAttrs; set => _menuAttrs = value; }
        private MenuAttrs _menuAttrs;
        private bool _firstCheckListBoxChange = true;
        private bool _firstComboBoxChange = true;

        public Settings(MenuAttrs menuAttrs) {
            MenuAttrs = menuAttrs;

            InitializeComponent();

            checkedListBox1.SetItemCheckState(MenuAttrs.RepeatFreqIndex, CheckState.Checked);
            comboBox.SelectedIndex = MenuAttrs.WaitTime;
        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e) {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (_firstCheckListBoxChange) {
                _firstCheckListBoxChange = false;
                return;
            }
            if (e.Index != MenuAttrs.RepeatFreqIndex) {
                checkedListBox1.SetItemCheckState(MenuAttrs.RepeatFreqIndex, CheckState.Unchecked);
                switch (e.Index) {
                    case 0:
                        _menuAttrs.RepeatFreq = RepeatFreq.FiveMinutes;
                        break;
                    case 1:
                        _menuAttrs.RepeatFreq = RepeatFreq.FiveteenMinutes;
                        break;
                    case 2:
                        _menuAttrs.RepeatFreq = RepeatFreq.HalfAnHour;
                        break;
                    case 3:
                        _menuAttrs.RepeatFreq = RepeatFreq.Hour;
                        break;
                    case 4:
                        _menuAttrs.RepeatFreq = RepeatFreq.FourHours;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                checkedListBox1.SetItemCheckState(e.Index, CheckState.Checked);
                checkedListBox1.Refresh();
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (_firstComboBoxChange) {
                _firstComboBoxChange = false;
                return;
            }
            _menuAttrs.WaitTime = comboBox.SelectedIndex;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            ApplySuccess = true;
            Close();
        }
    }
}
