using Rhino;
using Rhino.Commands;
using System.Windows;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace CommandManager.Windows
{
    /// <summary>
    /// CommandManagerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommandManagerWindow : Window
    {
        private RhinoDoc _doc;
        private RunMode _mode;
        private string lastFillIn = Settings.LastFillIn;

        public CommandManagerWindow(RhinoDoc doc, RunMode mode)
        {
            InitializeComponent();
            filepathTextBox.Text = lastFillIn;
            _doc = doc;
            _mode = mode;
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(filepathTextBox.Text))
            {
                MessageBox.Show("Assembly null");
            }
            AddOn addOn = new AddOn(filepathTextBox.Text);

            lastFillIn = filepathTextBox.Text;

            addOn.RunCMDMethod.Invoke(addOn.CommandInstance, new object[] { _doc, _mode });

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.LastFillIn = filepathTextBox.Text;
            Close();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Assembly files (*.dll;*.exe,*.mcl,*.rhp)|*.dll;*.exe;*.mcl;*.rhp|All files|*.*||";
            if (openFileDialog.ShowDialog() == true)
            {
                filepathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}