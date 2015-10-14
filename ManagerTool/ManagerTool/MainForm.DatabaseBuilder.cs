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
using System.IO;


namespace ManagerTool {
    public partial class MainForm : Form {

        RobotGenerationStorage _workingRobotDatabase;


        #region Background worker job
        private void BackGround_BuildDataBase(object sender, System.ComponentModel.DoWorkEventArgs e) {
            var bgw = sender as BackgroundWorker;
            String dir = checkBox_DbBUseOutputDir.Checked ? textBox_rgOutDir.Text : textBox_DbBRobotDir.Text;

            if (!Directory.Exists(dir)) {
                bgw.CancelAsync();
                e.Cancel = true;
                bgw.ReportProgress(0);
                MessageBox.Show(String.Format("ERROR: '{0}' doen't exist.", dir));
                return;
            }

            var dirFiles= Directory.GetFiles(dir, String.Format("*.{0}", RobotGenerator.FILEEXTENSION));
            _workingRobotDatabase = new RobotGenerationStorage(textBox_DbBName.Text, (uint)numericUpDown_DbBGeneration.Value);
            for (int i = 0; i < dirFiles.Length; i++) {
                //Console.WriteLine(dirFiles[i]);  // DEBUG
                bgw.ReportProgress((i * 100)/dirFiles.Length);
                RobotEntry re = new RobotEntry((uint)i, dirFiles[i]);  // TODO: Que el ID se coja del nombre del fichero ??? Robot.id.rxt ???
                _workingRobotDatabase.Robots.Add(re);
            }

            //Console.WriteLine(Serializers.Serialize(_workingRobotDatabase));  // DEBUG
            bgw.ReportProgress(100);
        }

        /// <summary>
        /// Used to upgrade the progress bar.
        /// </summary>
        private void BackGround_DatabaseBuildProgressUpdate(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            progressBar_DbBBuildProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Called when the background worker ends.
        /// </summary>
        private void BackGround_DatabaseBuildCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            button_DbBBuild.Enabled = true;
            groupBox_DbBParams.Enabled = true;
            if ((e.Cancelled) || (_bgWorkerDbB.CancellationPending)) {
                label_DbBProgressStatus.Text = "Database Build: Cancelled";
                toolStripStatusLabel_DataBase.Image = (Bitmap)GetResourceObject("db_fail");
            } else if (e.Error != null) {
                label_DbBProgressStatus.Text = "Database Build: Error. Thread aborted";
                toolStripStatusLabel_DataBase.Image = (Bitmap)GetResourceObject("db_fail");
            } else {
                label_DbBProgressStatus.Text = "Database Build: Success";
                toolStripStatusLabel_DataBase.Image = (Bitmap)GetResourceObject("db_ok");
                toolStripStatusLabel_DataBase.Text = String.Format("Database: {0}", _workingRobotDatabase.Name);
            }
        }
        #endregion

        #region Parameters GUI & App.config update        
        private void checkBox_DbBUseOutputDir_CheckedChanged(object sender, EventArgs e) {
            var cb = (CheckBox)sender;
            textBox_DbBRobotDir.Enabled = !cb.Checked;
            SaveAppConfigKeyValue("DbBUseOutPutDirChecked", cb.Checked.ToString());
        }

        private void textBox_DbBName_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            SaveAppConfigKeyValue("DbBName", tb.Text);
        }

        private void textBox_DbBRobotDir_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            SaveAppConfigKeyValue("DbBRobotDir", tb.Text);
        }

        private void numericUpDown_DbBGeneration_ValueChanged(object sender, EventArgs e) {
            var nud = (NumericUpDown)sender;
            SaveAppConfigKeyValue("DbBGeneration", nud.Value.ToString());
        }

        private void button_DbBBuild_Click(object sender, EventArgs e) {
            if (!_bgWorkerDbB.IsBusy) {
                ((Button)sender).Enabled = false;
                groupBox_DbBParams.Enabled = false;
                toolStripStatusLabel_DataBase.Image = (Bitmap)GetResourceObject("db_search");
                _bgWorkerDbB.RunWorkerAsync();
            }
        }
        #endregion

        // TODO: Moverme de aquí !!!!!!!!!!!!
        private Object GetResourceObject(string resource_name) {
            var res = new System.Resources.ResourceManager("ManagerTool.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            return res.GetObject(resource_name);
        }
    }
}