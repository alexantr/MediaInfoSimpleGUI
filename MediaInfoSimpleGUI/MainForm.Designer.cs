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
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxOutput.Location = new System.Drawing.Point(7, 47);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxOutput.Size = new System.Drawing.Size(958, 784);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.TabStop = false;
            this.richTextBoxOutput.Text = "";
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(7, 8);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(840, 31);
            this.textBoxIn.TabIndex = 1;
            this.textBoxIn.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(853, 839);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(112, 34);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Exit";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(125, 839);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 34);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(853, 7);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(112, 34);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open file";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(7, 839);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(112, 34);
            this.buttonCopy.TabIndex = 3;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(243, 844);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(24, 25);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "...";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 880);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxIn);
            this.Controls.Add(this.richTextBoxOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaInfo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBoxOutput;
        private TextBox textBoxIn;
        private Button buttonClose;
        private Button buttonSave;
        private Button buttonOpen;
        private Button buttonCopy;
        private Label labelInfo;
    }
}