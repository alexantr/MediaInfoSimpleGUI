using MediaInfoLib;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;

#pragma warning disable IDE0017 // Simplify object initialization

namespace MediaInfoSimpleGUI
{
    public partial class MainForm : Form
    {
        private string sourcePath = "";

        private readonly string loadingText = "Loading...";

        private readonly char[] invalidChars = Path.GetInvalidPathChars();

        private Timer timer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonCopy.Enabled = false;
            buttonSave.Enabled = false;
            labelInfo.Text = "";
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                textBoxOutput.Text = loadingText;
                
                timer = new();
                timer.Interval = 250;
                timer.Tick += ShownTimerElapsed;
                timer.Start();
            }
        }

        private void ShownTimerElapsed(object sender, EventArgs eventArgs)
        {
            timer.Stop();
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
                LoadFile(commandLineArgs[1]);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadFile(files[0]);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (e.Control && e.KeyCode == Keys.S)
                SaveInfo();

            if (e.Control && e.KeyCode == Keys.O)
                OpenFile();

            if (e.Control && e.KeyCode == Keys.C && (!textBoxOutput.Focused || textBoxOutput.SelectionLength == 0))
                CopyInfo();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopyInfo();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetAboutInfo(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyInfo()
        {
            if (!string.IsNullOrEmpty(sourcePath))
            {
                Clipboard.SetText(textBoxOutput.Text);
                ShowNotify("Copied info to clipboard");
            }
        }

        private void OpenFile()
        {
            using OpenFileDialog dialog = new();

            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ValidateNames = true;

            if (!string.IsNullOrWhiteSpace(sourcePath))
            {
                string inPath = Path.GetDirectoryName(sourcePath);
                if (Directory.Exists(inPath))
                    dialog.InitialDirectory = inPath;
            }

            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                LoadFile(dialog.FileName);
        }

        private void SaveInfo()
        {
            if (!string.IsNullOrEmpty(sourcePath))
            {
                using SaveFileDialog dialog = new();

                dialog.OverwritePrompt = true;
                dialog.ValidateNames = true;
                dialog.Filter = "Text files|*.txt";

                try
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(sourcePath);
                    dialog.FileName = "MediaInfo " + Path.GetFileName(sourcePath) + ".txt";
                }
                catch (Exception) { }

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    File.WriteAllText(dialog.FileName, textBoxOutput.Text);
                    ShowNotify("Saved info to file");
                }
            }
        }

        private void LoadFile(string path)
        {
            sourcePath = "";

            labelInfo.Text = "";
            textBoxIn.Text = "";
            textBoxOutput.Text = loadingText;
            buttonCopy.Enabled = false;
            buttonSave.Enabled = false;

            try
            {
                ValidateInputFile(path);
                sourcePath = path;
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = ex.Message;
                return;
            }

            textBoxIn.Text = Path.GetFileName(sourcePath);

            MediaInfo MI = new();

            int res = MI.Open(sourcePath);
            //MI.Option("Complete");
            textBoxOutput.Text = MI.Inform();
            MI.Close();

            if (res > 0)
            {
                buttonCopy.Enabled = true;
                buttonSave.Enabled = true;
            }
        }

        private void ValidateInputFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.IndexOfAny(invalidChars) >= 0)
                throw new("Invalid file path!");
            if (!File.Exists(input))
                throw new("File not found!");
        }

        private void ShowNotify(string text)
        {
            labelInfo.Text = text;
            if (timer != null)
                timer.Stop();

            timer = new();
            timer.Interval = 3000;
            timer.Tick += NotifyTimerElapsed;
            timer.Start();
        }

        private void NotifyTimerElapsed(object sender, EventArgs eventArgs)
        {
            timer.Stop();
            labelInfo.Text = "";
        }

        private static string GetAboutInfo()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            
            string appName = ((AssemblyTitleAttribute)ass.GetCustomAttribute(typeof(AssemblyTitleAttribute))).Title;
            
            Version version = ass.GetName().Version;
            string niceVersion = version.Major.ToString() + "." + version.Minor.ToString();
            if (version.Build != 0 || version.Revision != 0)
                niceVersion += "." + version.Build.ToString();
            if (version.Revision != 0)
                niceVersion += "." + version.Revision.ToString();

            string info = $"{appName} - v{niceVersion}\n";

            MediaInfo MI = new();
            info += MI.Option("Info_Version");
            MI.Close();

            return info;
        }
    }
}