namespace Draw.GUI
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.startLabel = new System.Windows.Forms.Label();
            this.newFileLabel = new System.Windows.Forms.LinkLabel();
            this.openFileLabel = new System.Windows.Forms.LinkLabel();
            this.addFolderDialog = new System.Windows.Forms.LinkLabel();
            this.recentFileLabel = new System.Windows.Forms.Label();
            this.keywordsLabel = new System.Windows.Forms.LinkLabel();
            this.helpLabel = new System.Windows.Forms.Label();
            this.xmldocLabel = new System.Windows.Forms.LinkLabel();
            this.repoLabel = new System.Windows.Forms.LinkLabel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.startLabel.Location = new System.Drawing.Point(31, 23);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(44, 20);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Start";
            // 
            // newFileLabel
            // 
            this.newFileLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.newFileLabel.AutoSize = true;
            this.newFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.newFileLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.newFileLabel.Location = new System.Drawing.Point(32, 53);
            this.newFileLabel.Name = "newFileLabel";
            this.newFileLabel.Size = new System.Drawing.Size(55, 16);
            this.newFileLabel.TabIndex = 1;
            this.newFileLabel.TabStop = true;
            this.newFileLabel.Text = "New file";
            this.newFileLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newFileLabel_LinkClicked);
            // 
            // openFileLabel
            // 
            this.openFileLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.openFileLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.openFileLabel.Location = new System.Drawing.Point(32, 73);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(61, 16);
            this.openFileLabel.TabIndex = 2;
            this.openFileLabel.TabStop = true;
            this.openFileLabel.Text = "Open file";
            // 
            // addFolderDialog
            // 
            this.addFolderDialog.ActiveLinkColor = System.Drawing.Color.White;
            this.addFolderDialog.AutoSize = true;
            this.addFolderDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFolderDialog.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.addFolderDialog.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.addFolderDialog.Location = new System.Drawing.Point(32, 93);
            this.addFolderDialog.Name = "addFolderDialog";
            this.addFolderDialog.Size = new System.Drawing.Size(150, 16);
            this.addFolderDialog.TabIndex = 3;
            this.addFolderDialog.TabStop = true;
            this.addFolderDialog.Text = "Add a workspace folder";
            // 
            // recentFileLabel
            // 
            this.recentFileLabel.AutoSize = true;
            this.recentFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.recentFileLabel.Location = new System.Drawing.Point(31, 176);
            this.recentFileLabel.Name = "recentFileLabel";
            this.recentFileLabel.Size = new System.Drawing.Size(85, 20);
            this.recentFileLabel.TabIndex = 4;
            this.recentFileLabel.Text = "Recent file";
            // 
            // keywordsLabel
            // 
            this.keywordsLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.keywordsLabel.AutoSize = true;
            this.keywordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keywordsLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.keywordsLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.keywordsLabel.Location = new System.Drawing.Point(32, 324);
            this.keywordsLabel.Name = "keywordsLabel";
            this.keywordsLabel.Size = new System.Drawing.Size(134, 16);
            this.keywordsLabel.TabIndex = 7;
            this.keywordsLabel.TabStop = true;
            this.keywordsLabel.Text = "Keywords and syntax";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.helpLabel.Location = new System.Drawing.Point(31, 294);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(42, 20);
            this.helpLabel.TabIndex = 6;
            this.helpLabel.Text = "Help";
            // 
            // xmldocLabel
            // 
            this.xmldocLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.xmldocLabel.AutoSize = true;
            this.xmldocLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmldocLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.xmldocLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.xmldocLabel.Location = new System.Drawing.Point(32, 344);
            this.xmldocLabel.Name = "xmldocLabel";
            this.xmldocLabel.Size = new System.Drawing.Size(127, 16);
            this.xmldocLabel.TabIndex = 8;
            this.xmldocLabel.TabStop = true;
            this.xmldocLabel.Text = "XML Documentation";
            // 
            // repoLabel
            // 
            this.repoLabel.ActiveLinkColor = System.Drawing.Color.White;
            this.repoLabel.AutoSize = true;
            this.repoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repoLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.repoLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(214)))));
            this.repoLabel.Location = new System.Drawing.Point(32, 364);
            this.repoLabel.Name = "repoLabel";
            this.repoLabel.Size = new System.Drawing.Size(109, 16);
            this.repoLabel.TabIndex = 9;
            this.repoLabel.TabStop = true;
            this.repoLabel.Text = "Github repository";
            // 
            // logoBox
            // 
            this.logoBox.Image = global::Draw.GUI.Properties.Resources.drawgui_icon;
            this.logoBox.Location = new System.Drawing.Point(323, 93);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(212, 207);
            this.logoBox.TabIndex = 10;
            this.logoBox.TabStop = false;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.fileNameLabel.Location = new System.Drawing.Point(32, 206);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(93, 16);
            this.fileNameLabel.TabIndex = 11;
            this.fileNameLabel.Text = "No recent files";
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.repoLabel);
            this.Controls.Add(this.xmldocLabel);
            this.Controls.Add(this.keywordsLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.recentFileLabel);
            this.Controls.Add(this.addFolderDialog);
            this.Controls.Add(this.openFileLabel);
            this.Controls.Add(this.newFileLabel);
            this.Controls.Add(this.startLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WelcomeForm";
            this.Text = "Welcome ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WelcomeForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.LinkLabel newFileLabel;
        private System.Windows.Forms.LinkLabel openFileLabel;
        private System.Windows.Forms.LinkLabel addFolderDialog;
        private System.Windows.Forms.Label recentFileLabel;
        private System.Windows.Forms.LinkLabel keywordsLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.LinkLabel xmldocLabel;
        private System.Windows.Forms.LinkLabel repoLabel;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label fileNameLabel;
    }
}

