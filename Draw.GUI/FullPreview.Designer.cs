namespace Draw.GUI.Presenters
{
    partial class FullPreview
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pieBox = new System.Windows.Forms.CheckBox();
            this.arcBox = new System.Windows.Forms.CheckBox();
            this.circleBox = new System.Windows.Forms.CheckBox();
            this.rectangleBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 528);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pieBox);
            this.groupBox1.Controls.Add(this.arcBox);
            this.groupBox1.Controls.Add(this.circleBox);
            this.groupBox1.Controls.Add(this.rectangleBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1254, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw.GUI Toolbox";
            // 
            // pieBox
            // 
            this.pieBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.pieBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.SpringGreen;
            this.pieBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pieBox.Location = new System.Drawing.Point(330, 32);
            this.pieBox.Name = "pieBox";
            this.pieBox.Size = new System.Drawing.Size(77, 42);
            this.pieBox.TabIndex = 3;
            this.pieBox.Text = "Pie";
            this.pieBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pieBox.UseVisualStyleBackColor = true;
            this.pieBox.CheckedChanged += new System.EventHandler(this.pieBox_CheckedChanged);
            // 
            // arcBox
            // 
            this.arcBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.arcBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.SpringGreen;
            this.arcBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.arcBox.Location = new System.Drawing.Point(237, 32);
            this.arcBox.Name = "arcBox";
            this.arcBox.Size = new System.Drawing.Size(77, 42);
            this.arcBox.TabIndex = 2;
            this.arcBox.Text = "Arc";
            this.arcBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.arcBox.UseVisualStyleBackColor = true;
            this.arcBox.CheckedChanged += new System.EventHandler(this.arcBox_CheckedChanged);
            // 
            // circleBox
            // 
            this.circleBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.circleBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.circleBox.Location = new System.Drawing.Point(123, 32);
            this.circleBox.Name = "circleBox";
            this.circleBox.Size = new System.Drawing.Size(97, 42);
            this.circleBox.TabIndex = 1;
            this.circleBox.Text = "Circle/Ellipse";
            this.circleBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.circleBox.UseVisualStyleBackColor = true;
            this.circleBox.CheckedChanged += new System.EventHandler(this.circleBox_CheckedChanged);
            // 
            // rectangleBox
            // 
            this.rectangleBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectangleBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.SpringGreen;
            this.rectangleBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rectangleBox.Location = new System.Drawing.Point(29, 32);
            this.rectangleBox.Name = "rectangleBox";
            this.rectangleBox.Size = new System.Drawing.Size(77, 42);
            this.rectangleBox.TabIndex = 0;
            this.rectangleBox.Text = "Rectangle";
            this.rectangleBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rectangleBox.UseVisualStyleBackColor = true;
            this.rectangleBox.CheckedChanged += new System.EventHandler(this.rectangleBox_CheckedChanged);
            // 
            // FullPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FullPreview";
            this.Text = "Untitled";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox pieBox;
        private System.Windows.Forms.CheckBox arcBox;
        private System.Windows.Forms.CheckBox circleBox;
        private System.Windows.Forms.CheckBox rectangleBox;
    }
}