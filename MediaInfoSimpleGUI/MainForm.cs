using MediaInfoLib;

namespace MediaInfoSimpleGUI
{
    public partial class MainForm : Form
    {
        private string SourcePath = "";

        private char[] invalidChars = Path.GetInvalidPathChars();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.OverwritePrompt = false; // ask later
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
            try
            {
                ValidateInputFile(path);
                SourcePath = path;
            }
            catch (Exception ex)
            {
                textBoxIn.Text = "";
                richTextBoxOutput.Text = "";
                buttonSave.Enabled = false;

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            textBoxIn.Text = Path.GetFileName(SourcePath);

            MediaInfo MI = new MediaInfo();

            /*string ToDisplay;
            //Test if version of DLL is compatible : 3rd argument is "version of DLL tested;Your application name;Your application version"
            ToDisplay = MI.Option("Info_Version", "0.7.0.0;MediaInfoDLL_Example_CS;0.7.0.0");
            if (ToDisplay.Length == 0)
            {
                richTextBoxOutput.Text = "MediaInfo.Dll: this version of the DLL is not compatible";
                return;
            }*/

            MI.Open(SourcePath);
            //MI.Option("Complete");
            richTextBoxOutput.Text = MI.Inform();
            MI.Close();

            buttonSave.Enabled = true;
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
    }
}