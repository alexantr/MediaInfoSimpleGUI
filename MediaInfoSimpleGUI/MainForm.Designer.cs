namespace MediaInfoSimpleGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            textBoxIn = new TextBox();
            buttonClose = new Button();
            buttonSave = new Button();
            buttonOpen = new Button();
            buttonCopy = new Button();
            labelInfo = new Label();
            buttonAbout = new Button();
            textBoxOutput = new TextBox();
            SuspendLayout();
            // 
            // textBoxIn
            // 
            textBoxIn.Location = new Point(7, 8);
            textBoxIn.Name = "textBoxIn";
            textBoxIn.ReadOnly = true;
            textBoxIn.Size = new Size(866, 31);
            textBoxIn.TabIndex = 1;
            textBoxIn.TabStop = false;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(879, 819);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(112, 34);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Exit";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(125, 819);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(879, 7);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(112, 34);
            buttonOpen.TabIndex = 2;
            buttonOpen.Text = "Browse...";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(7, 819);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(112, 34);
            buttonCopy.TabIndex = 3;
            buttonCopy.Text = "Copy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(243, 824);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(24, 25);
            labelInfo.TabIndex = 5;
            labelInfo.Text = "...";
            // 
            // buttonAbout
            // 
            buttonAbout.Location = new Point(761, 819);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(112, 34);
            buttonAbout.TabIndex = 6;
            buttonAbout.Text = "About";
            buttonAbout.UseVisualStyleBackColor = true;
            buttonAbout.Click += buttonAbout_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Font = new Font("Consolas", 9F);
            textBoxOutput.Location = new Point(7, 47);
            textBoxOutput.MaxLength = int.MaxValue;
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(984, 766);
            textBoxOutput.TabIndex = 0;
            textBoxOutput.TabStop = false;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 860);
            Controls.Add(textBoxOutput);
            Controls.Add(buttonAbout);
            Controls.Add(labelInfo);
            Controls.Add(buttonCopy);
            Controls.Add(buttonOpen);
            Controls.Add(buttonSave);
            Controls.Add(buttonClose);
            Controls.Add(textBoxIn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaInfo";
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            KeyDown += MainForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private TextBox textBoxIn;
        private Button buttonClose;
        private Button buttonSave;
        private Button buttonOpen;
        private Button buttonCopy;
        private Label labelInfo;
        private Button buttonAbout;
        private TextBox textBoxOutput;
    }
}