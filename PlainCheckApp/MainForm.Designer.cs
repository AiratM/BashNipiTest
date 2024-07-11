namespace PlainCheckApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemOpenFile = new System.Windows.Forms.MenuItem();
            this.menuItemDrawRectangle = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelLog = new System.Windows.Forms.Panel();
            this.groupBoxRectangle = new System.Windows.Forms.GroupBox();
            this.dataGridViewRectangle = new System.Windows.Forms.DataGridView();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDrawRect = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panelLog.SuspendLayout();
            this.groupBoxRectangle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRectangle)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpenFile,
            this.menuItemDrawRectangle,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text = "Файл";
            // 
            // menuItemOpenFile
            // 
            this.menuItemOpenFile.Index = 0;
            this.menuItemOpenFile.Text = "Загрузить данные";
            this.menuItemOpenFile.Click += new System.EventHandler(this.menuItemOpenFile_Click);
            // 
            // menuItemDrawRectangle
            // 
            this.menuItemDrawRectangle.Index = 1;
            this.menuItemDrawRectangle.Text = "Отрисовка прямоугольника";
            this.menuItemDrawRectangle.Click += new System.EventHandler(this.menuItemDrawRectangle_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Выход";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItem5.Text = "Справка";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "О программе";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Файл csv|*.csv";
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.groupBoxRectangle);
            this.panelLog.Controls.Add(this.listBoxLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 631);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(1057, 173);
            this.panelLog.TabIndex = 0;
            // 
            // groupBoxRectangle
            // 
            this.groupBoxRectangle.Controls.Add(this.dataGridViewRectangle);
            this.groupBoxRectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRectangle.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRectangle.Name = "groupBoxRectangle";
            this.groupBoxRectangle.Size = new System.Drawing.Size(572, 173);
            this.groupBoxRectangle.TabIndex = 1;
            this.groupBoxRectangle.TabStop = false;
            this.groupBoxRectangle.Text = "Координаты прямоугольника";
            // 
            // dataGridViewRectangle
            // 
            this.dataGridViewRectangle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRectangle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDescription,
            this.ColumnX,
            this.ColumnY});
            this.dataGridViewRectangle.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewRectangle.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRectangle.Name = "dataGridViewRectangle";
            this.dataGridViewRectangle.Size = new System.Drawing.Size(566, 150);
            this.dataGridViewRectangle.TabIndex = 2;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnY
            // 
            this.ColumnY.HeaderText = "Y";
            this.ColumnY.Name = "ColumnY";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(572, 0);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(485, 173);
            this.listBoxLog.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripButtonDrawRect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1057, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLoad.Text = "Загрузить данные";
            this.toolStripButtonLoad.Click += new System.EventHandler(this.menuItemOpenFile_Click);
            // 
            // toolStripButtonDrawRect
            // 
            this.toolStripButtonDrawRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDrawRect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDrawRect.Image")));
            this.toolStripButtonDrawRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDrawRect.Name = "toolStripButtonDrawRect";
            this.toolStripButtonDrawRect.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDrawRect.Text = "Отрисовать прямоугольник";
            this.toolStripButtonDrawRect.Click += new System.EventHandler(this.menuItemDrawRectangle_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 592);
            this.panel1.TabIndex = 3;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxMain.Location = new System.Drawing.Point(5, 3);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMain.TabIndex = 2;
            this.pictureBoxMain.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 804);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelLog);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Тестовое задание";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelLog.ResumeLayout(false);
            this.groupBoxRectangle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRectangle)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemOpenFile;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBoxRectangle;
        private System.Windows.Forms.DataGridView dataGridViewRectangle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnY;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.MenuItem menuItemDrawRectangle;
        private System.Windows.Forms.ToolStripButton toolStripButtonDrawRect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxMain;
    }
}

