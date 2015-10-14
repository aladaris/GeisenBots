using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;


namespace ManagerTool {
    public partial class MainForm : Form {

        private BackgroundWorker _bgWorkerRG = new BackgroundWorker();  /// Background worker used in the Robot Generation proccess
        private BackgroundWorker _bgWorkerDbB = new BackgroundWorker();  /// Background worker used in the Database Building proccess

        public MainForm() {
            InitializeComponent();
            toolStripStatusLabel_DataBase.Image = Properties.Resources.db_fail;  // NOTE: This hould be inside "InitializeComponent()", but the designer crashes ... "global::ManagerTool.Properties.Resources.db_fail"
            // Background worker Robot Generation
            _bgWorkerRG.DoWork += BackGround_GenerateRobotPrograms;
            _bgWorkerRG.ProgressChanged += BackGround_RobotGenerationProgressUpdate;
            _bgWorkerRG.RunWorkerCompleted += BackGround_RobotGenerationCompleted;
            _bgWorkerRG.WorkerReportsProgress = true;
            // Background worker DataBase Building
            _bgWorkerDbB.DoWork += BackGround_BuildDataBase;
            _bgWorkerDbB.ProgressChanged += BackGround_DatabaseBuildProgressUpdate;
            _bgWorkerDbB.RunWorkerCompleted += BackGround_DatabaseBuildCompleted;
            _bgWorkerDbB.WorkerReportsProgress = true;
            _bgWorkerDbB.WorkerSupportsCancellation = true;
        }

        private void LoadAppConfigValues() {
            // Robot Generation
            textBox_rgSeed.Text = ConfigurationManager.AppSettings["rgSeed"];
            numericUpDown_rgRobotCount.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["rgRobotCount"]);
            textBox_rgBaseFileName.Text = ConfigurationManager.AppSettings["rgBaseFileName"];
            textBox_rgOutDir.Text = ConfigurationManager.AppSettings["rgOutDir"];
            // Database Builder
            textBox_DbBName.Text = ConfigurationManager.AppSettings["DbBName"];
            numericUpDown_DbBGeneration.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["DbBGeneration"]);
            textBox_DbBRobotDir.Text = ConfigurationManager.AppSettings["DbBRobotDir"];
            checkBox_DbBUseOutputDir.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["DbBUseOutPutDirChecked"]);

        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadAppConfigValues();
        }
    }
}
