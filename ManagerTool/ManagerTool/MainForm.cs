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

        private RobotGenerator _robotGen;
        private BackgroundWorker _bgWorkerRG = new BackgroundWorker();

        public MainForm() {
            InitializeComponent();
            // Robot Generation Background worker
            _bgWorkerRG.DoWork += GenerateRobotPrograms_BackGround;
            _bgWorkerRG.ProgressChanged += BackGround_RobotGenerationProgressUpdate;
            _bgWorkerRG.RunWorkerCompleted += BackGround_RobotGenerationCompleted;
            _bgWorkerRG.WorkerReportsProgress = true;
        }

        private void LoadAppConfigValues() {
            // Robot Generation
            textBox_rgSeed.Text = ConfigurationManager.AppSettings["rgSeed"];
            numericUpDown_rgRobotCount.Value = Convert.ToDecimal(ConfigurationManager.AppSettings["rgRobotCount"]);
            textBox_rgBaseFileName.Text = ConfigurationManager.AppSettings["rgBaseFileName"];
            textBox_rgOutDir.Text = ConfigurationManager.AppSettings["rgOutDir"];
        }

        /// <summary>
        /// Updates the value of a given parameter in the App.config
        /// </summary>
        /// <param name="key">Parameter key/name</param>
        /// <param name="value">New value to assign</param>
        private void SaveAppConfigKeyValue(string key, string value) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadAppConfigValues();
        }

    }
}
