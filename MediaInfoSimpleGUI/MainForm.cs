using MediaInfoLib;
using Timer = System.Windows.Forms.Timer;

namespace MediaInfoSimpleGUI
{
    public partial class MainForm : Form
    {
        private string SourcePath = "";

        private char[] invalidChars = Path.GetInvalidPathChars();

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

            MediaInfo MI = new MediaInfo();
            richTextBoxOutput.Text = MI.Option("Info_Version");
            MI.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                LoadFile(commandLineArgs[1]);
            }
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                Clipboard.SetText(richTextBoxOutput.Text);
                ShowInfo("Copied info to clipboard");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.OverwritePrompt = true;
                    dialog.ValidateNames = true;
                    dialog.Filter = "Text files|*.txt";

                    try
                    {
                        dialog.InitialDirectory = Path.GetDirectoryName(SourcePath);
                        dialog.FileName = Path.GetFileName(SourcePath) + ".txt";
                    }
                    catch (Exception) { }

                    if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                    {
                        //string ext = Path.GetExtension(dialog.FileName).ToLower();

                        File.WriteAllText(dialog.FileName, richTextBoxOutput.Text);
                        ShowInfo("Saved info to file");
                    }
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ValidateNames = true;

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    LoadFile(dialog.FileName);
                }
            }
        }

        private void LoadFile(string path)
        {
            SourcePath = "";
            labelInfo.Text = "";
            textBoxIn.Text = "";
            richTextBoxOutput.Text = "";
            buttonCopy.Enabled = false;
            buttonSave.Enabled = false;

            try
            {
                ValidateInputFile(path);
                SourcePath = path;
            }
            catch (Exception ex)
            {
                richTextBoxOutput.Text = ex.Message;
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            textBoxIn.Text = Path.GetFileName(SourcePath);
            richTextBoxOutput.Text = "Loading...";

            MediaInfo MI = new MediaInfo();

            /*string ToDisplay;
            //Test if version of DLL is compatible : 3rd argument is "version of DLL tested;Your application name;Your application version"
            ToDisplay = MI.Option("Info_Version", "0.7.0.0;MediaInfoDLL_Example_CS;0.7.0.0");
            if (ToDisplay.Length == 0)
            {
                richTextBoxOutput.Text = "MediaInfo.Dll: this version of the DLL is not compatible";
                return;
            }*/

            int res = MI.Open(SourcePath);
            //MI.Option("Complete");
            richTextBoxOutput.Text = MI.Inform();
            MI.Close();

            if (res > 0)
            {
                buttonCopy.Enabled = true;
                buttonSave.Enabled = true;
            }
        }

        private void ValidateInputFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("No file selected!");
            }
            if (input.IndexOfAny(invalidChars) >= 0)
            {
                throw new Exception("Invalid chars in path!");
            }
            if (!File.Exists(input))
            {
                throw new Exception("File not found!");
            }
        }

        private void ShowInfo(string text)
        {
            labelInfo.Text = text;
            if (timer != null)
                timer.Stop();

            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += timerElapsed;
            timer.Start();
        }

        private void timerElapsed(object sender, EventArgs eventArgs)
        {
            timer.Stop();
            labelInfo.Text = "";
        }
    }
}