using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
                bgw.ReportProgress((i * 99)/dirFiles.Length);
                RobotEntry re = new RobotEntry((uint)i, dirFiles[i]);  // TODO: Que el ID se coja del nombre del fichero ??? Robot.id.rxt ???
                _workingRobotDatabase.Robots.Add(re);
            }

            //Console.WriteLine(Serializers.Serialize(_workingRobotDatabase));  // DEBUG

            // textBox_DbBSaveAs.Text.IndexOf(@"\", textBox_DbBSaveAs.Text.Length)
            string pattern = @"^(.+){1}\\([^\\]+)$";
            string baseFullPath = Regex.Match(textBox_DbBSaveAs.Text, pattern).Groups[1].Value;
            baseFullPath = Directory.Exists(baseFullPath) ? textBox_DbBSaveAs.Text : textBox_DbBName.Text + '.' + RobotGenerationStorage.FILE_EXTENSION;
            File.WriteAllText(baseFullPath, Serializers.Serialize(_workingRobotDatabase));
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
                toolStripStatusLabel_DataBase.Image = Properties.Resources.db_fail;
            } else if (e.Error != null) {
                label_DbBProgressStatus.Text = "Database Build: Error. Thread aborted";
                toolStripStatusLabel_DataBase.Image = Properties.Resources.db_fail;
            } else {
                label_DbBProgressStatus.Text = "Database Build: Success";
                toolStripStatusLabel_DataBase.Image = Properties.Resources.db_ok;
                toolStripStatusLabel_DataBase.Text = String.Format("Database: {0}", _workingRobotDatabase.Name);
            }
        }
        #endregion

        #region Parameters GUI & App.config update        
        private void checkBox_DbBUseOutputDir_CheckedChanged(object sender, EventArgs e) {
            var cb = (CheckBox)sender;
            textBox_DbBRobotDir.Enabled = !cb.Checked;
            AppConfigUtils.SaveAppConfigKeyValue("DbBUseOutPutDirChecked", cb.Checked.ToString());
        }

        private void textBox_DbBName_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            AppConfigUtils.SaveAppConfigKeyValue("DbBName", tb.Text);
        }

        private void textBox_DbBRobotDir_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            AppConfigUtils.SaveAppConfigKeyValue("DbBRobotDir", tb.Text);
        }

        /// <summary>
        /// Robot Database Generation input RobotDir selection
        /// </summary>
        private void textBox_DbBRobotDir_MouseClick(object sender, MouseEventArgs e) {
            GUIUtils.TextBoxClickFolderBrowserDialog(sender);
        }

        private void numericUpDown_DbBGeneration_ValueChanged(object sender, EventArgs e) {
            var nud = (NumericUpDown)sender;
            AppConfigUtils.SaveAppConfigKeyValue("DbBGeneration", nud.Value.ToString());
        }

        private void textBox_DbBSaveAs_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            AppConfigUtils.SaveAppConfigKeyValue("DbBsaveAs", tb.Text);
        }

        /// <summary>
        /// Robot DataBase Generation output file selection
        /// </summary>
        private void textBox_DbBSaveAs_MouseClick(object sender, MouseEventArgs e) {
            var saveFileDiag = new SaveFileDialog();
            saveFileDiag.Filter = String.Format("Robot Generation Database|*.{0}", RobotGenerationStorage.FILE_EXTENSION);
            saveFileDiag.Title = "Save Robot Generation Database";
            saveFileDiag.FileName = textBox_DbBName.Text;
            saveFileDiag.ShowDialog();
            var tb = (TextBox)sender;
            tb.Text = saveFileDiag.FileName;
        }

        private void button_DbBBuild_Click(object sender, EventArgs e) {
            if (!_bgWorkerDbB.IsBusy) {
                ((Button)sender).Enabled = false;
                groupBox_DbBParams.Enabled = false;
                toolStripStatusLabel_DataBase.Image = Properties.Resources.db_search;
                _bgWorkerDbB.RunWorkerAsync();
            }
        }
        #endregion
    }
}