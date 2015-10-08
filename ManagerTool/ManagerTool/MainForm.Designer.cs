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
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_rgSeed = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_rgParameters = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_rgParameters = new System.Windows.Forms.GroupBox();
            this.label_rgRobotNumber = new System.Windows.Forms.Label();
            this.label_rgBaseFileName = new System.Windows.Forms.Label();
            this.label_rgOutDir = new System.Windows.Forms.Label();
            this.textBox_rgSeed = new System.Windows.Forms.TextBox();
            this.textBox_rgBaseFileName = new System.Windows.Forms.TextBox();
            this.textBox_rgOutDir = new System.Windows.Forms.TextBox();
            this.numericUpDown_rgRobotCount = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel_rgLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.button_rgStart = new System.Windows.Forms.Button();
            this.progressBar_rgGenerate = new System.Windows.Forms.ProgressBar();
            this.panel_BASE.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel_rgParameters.SuspendLayout();
            this.groupBox_rgParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgRobotCount)).BeginInit();
            this.flowLayoutPanel_rgLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_BASE
            // 
            this.panel_BASE.Controls.Add(this.tabControl_Main);
            this.panel_BASE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BASE.Location = new System.Drawing.Point(0, 0);
            this.panel_BASE.Name = "panel_BASE";
            this.panel_BASE.Size = new System.Drawing.Size(1018, 583);
            this.panel_BASE.TabIndex = 0;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage1);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Controls.Add(this.tabPage3);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1018, 583);
            this.tabControl_Main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel_rgLeft);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1010, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Robot Generation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_rgSeed
            // 
            this.label_rgSeed.AutoSize = true;
            this.label_rgSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgSeed.Location = new System.Drawing.Point(3, 0);
            this.label_rgSeed.Name = "label_rgSeed";
            this.label_rgSeed.Size = new System.Drawing.Size(82, 26);
            this.label_rgSeed.TabIndex = 0;
            this.label_rgSeed.Text = "Seed";
            this.label_rgSeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1010, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Battle Manager";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1010, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Genetics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_rgParameters
            // 
            this.tableLayoutPanel_rgParameters.ColumnCount = 2;
            this.tableLayoutPanel_rgParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.58333F));
            this.tableLayoutPanel_rgParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.41667F));
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
            this.tableLayoutPanel_rgParameters.Name = "tableLayoutPanel_rgParameters";
            this.tableLayoutPanel_rgParameters.RowCount = 4;
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_rgParameters.Size = new System.Drawing.Size(358, 104);
            this.tableLayoutPanel_rgParameters.TabIndex = 1;
            // 
            // groupBox_rgParameters
            // 
            this.groupBox_rgParameters.Controls.Add(this.tableLayoutPanel_rgParameters);
            this.groupBox_rgParameters.Location = new System.Drawing.Point(3, 3);
            this.groupBox_rgParameters.Name = "groupBox_rgParameters";
            this.groupBox_rgParameters.Size = new System.Drawing.Size(364, 129);
            this.groupBox_rgParameters.TabIndex = 2;
            this.groupBox_rgParameters.TabStop = false;
            this.groupBox_rgParameters.Text = "Parameters";
            // 
            // label_rgRobotNumber
            // 
            this.label_rgRobotNumber.AutoSize = true;
            this.label_rgRobotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_rgRobotNumber.Location = new System.Drawing.Point(3, 26);
            this.label_rgRobotNumber.Name = "label_rgRobotNumber";
            this.label_rgRobotNumber.Size = new System.Drawing.Size(82, 26);
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
            this.label_rgBaseFileName.Size = new System.Drawing.Size(82, 26);
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
            this.label_rgOutDir.Size = new System.Drawing.Size(82, 26);
            this.label_rgOutDir.TabIndex = 3;
            this.label_rgOutDir.Text = "Output directory";
            this.label_rgOutDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_rgSeed
            // 
            this.textBox_rgSeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgSeed.Location = new System.Drawing.Point(91, 3);
            this.textBox_rgSeed.Name = "textBox_rgSeed";
            this.textBox_rgSeed.Size = new System.Drawing.Size(264, 20);
            this.textBox_rgSeed.TabIndex = 4;
            this.textBox_rgSeed.TextChanged += new System.EventHandler(this.textBox_rgSeed_TextChanged);
            // 
            // textBox_rgBaseFileName
            // 
            this.textBox_rgBaseFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgBaseFileName.Location = new System.Drawing.Point(91, 55);
            this.textBox_rgBaseFileName.Name = "textBox_rgBaseFileName";
            this.textBox_rgBaseFileName.Size = new System.Drawing.Size(264, 20);
            this.textBox_rgBaseFileName.TabIndex = 6;
            this.textBox_rgBaseFileName.TextChanged += new System.EventHandler(this.textBox_rgBaseFileName_TextChanged);
            // 
            // textBox_rgOutDir
            // 
            this.textBox_rgOutDir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_rgOutDir.Location = new System.Drawing.Point(91, 81);
            this.textBox_rgOutDir.Name = "textBox_rgOutDir";
            this.textBox_rgOutDir.Size = new System.Drawing.Size(264, 20);
            this.textBox_rgOutDir.TabIndex = 7;
            this.textBox_rgOutDir.TextChanged += new System.EventHandler(this.textBox_rgOutDir_TextChanged);
            // 
            // numericUpDown_rgRobotCount
            // 
            this.numericUpDown_rgRobotCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numericUpDown_rgRobotCount.Location = new System.Drawing.Point(91, 29);
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
            this.numericUpDown_rgRobotCount.Size = new System.Drawing.Size(264, 20);
            this.numericUpDown_rgRobotCount.TabIndex = 8;
            this.numericUpDown_rgRobotCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_rgRobotCount.ValueChanged += new System.EventHandler(this.numericUpDown_rgRobotCount_ValueChanged);
            // 
            // flowLayoutPanel_rgLeft
            // 
            this.flowLayoutPanel_rgLeft.Controls.Add(this.groupBox_rgParameters);
            this.flowLayoutPanel_rgLeft.Controls.Add(this.button_rgStart);
            this.flowLayoutPanel_rgLeft.Controls.Add(this.progressBar_rgGenerate);
            this.flowLayoutPanel_rgLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel_rgLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_rgLeft.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_rgLeft.Name = "flowLayoutPanel_rgLeft";
            this.flowLayoutPanel_rgLeft.Size = new System.Drawing.Size(373, 551);
            this.flowLayoutPanel_rgLeft.TabIndex = 3;
            // 
            // button_rgStart
            // 
            this.button_rgStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_rgStart.Location = new System.Drawing.Point(292, 138);
            this.button_rgStart.Name = "button_rgStart";
            this.button_rgStart.Size = new System.Drawing.Size(75, 40);
            this.button_rgStart.TabIndex = 3;
            this.button_rgStart.Text = "Generate";
            this.button_rgStart.UseVisualStyleBackColor = true;
            this.button_rgStart.Click += new System.EventHandler(this.button_rgStart_Click);
            // 
            // progressBar_rgGenerate
            // 
            this.progressBar_rgGenerate.Location = new System.Drawing.Point(3, 184);
            this.progressBar_rgGenerate.Name = "progressBar_rgGenerate";
            this.progressBar_rgGenerate.Size = new System.Drawing.Size(364, 35);
            this.progressBar_rgGenerate.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 583);
            this.Controls.Add(this.panel_BASE);
            this.Name = "MainForm";
            this.Text = "EisenRobots Manager [ERM]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_BASE.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel_rgParameters.ResumeLayout(false);
            this.tableLayoutPanel_rgParameters.PerformLayout();
            this.groupBox_rgParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgRobotCount)).EndInit();
            this.flowLayoutPanel_rgLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_BASE;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_rgLeft;
        private System.Windows.Forms.Button button_rgStart;
        private System.Windows.Forms.ProgressBar progressBar_rgGenerate;
    }
}

