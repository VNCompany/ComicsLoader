namespace ComicsLoader
{
    partial class Main
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
            label1 = new Label();
            tbUrl = new TextBox();
            rtbHtml = new RichTextBox();
            label2 = new Label();
            label4 = new Label();
            cbXPath = new ComboBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "URL:";
            // 
            // tbUrl
            // 
            tbUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbUrl.Location = new Point(14, 36);
            tbUrl.Margin = new Padding(3, 4, 3, 4);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(525, 27);
            tbUrl.TabIndex = 1;
            // 
            // rtbHtml
            // 
            rtbHtml.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbHtml.Location = new Point(14, 107);
            rtbHtml.Margin = new Padding(3, 4, 3, 4);
            rtbHtml.Name = "rtbHtml";
            rtbHtml.Size = new Size(525, 256);
            rtbHtml.TabIndex = 2;
            rtbHtml.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 83);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 3;
            label2.Text = "HTML:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(14, 380);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "XPath:";
            // 
            // cbXPath
            // 
            cbXPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbXPath.FormattingEnabled = true;
            cbXPath.Location = new Point(14, 404);
            cbXPath.Margin = new Padding(3, 4, 3, 4);
            cbXPath.Name = "cbXPath";
            cbXPath.Size = new Size(525, 28);
            cbXPath.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Bottom;
            btnSearch.Enabled = false;
            btnSearch.Location = new Point(222, 443);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 45);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(553, 508);
            Controls.Add(btnSearch);
            Controls.Add(cbXPath);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(rtbHtml);
            Controls.Add(tbUrl);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(557, 518);
            Name = "Main";
            Text = "Comics Loader v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbUrl;
        private RichTextBox rtbHtml;
        private Label label2;
        private Label label4;
        private ComboBox cbXPath;
        private Button btnSearch;
    }
}
