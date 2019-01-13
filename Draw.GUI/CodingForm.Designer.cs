using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Draw.GUI
{
    partial class CodingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodingForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOutputInFullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridlinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFillDrawingObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordsAndSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pieBox = new System.Windows.Forms.CheckBox();
            this.arcBox = new System.Windows.Forms.CheckBox();
            this.circleBox = new System.Windows.Forms.CheckBox();
            this.rectangleBox = new System.Windows.Forms.CheckBox();
            this.textureFillDrawingObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.newFileToolStripMenuItem,
            this.newWindowToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAsImageToolStripMenuItem,
            this.closeWindowToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newFileToolStripMenuItem.Text = "New file";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newWindowToolStripMenuItem.Text = "New window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save file";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsImageToolStripMenuItem.Text = "Save as Image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // closeWindowToolStripMenuItem
            // 
            this.closeWindowToolStripMenuItem.Name = "closeWindowToolStripMenuItem";
            this.closeWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeWindowToolStripMenuItem.Text = "Close window";
            this.closeWindowToolStripMenuItem.Click += new System.EventHandler(this.closeWindowToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem1,
            this.runCodeToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildToolStripMenuItem1
            // 
            this.buildToolStripMenuItem1.Name = "buildToolStripMenuItem1";
            this.buildToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.buildToolStripMenuItem1.Text = "Build ";
            this.buildToolStripMenuItem1.Click += new System.EventHandler(this.buildToolStripMenuItem1_Click);
            // 
            // runCodeToolStripMenuItem
            // 
            this.runCodeToolStripMenuItem.Name = "runCodeToolStripMenuItem";
            this.runCodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.runCodeToolStripMenuItem.Text = "Run code";
            this.runCodeToolStripMenuItem.Click += new System.EventHandler(this.runCodeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOutputInFullscreenToolStripMenuItem,
            this.showGridlinesToolStripMenuItem,
            this.colorFillDrawingObjectsToolStripMenuItem,
            this.textureFillDrawingObjectsToolStripMenuItem,
            this.clearCanvasToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showOutputInFullscreenToolStripMenuItem
            // 
            this.showOutputInFullscreenToolStripMenuItem.Name = "showOutputInFullscreenToolStripMenuItem";
            this.showOutputInFullscreenToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showOutputInFullscreenToolStripMenuItem.Text = "Show output in fullscreen";
            this.showOutputInFullscreenToolStripMenuItem.Click += new System.EventHandler(this.showOutputInFullscreenToolStripMenuItem_Click);
            // 
            // showGridlinesToolStripMenuItem
            // 
            this.showGridlinesToolStripMenuItem.Name = "showGridlinesToolStripMenuItem";
            this.showGridlinesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showGridlinesToolStripMenuItem.Text = "Show gridlines";
            this.showGridlinesToolStripMenuItem.Click += new System.EventHandler(this.showGridlinesToolStripMenuItem_Click);
            // 
            // colorFillDrawingObjectsToolStripMenuItem
            // 
            this.colorFillDrawingObjectsToolStripMenuItem.Name = "colorFillDrawingObjectsToolStripMenuItem";
            this.colorFillDrawingObjectsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.colorFillDrawingObjectsToolStripMenuItem.Text = "Color fill drawing objects";
            this.colorFillDrawingObjectsToolStripMenuItem.Click += new System.EventHandler(this.colorFillDrawingObjectsToolStripMenuItem_Click);
            // 
            // clearCanvasToolStripMenuItem
            // 
            this.clearCanvasToolStripMenuItem.Name = "clearCanvasToolStripMenuItem";
            this.clearCanvasToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.clearCanvasToolStripMenuItem.Text = "Clear canvas";
            this.clearCanvasToolStripMenuItem.Click += new System.EventHandler(this.clearCanvasToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keywordsAndSyntaxToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // keywordsAndSyntaxToolStripMenuItem
            // 
            this.keywordsAndSyntaxToolStripMenuItem.Name = "keywordsAndSyntaxToolStripMenuItem";
            this.keywordsAndSyntaxToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.keywordsAndSyntaxToolStripMenuItem.Text = "Keywords and syntax";
            this.keywordsAndSyntaxToolStripMenuItem.Click += new System.EventHandler(this.keywordsAndSyntaxToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEditorControl1.Highlighting = null;
            this.textEditorControl1.Location = new System.Drawing.Point(12, 27);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(642, 411);
            this.textEditorControl1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Code,
            this.Description,
            this.Line,
            this.File});
            this.listView1.Location = new System.Drawing.Point(12, 456);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 97);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Code
            // 
            this.Code.Text = "Code";
            this.Code.Width = 104;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 419;
            // 
            // Line
            // 
            this.Line.Text = "Line";
            this.Line.Width = 58;
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 191;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(660, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 411);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(535, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 52);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pieBox);
            this.groupBox1.Controls.Add(this.arcBox);
            this.groupBox1.Controls.Add(this.circleBox);
            this.groupBox1.Controls.Add(this.rectangleBox);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(807, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 103);
            this.groupBox1.TabIndex = 4;
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
            // textureFillDrawingObjectsToolStripMenuItem
            // 
            this.textureFillDrawingObjectsToolStripMenuItem.Name = "textureFillDrawingObjectsToolStripMenuItem";
            this.textureFillDrawingObjectsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.textureFillDrawingObjectsToolStripMenuItem.Text = "Texture fill drawing objects";
            this.textureFillDrawingObjectsToolStripMenuItem.Click += new System.EventHandler(this.textureFillDrawingObjectsToolStripMenuItem_Click);
            // 
            // CodingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1284, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textEditorControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CodingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untitled";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowToolStripMenuItem;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem runCodeToolStripMenuItem;
        private ListView listView1;
        private ColumnHeader Code;
        private ColumnHeader Description;
        private ColumnHeader Line;
        private ColumnHeader File;
        private Panel panel1;
        private Button button1;
        private ComponentResourceManager resources;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem showOutputInFullscreenToolStripMenuItem;
        private ToolStripMenuItem showGridlinesToolStripMenuItem;
        private ToolStripMenuItem saveAsImageToolStripMenuItem;
        private ToolStripMenuItem colorFillDrawingObjectsToolStripMenuItem;
        private ToolStripMenuItem clearCanvasToolStripMenuItem;
        private GroupBox groupBox1;
        private CheckBox circleBox;
        private CheckBox rectangleBox;
        private CheckBox pieBox;
        private CheckBox arcBox;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem keywordsAndSyntaxToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem textureFillDrawingObjectsToolStripMenuItem;
    }
}