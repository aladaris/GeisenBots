namespace ManagerTool {
    partial class MainForm {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.panel_BASE = new System.Windows.Forms.Panel();
            this.splitContainer_Base = new System.Windows.Forms.SplitContainer();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_robotManagement = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_Main3Cols = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_RobotGeneration = new System.Windows.Forms.TableLayoutPanel();
            this.label_rgProgressStatus = new System.Windows.Forms.Label();
            this.progressBar_rgGenerate = new System.Windows.Forms.ProgressBar();
            this.button_rgStart = new System.Windows.Forms.Button();
            this.groupBox_rgParameters = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_rgParameters = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_rgOutDir = new System.Windows.Forms.TextBox();
            this.textBox_rgBaseFileName = new System.Windows.Forms.TextBox();
            this.label_rgSeed = new System.Windows.Forms.Label();
            this.label_rgRobotNumber = new System.Windows.Forms.Label();
            this.label_rgBaseFileName = new System.Windows.Forms.Label();
            this.label_rgOutDir = new System.Windows.Forms.Label();
            this.textBox_rgSeed = new System.Windows.Forms.TextBox();
            this.numericUpDown_rgRobotCount = new System.Windows.Forms.NumericUpDown();
            this.label_rgTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel_DataBaseGeneration = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_DbBParams = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_DbBRobotDir = new System.Windows.Forms.TextBox();
            this.label_DbBName = new System.Windows.Forms.Label();
            this.label_DbBGeneration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DbBName = new System.Windows.Forms.TextBox();
            this.numericUpDown_DbBGeneration = new System.Windows.Forms.NumericUpDown();
            this.checkBox_DbBUseOutputDir = new System.Windows.Forms.CheckBox();
            this.label_DbBSaveAs = new System.Windows.Forms.Label();
            this.textBox_DbBSaveAs = new System.Windows.Forms.TextBox();
            this.button_DbBBuild = new System.Windows.Forms.Button();
            this.progressBar_DbBBuildProgress = new System.Windows.Forms.ProgressBar();
            this.label_DbBProgressStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_DataBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_BASE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Base)).BeginInit();
            this.splitContainer_Base.Panel1.SuspendLayout();
            this.splitContainer_Base.Panel2.SuspendLayout();
            this.splitContainer_Base.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_robotManagement.SuspendLayout();
            this.tableLayoutPanel_Main3Cols.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel_RobotGeneration.SuspendLayout();
            this.groupBox_rgParameters.SuspendLayout();
            this.tableLayoutPanel_rgParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgRobotCount)).BeginInit();
            this.tableLayoutPanel_DataBaseGeneration.SuspendLayout();
            this.groupBox_DbBParams.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DbBGeneration)).BeginInit();
            this.statusStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_BASE
            // 
            this.panel_BASE.Controls.Add(this.splitContainer_Base);
            this.panel_BASE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BASE.Location = new System.Drawing.Point(0, 0);
            this.panel_BASE.Name = "panel_BASE";
            this.panel_BASE.Size = new System.Drawing.Size(984, 611);
            this.panel_BASE.TabIndex = 0;
            // 
            // splitContainer_Base
            // 
            this.splitContainer_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Base.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_Base.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Base.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_Base.Name = "splitContainer_Base";
            this.splitContainer_Base.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Base.Panel1
            // 
            this.splitContainer_Base.Panel1.Controls.Add(this.tabControl_Main);
            // 
            // splitContainer_Base.Panel2
            // 
            this.splitContainer_Base.Panel2.Controls.Add(this.statusStrip_Main);
            this.splitContainer_Base.Panel2MinSize = 20;
            this.splitContainer_Base.Size = new System.Drawing.Size(984, 611);
            this.splitContainer_Base.SplitterDistance = 585;
            this.splitContainer_Base.SplitterWidth = 1;
            this.splitContainer_Base.TabIndex = 1;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_robotManagement);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Controls.Add(this.tabPage3);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(984, 585);
            this.tabControl_Main.TabIndex = 0;
            // 
            // tabPage_robotManagement
            // 
            this.tabPage_robotManagement.Controls.Add(this.tableLayoutPanel_Main3Cols);
            this.tabPage_robotManagement.Location = new System.Drawing.Point(4, 22);
            this.tabPage_robotManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_robotManagement.Name = "tabPage_robotManagement";
            this.tabPage_robotManagement.Size = new System.Drawing.Size(976, 559);
            this.tabPage_robotManagement.TabIndex = 0;
            this.tabPage_robotManagement.Text = "Robot Management";
            // 
            // tableLayoutPanel_Main3Cols
            // 
            this.tableLayoutPanel_Main3Cols.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_Main3Cols.ColumnCount = 3;
            this.tableLayoutPanel_Main3Cols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main3Cols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main3Cols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_Main3Cols.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tableLayoutPanel_Main3Cols.Controls.Add(this.tableLayoutPanel_RobotGeneration, 0, 0);
            this.tableLayoutPanel_Main3Cols.Controls.Add(this.tableLayoutPanel_DataBaseGeneration, 1, 0);
            this.tableLayoutPanel_Main3Cols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Main3Cols.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Main3Cols.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Main3Cols.Name = "tableLayoutPanel_Main3Cols";
            this.tableLayoutPanel_Main3Cols.RowCount = 1;
            this.tableLayoutPanel_Main3Cols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Main3Cols.Size = new System.Drawing.Size(976, 559);
            this.tableLayoutPanel_Main3Cols.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(651, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(324, 557);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "Database Explorer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_RobotGeneration
            // 
            this.tableLayoutPanel_RobotGeneration.ColumnCount = 1;
            this.tableLayoutPanel_RobotGeneration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RobotGeneration.Controls.Add(this.label_rgProgressStatus, 0, 4);
            this.tableLayoutPanel_RobotGeneration.Controls.Add(this.progressBar_rgGenerate, 0, 3);
            this.tableLayoutPanel_RobotGeneration.Controls.Add(this.button_rgStart, 0, 2);
            this.tableLayoutPanel_RobotGeneration.Controls.Add(this.groupBox_rgParameters, 0, 1);
            this.tableLayoutPanel_RobotGeneration.Controls.Add(this.label_rgTitle, 0, 0);
            this.tableLayoutPanel_RobotGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_RobotGeneration.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel_RobotGeneration.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_RobotGeneration.Name = "tableLayoutPanel_RobotGeneration";
            this.tableLayoutPanel_RobotGeneration.RowCount = 6;
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_RobotGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_RobotGeneration.Size = new System.Drawing.Size(324, 557);
            this.tableLayoutPanel_RobotGeneration.TabIndex = 0;
            // 
            // label_rgProgressStatus
            // 
            this.label_rgProgressStatus.AutoSize = true;
            this.label_rgProgressStatus.Location = new System.Drawing.Point(3, 275);
            this.label_rgProgressStatus.Name = "label_rgProgressStatus";
            this.label_rgProgressStatus.Size = new System.Drawing.Size(0, 13);
            this.label_rgProgressStatus.TabIndex = 5;
            // 
            // progressBar_rgGenerate
            // 
            this.progressBar_rgGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_rgGenerate.Location = new System.Drawing.Point(3, 233);
            this.progressBar_rgGenerate.Name = "progressBar_rgGenerate";
            this.progressBar_rgGenerate.Size = new System.Drawing.Size(318, 39);
            this.progressBar_rgGenerate.TabIndex = 4;
            // 
            // button_rgStart
            // 
            this.button_rgStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_rgStart.Location = new System.Drawing.Point(3, 188);
            this.button_rgStart.Name = "button_rgStart";
            this.button_rgStart.Size = new System.Drawing.Size(318, 39);
            this.button_rgStart.TabIndex = 3;
            this.button_rgStart.Text = "Create";
            this.button_rgStart.UseVisualStyleBackColor = true;
            this.button_rgStart.Click += new System.EventHandler(this.button_rgStart_Click);
            // 
            // groupBox_rgParameters
            // 
            this.groupBox_rgParameters.Controls.Add(this.tableLayoutPanel_rgParameters);
            this.groupBox_rgParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_rgParameters.Location = new System.Drawing.Point(3, 38);
            this.groupBox_rgParameters.Name = "groupBox_rgParameters";
            this.groupBox_rgParameters.Size = new System.Drawing.Size(318, 144);
            this.groupBox_rgParameters.TabIndex = 2;
            this.groupBox_rgParameters.TabStop = false;
            this.groupBox_rgParameters.Text = "Parameters";
            // 
            // tableLayoutPanel_rgParameters
            // 
            this.tableLayoutPanel_rgParameters.ColumnCount = 2;
            this.tableLayoutPanel_rgParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel_rgParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_rgParameters.Controls.Add(this.textBox_rgOutDir, 1, 3);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.textBox_rgBaseFileName, 1, 2);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.label_rgSeed, 0, 0);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.label_rgRobotNumber, 0, 1);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.label_rgBaseFileName, 0, 2);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.label_rgOutDir, 0, 3);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.textBox_rgSeed, 1, 0);
            this.tableLayoutPanel_rgParameters.Controls.Add(this.numericUpDown_rgRobotCount, 1, 1);
            this.tableLayoutPanel_rgParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel_rgParameters.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel_rgParameters.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_rgParameters.Name = "tableLayoutPanel_rgParameters";
            this.tableLayoutPanel_rgParameters.RowCount = 4;
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.Size = new System.Drawing.Size(312, 104);
            this.tableLayoutPanel_rgParameters.TabIndex = 1;
            // 
            // textBox_rgOutDir
            // 
            this.textBox_rgOutDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgOutDir.Location = new System.Drawing.Point(62, 81);
            this.textBox_rgOutDir.Name = "textBox_rgOutDir";
            this.textBox_rgOutDir.Size = new System.Drawing.Size(247, 20);
            this.textBox_rgOutDir.TabIndex = 7;
            this.textBox_rgOutDir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_rgOutDir_MouseClick);
            this.textBox_rgOutDir.TextChanged += new System.EventHandler(this.textBox_rgOutDir_TextChanged);
            // 
            // textBox_rgBaseFileName
            // 
            this.textBox_rgBaseFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgBaseFileName.Location = new System.Drawing.Point(62, 55);
            this.textBox_rgBaseFileName.Name = "textBox_rgBaseFileName";
            this.textBox_rgBaseFileName.Size = new System.Drawing.Size(247, 20);
            this.textBox_rgBaseFileName.TabIndex = 6;
            this.textBox_rgBaseFileName.TextChanged += new System.EventHandler(this.textBox_rgBaseFileName_TextChanged);
            // 
            // label_rgSeed
            // 
            this.label_rgSeed.AutoSize = true;
            this.label_rgSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgSeed.Location = new System.Drawing.Point(3, 0);
            this.label_rgSeed.Name = "label_rgSeed";
            this.label_rgSeed.Size = new System.Drawing.Size(53, 26);
            this.label_rgSeed.TabIndex = 0;
            this.label_rgSeed.Text = "Seed";
            this.label_rgSeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_rgRobotNumber
            // 
            this.label_rgRobotNumber.AutoSize = true;
            this.label_rgRobotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgRobotNumber.Location = new System.Drawing.Point(3, 26);
            this.label_rgRobotNumber.Name = "label_rgRobotNumber";
            this.label_rgRobotNumber.Size = new System.Drawing.Size(53, 26);
            this.label_rgRobotNumber.TabIndex = 1;
            this.label_rgRobotNumber.Text = "# Robots";
            this.label_rgRobotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_rgBaseFileName
            // 
            this.label_rgBaseFileName.AutoSize = true;
            this.label_rgBaseFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgBaseFileName.Location = new System.Drawing.Point(3, 52);
            this.label_rgBaseFileName.Name = "label_rgBaseFileName";
            this.label_rgBaseFileName.Size = new System.Drawing.Size(53, 26);
            this.label_rgBaseFileName.TabIndex = 2;
            this.label_rgBaseFileName.Text = "Base filename";
            this.label_rgBaseFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_rgOutDir
            // 
            this.label_rgOutDir.AutoSize = true;
            this.label_rgOutDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgOutDir.Location = new System.Drawing.Point(3, 78);
            this.label_rgOutDir.Name = "label_rgOutDir";
            this.label_rgOutDir.Size = new System.Drawing.Size(53, 26);
            this.label_rgOutDir.TabIndex = 3;
            this.label_rgOutDir.Text = "Output directory";
            this.label_rgOutDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_rgSeed
            // 
            this.textBox_rgSeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgSeed.Location = new System.Drawing.Point(62, 3);
            this.textBox_rgSeed.Name = "textBox_rgSeed";
            this.textBox_rgSeed.Size = new System.Drawing.Size(247, 20);
            this.textBox_rgSeed.TabIndex = 4;
            this.textBox_rgSeed.TextChanged += new System.EventHandler(this.textBox_rgSeed_TextChanged);
            // 
            // numericUpDown_rgRobotCount
            // 
            this.numericUpDown_rgRobotCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numericUpDown_rgRobotCount.Location = new System.Drawing.Point(62, 29);
            this.numericUpDown_rgRobotCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_rgRobotCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_rgRobotCount.Name = "numericUpDown_rgRobotCount";
            this.numericUpDown_rgRobotCount.Size = new System.Drawing.Size(247, 20);
            this.numericUpDown_rgRobotCount.TabIndex = 8;
            this.numericUpDown_rgRobotCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_rgRobotCount.ValueChanged += new System.EventHandler(this.numericUpDown_rgRobotCount_ValueChanged);
            // 
            // label_rgTitle
            // 
            this.label_rgTitle.AutoSize = true;
            this.label_rgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rgTitle.Location = new System.Drawing.Point(3, 0);
            this.label_rgTitle.Name = "label_rgTitle";
            this.label_rgTitle.Size = new System.Drawing.Size(318, 35);
            this.label_rgTitle.TabIndex = 6;
            this.label_rgTitle.Text = "Robot Creation";
            this.label_rgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_DataBaseGeneration
            // 
            this.tableLayoutPanel_DataBaseGeneration.ColumnCount = 1;
            this.tableLayoutPanel_DataBaseGeneration.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_DataBaseGeneration.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_DataBaseGeneration.Controls.Add(this.groupBox_DbBParams, 0, 1);
            this.tableLayoutPanel_DataBaseGeneration.Controls.Add(this.button_DbBBuild, 0, 2);
            this.tableLayoutPanel_DataBaseGeneration.Controls.Add(this.progressBar_DbBBuildProgress, 0, 3);
            this.tableLayoutPanel_DataBaseGeneration.Controls.Add(this.label_DbBProgressStatus, 0, 4);
            this.tableLayoutPanel_DataBaseGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_DataBaseGeneration.Location = new System.Drawing.Point(326, 1);
            this.tableLayoutPanel_DataBaseGeneration.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_DataBaseGeneration.Name = "tableLayoutPanel_DataBaseGeneration";
            this.tableLayoutPanel_DataBaseGeneration.RowCount = 6;
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_DataBaseGeneration.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_DataBaseGeneration.Size = new System.Drawing.Size(324, 557);
            this.tableLayoutPanel_DataBaseGeneration.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database Builder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_DbBParams
            // 
            this.groupBox_DbBParams.Controls.Add(this.tableLayoutPanel2);
            this.groupBox_DbBParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_DbBParams.Location = new System.Drawing.Point(3, 38);
            this.groupBox_DbBParams.Name = "groupBox_DbBParams";
            this.groupBox_DbBParams.Size = new System.Drawing.Size(318, 144);
            this.groupBox_DbBParams.TabIndex = 8;
            this.groupBox_DbBParams.TabStop = false;
            this.groupBox_DbBParams.Text = "Parameters";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_DbBRobotDir, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label_DbBName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_DbBGeneration, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_DbBName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDown_DbBGeneration, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_DbBUseOutputDir, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label_DbBSaveAs, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox_DbBSaveAs, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(312, 128);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBox_DbBRobotDir
            // 
            this.textBox_DbBRobotDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_DbBRobotDir.Location = new System.Drawing.Point(70, 55);
            this.textBox_DbBRobotDir.Name = "textBox_DbBRobotDir";
            this.textBox_DbBRobotDir.Size = new System.Drawing.Size(239, 20);
            this.textBox_DbBRobotDir.TabIndex = 7;
            this.textBox_DbBRobotDir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DbBRobotDir_MouseClick);
            this.textBox_DbBRobotDir.TextChanged += new System.EventHandler(this.textBox_DbBRobotDir_TextChanged);
            // 
            // label_DbBName
            // 
            this.label_DbBName.AutoSize = true;
            this.label_DbBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DbBName.Location = new System.Drawing.Point(3, 0);
            this.label_DbBName.Name = "label_DbBName";
            this.label_DbBName.Size = new System.Drawing.Size(61, 26);
            this.label_DbBName.TabIndex = 0;
            this.label_DbBName.Text = "Name";
            this.label_DbBName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_DbBGeneration
            // 
            this.label_DbBGeneration.AutoSize = true;
            this.label_DbBGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DbBGeneration.Location = new System.Drawing.Point(3, 26);
            this.label_DbBGeneration.Name = "label_DbBGeneration";
            this.label_DbBGeneration.Size = new System.Drawing.Size(61, 26);
            this.label_DbBGeneration.TabIndex = 1;
            this.label_DbBGeneration.Text = "Generation";
            this.label_DbBGeneration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Robots directory";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_DbBName
            // 
            this.textBox_DbBName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_DbBName.Location = new System.Drawing.Point(70, 3);
            this.textBox_DbBName.Name = "textBox_DbBName";
            this.textBox_DbBName.Size = new System.Drawing.Size(239, 20);
            this.textBox_DbBName.TabIndex = 4;
            this.textBox_DbBName.TextChanged += new System.EventHandler(this.textBox_DbBName_TextChanged);
            // 
            // numericUpDown_DbBGeneration
            // 
            this.numericUpDown_DbBGeneration.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numericUpDown_DbBGeneration.Location = new System.Drawing.Point(70, 29);
            this.numericUpDown_DbBGeneration.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_DbBGeneration.Name = "numericUpDown_DbBGeneration";
            this.numericUpDown_DbBGeneration.Size = new System.Drawing.Size(239, 20);
            this.numericUpDown_DbBGeneration.TabIndex = 8;
            this.numericUpDown_DbBGeneration.ValueChanged += new System.EventHandler(this.numericUpDown_DbBGeneration_ValueChanged);
            // 
            // checkBox_DbBUseOutputDir
            // 
            this.checkBox_DbBUseOutputDir.AutoSize = true;
            this.checkBox_DbBUseOutputDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_DbBUseOutputDir.Location = new System.Drawing.Point(70, 81);
            this.checkBox_DbBUseOutputDir.Name = "checkBox_DbBUseOutputDir";
            this.checkBox_DbBUseOutputDir.Size = new System.Drawing.Size(239, 17);
            this.checkBox_DbBUseOutputDir.TabIndex = 9;
            this.checkBox_DbBUseOutputDir.Text = "Use \"Robot Creation\" output directory";
            this.checkBox_DbBUseOutputDir.UseVisualStyleBackColor = true;
            this.checkBox_DbBUseOutputDir.CheckedChanged += new System.EventHandler(this.checkBox_DbBUseOutputDir_CheckedChanged);
            // 
            // label_DbBSaveAs
            // 
            this.label_DbBSaveAs.AutoSize = true;
            this.label_DbBSaveAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DbBSaveAs.Location = new System.Drawing.Point(3, 101);
            this.label_DbBSaveAs.Name = "label_DbBSaveAs";
            this.label_DbBSaveAs.Size = new System.Drawing.Size(61, 27);
            this.label_DbBSaveAs.TabIndex = 10;
            this.label_DbBSaveAs.Text = "Save as";
            this.label_DbBSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_DbBSaveAs
            // 
            this.textBox_DbBSaveAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DbBSaveAs.Location = new System.Drawing.Point(70, 104);
            this.textBox_DbBSaveAs.Name = "textBox_DbBSaveAs";
            this.textBox_DbBSaveAs.Size = new System.Drawing.Size(239, 20);
            this.textBox_DbBSaveAs.TabIndex = 11;
            this.textBox_DbBSaveAs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_DbBSaveAs_MouseClick);
            this.textBox_DbBSaveAs.TextChanged += new System.EventHandler(this.textBox_DbBSaveAs_TextChanged);
            // 
            // button_DbBBuild
            // 
            this.button_DbBBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_DbBBuild.Location = new System.Drawing.Point(3, 188);
            this.button_DbBBuild.Name = "button_DbBBuild";
            this.button_DbBBuild.Size = new System.Drawing.Size(318, 39);
            this.button_DbBBuild.TabIndex = 9;
            this.button_DbBBuild.Text = "Build";
            this.button_DbBBuild.UseVisualStyleBackColor = true;
            this.button_DbBBuild.Click += new System.EventHandler(this.button_DbBBuild_Click);
            // 
            // progressBar_DbBBuildProgress
            // 
            this.progressBar_DbBBuildProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_DbBBuildProgress.Location = new System.Drawing.Point(3, 233);
            this.progressBar_DbBBuildProgress.Name = "progressBar_DbBBuildProgress";
            this.progressBar_DbBBuildProgress.Size = new System.Drawing.Size(318, 39);
            this.progressBar_DbBBuildProgress.TabIndex = 10;
            // 
            // label_DbBProgressStatus
            // 
            this.label_DbBProgressStatus.AutoSize = true;
            this.label_DbBProgressStatus.Location = new System.Drawing.Point(3, 275);
            this.label_DbBProgressStatus.Name = "label_DbBProgressStatus";
            this.label_DbBProgressStatus.Size = new System.Drawing.Size(0, 13);
            this.label_DbBProgressStatus.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Battle Manager";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 556);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Genetics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip_Main
            // 
            this.statusStrip_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_DataBase});
            this.statusStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Main.Name = "statusStrip_Main";
            this.statusStrip_Main.Size = new System.Drawing.Size(984, 25);
            this.statusStrip_Main.TabIndex = 0;
            this.statusStrip_Main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_DataBase
            // 
            this.toolStripStatusLabel_DataBase.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel_DataBase.Name = "toolStripStatusLabel_DataBase";
            this.toolStripStatusLabel_DataBase.Size = new System.Drawing.Size(104, 25);
            this.toolStripStatusLabel_DataBase.Text = "Database: - none -";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.panel_BASE);
            this.MinimumSize = new System.Drawing.Size(630, 490);
            this.Name = "MainForm";
            this.Text = "EisenRobots Manager [ERM]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_BASE.ResumeLayout(false);
            this.splitContainer_Base.Panel1.ResumeLayout(false);
            this.splitContainer_Base.Panel2.ResumeLayout(false);
            this.splitContainer_Base.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Base)).EndInit();
            this.splitContainer_Base.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_robotManagement.ResumeLayout(false);
            this.tableLayoutPanel_Main3Cols.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel_RobotGeneration.ResumeLayout(false);
            this.tableLayoutPanel_RobotGeneration.PerformLayout();
            this.groupBox_rgParameters.ResumeLayout(false);
            this.tableLayoutPanel_rgParameters.ResumeLayout(false);
            this.tableLayoutPanel_rgParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgRobotCount)).EndInit();
            this.tableLayoutPanel_DataBaseGeneration.ResumeLayout(false);
            this.tableLayoutPanel_DataBaseGeneration.PerformLayout();
            this.groupBox_DbBParams.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DbBGeneration)).EndInit();
            this.statusStrip_Main.ResumeLayout(false);
            this.statusStrip_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_BASE;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_robotManagement;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label_rgSeed;
        private System.Windows.Forms.GroupBox groupBox_rgParameters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_rgParameters;
        private System.Windows.Forms.Label label_rgRobotNumber;
        private System.Windows.Forms.Label label_rgBaseFileName;
        private System.Windows.Forms.Label label_rgOutDir;
        private System.Windows.Forms.TextBox textBox_rgSeed;
        private System.Windows.Forms.TextBox textBox_rgOutDir;
        private System.Windows.Forms.TextBox textBox_rgBaseFileName;
        private System.Windows.Forms.NumericUpDown numericUpDown_rgRobotCount;
        private System.Windows.Forms.Button button_rgStart;
        private System.Windows.Forms.ProgressBar progressBar_rgGenerate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Main3Cols;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RobotGeneration;
        private System.Windows.Forms.Label label_rgProgressStatus;
        private System.Windows.Forms.Label label_rgTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_DataBaseGeneration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_DbBParams;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_DbBRobotDir;
        private System.Windows.Forms.Label label_DbBName;
        private System.Windows.Forms.Label label_DbBGeneration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DbBName;
        private System.Windows.Forms.NumericUpDown numericUpDown_DbBGeneration;
        private System.Windows.Forms.CheckBox checkBox_DbBUseOutputDir;
        private System.Windows.Forms.Button button_DbBBuild;
        private System.Windows.Forms.ProgressBar progressBar_DbBBuildProgress;
        private System.Windows.Forms.Label label_DbBProgressStatus;
        private System.Windows.Forms.SplitContainer splitContainer_Base;
        private System.Windows.Forms.StatusStrip statusStrip_Main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_DataBase;
        private System.Windows.Forms.Label label_DbBSaveAs;
        private System.Windows.Forms.TextBox textBox_DbBSaveAs;
    }
}

