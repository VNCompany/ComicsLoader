namespace ComicsLoader
{
    partial class SaveDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenSaveDialog = new Button();
            label1 = new Label();
            lbElements = new ListBox();
            tbOutputDir = new TextBox();
            groupBox1 = new GroupBox();
            rbAbsolute = new RadioButton();
            rbInject = new RadioButton();
            rbAppend = new RadioButton();
            rbInjectRoot = new RadioButton();
            btnQueue = new Button();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenSaveDialog
            // 
            btnOpenSaveDialog.Location = new Point(405, 421);
            btnOpenSaveDialog.Margin = new Padding(3, 4, 3, 4);
            btnOpenSaveDialog.Name = "btnOpenSaveDialog";
            btnOpenSaveDialog.Size = new Size(114, 31);
            btnOpenSaveDialog.TabIndex = 0;
            btnOpenSaveDialog.Text = "Select";
            btnOpenSaveDialog.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 397);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "Save path:";
            // 
            // lbElements
            // 
            lbElements.FormattingEnabled = true;
            lbElements.Location = new Point(7, 63);
            lbElements.Margin = new Padding(3, 4, 3, 4);
            lbElements.Name = "lbElements";
            lbElements.Size = new Size(491, 284);
            lbElements.TabIndex = 2;
            // 
            // tbOutputDir
            // 
            tbOutputDir.Location = new Point(14, 423);
            tbOutputDir.Margin = new Padding(3, 4, 3, 4);
            tbOutputDir.Name = "tbOutputDir";
            tbOutputDir.Size = new Size(383, 27);
            tbOutputDir.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbAbsolute);
            groupBox1.Controls.Add(rbInject);
            groupBox1.Controls.Add(rbAppend);
            groupBox1.Controls.Add(rbInjectRoot);
            groupBox1.Controls.Add(lbElements);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(505, 363);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Items";
            // 
            // rbAbsolute
            // 
            rbAbsolute.AutoSize = true;
            rbAbsolute.Location = new Point(163, 29);
            rbAbsolute.Margin = new Padding(3, 4, 3, 4);
            rbAbsolute.Name = "rbAbsolute";
            rbAbsolute.Size = new Size(89, 24);
            rbAbsolute.TabIndex = 6;
            rbAbsolute.TabStop = true;
            rbAbsolute.Text = "Absolute";
            rbAbsolute.UseVisualStyleBackColor = true;
            rbAbsolute.CheckedChanged += rb_CheckedChanged;
            // 
            // rbInject
            // 
            rbInject.AutoSize = true;
            rbInject.Location = new Point(335, 29);
            rbInject.Margin = new Padding(3, 4, 3, 4);
            rbInject.Name = "rbInject";
            rbInject.Size = new Size(66, 24);
            rbInject.TabIndex = 5;
            rbInject.TabStop = true;
            rbInject.Text = "Inject";
            rbInject.UseVisualStyleBackColor = true;
            rbInject.CheckedChanged += rb_CheckedChanged;
            // 
            // rbAppend
            // 
            rbAppend.AutoSize = true;
            rbAppend.Location = new Point(252, 29);
            rbAppend.Margin = new Padding(3, 4, 3, 4);
            rbAppend.Name = "rbAppend";
            rbAppend.Size = new Size(83, 24);
            rbAppend.TabIndex = 4;
            rbAppend.TabStop = true;
            rbAppend.Text = "Append";
            rbAppend.UseVisualStyleBackColor = true;
            rbAppend.CheckedChanged += rb_CheckedChanged;
            // 
            // rbInjectRoot
            // 
            rbInjectRoot.AutoSize = true;
            rbInjectRoot.Location = new Point(404, 29);
            rbInjectRoot.Margin = new Padding(3, 4, 3, 4);
            rbInjectRoot.Name = "rbInjectRoot";
            rbInjectRoot.Size = new Size(98, 24);
            rbInjectRoot.TabIndex = 3;
            rbInjectRoot.TabStop = true;
            rbInjectRoot.Text = "InjectRoot";
            rbInjectRoot.UseVisualStyleBackColor = true;
            rbInjectRoot.CheckedChanged += rb_CheckedChanged;
            // 
            // btnQueue
            // 
            btnQueue.Location = new Point(270, 480);
            btnQueue.Margin = new Padding(3, 4, 3, 4);
            btnQueue.Name = "btnQueue";
            btnQueue.Size = new Size(114, 44);
            btnQueue.TabIndex = 5;
            btnQueue.Text = "Queue";
            btnQueue.UseVisualStyleBackColor = true;
            btnQueue.Click += btnQueue_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(149, 480);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 44);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // SaveDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 551);
            Controls.Add(btnSave);
            Controls.Add(btnQueue);
            Controls.Add(groupBox1);
            Controls.Add(tbOutputDir);
            Controls.Add(label1);
            Controls.Add(btnOpenSaveDialog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimumSize = new Size(546, 584);
            Name = "SaveDialog";
            Text = "Save comics";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenSaveDialog;
        private Label label1;
        private ListBox lbElements;
        private TextBox tbOutputDir;
        private GroupBox groupBox1;
        private RadioButton rbAbsolute;
        private RadioButton rbInject;
        private RadioButton rbAppend;
        private RadioButton rbInjectRoot;
        private Button btnQueue;
        private Button btnSave;
    }
}