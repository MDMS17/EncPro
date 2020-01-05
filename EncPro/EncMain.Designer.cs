namespace EncPro
{
    partial class EncMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Meditrac");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Trading Partner");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Trading Partners", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbRunningStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lbConnectedDatabase = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btLoadData = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btEVRReportBrowse = new System.Windows.Forms.Button();
            this.tbEVRReportFolder = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btLoadTP837s = new System.Windows.Forms.Button();
            this.btTP837sArchiveBrowse = new System.Windows.Forms.Button();
            this.btTP837sSourceBrowse = new System.Windows.Forms.Button();
            this.tbTP837sArchiveFolder = new System.Windows.Forms.TextBox();
            this.tbTP837sSourceFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btExport = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btParseSubmission = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbSubmissionArchiveFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSubmissionSourceFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btLoadResponse = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbResponseArchiveFolder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbResponseSourceFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbResponseFile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbRunningStatus,
            this.toolStripProgressBar1,
            this.lbConnectedDatabase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 758);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1250, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lbRunningStatus
            // 
            this.lbRunningStatus.Name = "lbRunningStatus";
            this.lbRunningStatus.Size = new System.Drawing.Size(86, 22);
            this.lbRunningStatus.Text = "toolStripLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(200, 2, 1, 1);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 22);
            // 
            // lbConnectedDatabase
            // 
            this.lbConnectedDatabase.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbConnectedDatabase.Name = "lbConnectedDatabase";
            this.lbConnectedDatabase.Size = new System.Drawing.Size(86, 22);
            this.lbConnectedDatabase.Text = "toolStripLabel2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1250, 758);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Meditrac";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Trading Partner";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Trading Partners";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(193, 758);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1053, 758);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1045, 732);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Load Meditrac Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btLoadData);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel2.Controls.Add(this.bindingNavigator1);
            this.splitContainer2.Size = new System.Drawing.Size(1039, 726);
            this.splitContainer2.SplitterDistance = 41;
            this.splitContainer2.TabIndex = 0;
            // 
            // btLoadData
            // 
            this.btLoadData.Location = new System.Drawing.Point(559, 4);
            this.btLoadData.Name = "btLoadData";
            this.btLoadData.Size = new System.Drawing.Size(104, 23);
            this.btLoadData.TabIndex = 9;
            this.btLoadData.Text = "Load Data...Go";
            this.btLoadData.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(343, 7);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start Date:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1039, 656);
            this.dataGridView1.TabIndex = 4;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1039, 25);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listBox1);
            this.tabPage5.Controls.Add(this.btEVRReportBrowse);
            this.tabPage5.Controls.Add(this.tbEVRReportFolder);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.btLoadTP837s);
            this.tabPage5.Controls.Add(this.btTP837sArchiveBrowse);
            this.tabPage5.Controls.Add(this.btTP837sSourceBrowse);
            this.tabPage5.Controls.Add(this.tbTP837sArchiveFolder);
            this.tabPage5.Controls.Add(this.tbTP837sSourceFolder);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1045, 732);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Load Trading Partner 837s";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(98, 369);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(793, 290);
            this.listBox1.TabIndex = 10;
            // 
            // btEVRReportBrowse
            // 
            this.btEVRReportBrowse.Location = new System.Drawing.Point(816, 219);
            this.btEVRReportBrowse.Name = "btEVRReportBrowse";
            this.btEVRReportBrowse.Size = new System.Drawing.Size(75, 23);
            this.btEVRReportBrowse.TabIndex = 9;
            this.btEVRReportBrowse.Text = "button3";
            this.btEVRReportBrowse.UseVisualStyleBackColor = true;
            // 
            // tbEVRReportFolder
            // 
            this.tbEVRReportFolder.Location = new System.Drawing.Point(279, 221);
            this.tbEVRReportFolder.Name = "tbEVRReportFolder";
            this.tbEVRReportFolder.Size = new System.Drawing.Size(531, 20);
            this.tbEVRReportFolder.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(95, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "EVR Report Folder:";
            // 
            // btLoadTP837s
            // 
            this.btLoadTP837s.Location = new System.Drawing.Point(98, 293);
            this.btLoadTP837s.Name = "btLoadTP837s";
            this.btLoadTP837s.Size = new System.Drawing.Size(175, 23);
            this.btLoadTP837s.TabIndex = 6;
            this.btLoadTP837s.Text = "Load Trading Partner 837s...Go";
            this.btLoadTP837s.UseVisualStyleBackColor = true;
            // 
            // btTP837sArchiveBrowse
            // 
            this.btTP837sArchiveBrowse.Location = new System.Drawing.Point(816, 151);
            this.btTP837sArchiveBrowse.Name = "btTP837sArchiveBrowse";
            this.btTP837sArchiveBrowse.Size = new System.Drawing.Size(75, 23);
            this.btTP837sArchiveBrowse.TabIndex = 5;
            this.btTP837sArchiveBrowse.Text = "Browse";
            this.btTP837sArchiveBrowse.UseVisualStyleBackColor = true;
            // 
            // btTP837sSourceBrowse
            // 
            this.btTP837sSourceBrowse.Location = new System.Drawing.Point(816, 85);
            this.btTP837sSourceBrowse.Name = "btTP837sSourceBrowse";
            this.btTP837sSourceBrowse.Size = new System.Drawing.Size(75, 23);
            this.btTP837sSourceBrowse.TabIndex = 4;
            this.btTP837sSourceBrowse.Text = "Browse";
            this.btTP837sSourceBrowse.UseVisualStyleBackColor = true;
            // 
            // tbTP837sArchiveFolder
            // 
            this.tbTP837sArchiveFolder.Location = new System.Drawing.Point(279, 153);
            this.tbTP837sArchiveFolder.Name = "tbTP837sArchiveFolder";
            this.tbTP837sArchiveFolder.Size = new System.Drawing.Size(531, 20);
            this.tbTP837sArchiveFolder.TabIndex = 3;
            // 
            // tbTP837sSourceFolder
            // 
            this.tbTP837sSourceFolder.Location = new System.Drawing.Point(279, 87);
            this.tbTP837sSourceFolder.Name = "tbTP837sSourceFolder";
            this.tbTP837sSourceFolder.Size = new System.Drawing.Size(531, 20);
            this.tbTP837sSourceFolder.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(95, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Trading Partner 837s Archive Folder:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(95, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trading Partner 837s Source Folder:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btExport);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1045, 732);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generate 837s";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(566, 123);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(122, 23);
            this.btExport.TabIndex = 14;
            this.btExport.Text = "Generate 837s...Go";
            this.btExport.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Production",
            "Test"});
            this.comboBox2.Location = new System.Drawing.Point(421, 125);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Flag:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Export Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "----------",
            "CCIE810",
            "CCIE812",
            "CCII810",
            "CCII812",
            "CCIP810",
            "CCIP812",
            "CCI_ALL",
            "----------",
            "CMCE",
            "CMCI",
            "CMCP",
            "CMC_ALL",
            "----------",
            "DHCSI305",
            "DHCSI306",
            "DHCSP305",
            "DHCSP306",
            "DHCS_ALL"});
            this.comboBox1.Location = new System.Drawing.Point(247, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Controls.Add(this.btParseSubmission);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.tbSubmissionArchiveFolder);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.tbSubmissionSourceFolder);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1045, 732);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parse Submissions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(92, 282);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(838, 407);
            this.listBox2.TabIndex = 7;
            // 
            // btParseSubmission
            // 
            this.btParseSubmission.Location = new System.Drawing.Point(92, 229);
            this.btParseSubmission.Name = "btParseSubmission";
            this.btParseSubmission.Size = new System.Drawing.Size(223, 23);
            this.btParseSubmission.TabIndex = 6;
            this.btParseSubmission.Text = "Parse Submissions Go...";
            this.btParseSubmission.UseVisualStyleBackColor = true;
            this.btParseSubmission.Click += new System.EventHandler(this.btParseSubmission_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(855, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbSubmissionArchiveFolder
            // 
            this.tbSubmissionArchiveFolder.Location = new System.Drawing.Point(171, 161);
            this.tbSubmissionArchiveFolder.Name = "tbSubmissionArchiveFolder";
            this.tbSubmissionArchiveFolder.Size = new System.Drawing.Size(659, 20);
            this.tbSubmissionArchiveFolder.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Archive Folder:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(855, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbSubmissionSourceFolder
            // 
            this.tbSubmissionSourceFolder.Location = new System.Drawing.Point(171, 99);
            this.tbSubmissionSourceFolder.Name = "tbSubmissionSourceFolder";
            this.tbSubmissionSourceFolder.Size = new System.Drawing.Size(659, 20);
            this.tbSubmissionSourceFolder.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Source Folder:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btLoadResponse);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.tbResponseArchiveFolder);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.tbResponseSourceFolder);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.cbResponseFile);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1045, 732);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Load Reponses";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btLoadResponse
            // 
            this.btLoadResponse.Location = new System.Drawing.Point(98, 258);
            this.btLoadResponse.Name = "btLoadResponse";
            this.btLoadResponse.Size = new System.Drawing.Size(238, 23);
            this.btLoadResponse.TabIndex = 8;
            this.btLoadResponse.Text = "Load Response Files To Database...Go";
            this.btLoadResponse.UseVisualStyleBackColor = true;
            this.btLoadResponse.Click += new System.EventHandler(this.btLoadResponse_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(894, 206);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Browse";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(894, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tbResponseArchiveFolder
            // 
            this.tbResponseArchiveFolder.Location = new System.Drawing.Point(205, 208);
            this.tbResponseArchiveFolder.Name = "tbResponseArchiveFolder";
            this.tbResponseArchiveFolder.Size = new System.Drawing.Size(672, 20);
            this.tbResponseArchiveFolder.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Archive Folder:";
            // 
            // tbResponseSourceFolder
            // 
            this.tbResponseSourceFolder.Location = new System.Drawing.Point(205, 165);
            this.tbResponseSourceFolder.Name = "tbResponseSourceFolder";
            this.tbResponseSourceFolder.Size = new System.Drawing.Size(672, 20);
            this.tbResponseSourceFolder.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Source Folder:";
            // 
            // cbResponseFile
            // 
            this.cbResponseFile.FormattingEnabled = true;
            this.cbResponseFile.Items.AddRange(new object[] {
            "CMS 999",
            "CMS 277CA",
            "CMS MAO002",
            "CMS MAO004",
            "DHCS EVR",
            "835",
            "820"});
            this.cbResponseFile.Location = new System.Drawing.Point(205, 124);
            this.cbResponseFile.Name = "cbResponseFile";
            this.cbResponseFile.Size = new System.Drawing.Size(121, 21);
            this.cbResponseFile.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Response File Type:";
            // 
            // EncMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 783);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EncMain";
            this.Text = "Encounter Submission System";
            this.Load += new System.EventHandler(this.EncPro_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lbRunningStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripLabel lbConnectedDatabase;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btLoadData;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btParseSubmission;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbSubmissionArchiveFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSubmissionSourceFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btLoadResponse;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbResponseArchiveFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbResponseSourceFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbResponseFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btLoadTP837s;
        private System.Windows.Forms.Button btTP837sArchiveBrowse;
        private System.Windows.Forms.Button btTP837sSourceBrowse;
        private System.Windows.Forms.TextBox tbTP837sArchiveFolder;
        private System.Windows.Forms.TextBox tbTP837sSourceFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btEVRReportBrowse;
        private System.Windows.Forms.TextBox tbEVRReportFolder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}