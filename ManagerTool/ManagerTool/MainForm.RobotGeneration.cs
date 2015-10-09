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

        private RobotGenerator _robotGen;

        #region Background worker job
		/// <summary>
		/// A Background worker 'DoWork' function.
        /// This method handles the generation of the robot program strings
        /// as individual output files (one per robot).
		/// </summary>
        private void GenerateRobotPrograms_BackGround(object sender, System.ComponentModel.DoWorkEventArgs e) {
			// Robot count handling
            int count = (int)numericUpDown_rgRobotCount.Value;
            if (count <= 0)
                return;
			// Seed handling
            if (textBox_rgSeed.Text.Length == 0) {
                _robotGen = new RobotGenerator();
            } else {
                int seed = Convert.ToInt32(textBox_rgSeed.Text);
                _robotGen = new RobotGenerator(seed);
            }
			// Base FileName handling
            string baseFileName = textBox_rgBaseFileName.Text;
            if (baseFileName == String.Empty)
                return;
            baseFileName = baseFileName + ".{0}." + RobotGenerator.FILEEXTENSION;
			// Output directory handling
            string outDir = textBox_rgOutDir.Text;
            if (outDir == String.Empty) {
                outDir = ".";
            }
			if (!Directory.Exists(outDir)){
                Directory.CreateDirectory(outDir);
			}

			// Do the work (Generate strings and save them to files
            var bgw = sender as BackgroundWorker;
            string baseFullPath = outDir + Path.DirectorySeparatorChar + baseFileName;
            for (int i = 0; i < count; i++) {
                string robotProgram = _robotGen.RandomRobotProgram();
                File.WriteAllText(String.Format(baseFullPath, i), robotProgram);
                bgw.ReportProgress((i * 100) / count);
            }
            bgw.ReportProgress(100);
        }

		/// <summary>
		/// Used to upgrade the progress bar.
		/// </summary>
        private void BackGround_RobotGenerationProgressUpdate(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            progressBar_rgGenerate.Value = e.ProgressPercentage;
        }

		/// <summary>
		/// Called when the background worker ends.
		/// </summary>
        private void BackGround_RobotGenerationCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            button_rgStart.Enabled = true;
            groupBox_rgParameters.Enabled = true;
            if (e.Cancelled) {
                label_rgProgressStatus.Text = "Robot Creation: Cancelled";
            } else if (e.Error != null) {
                label_rgProgressStatus.Text = "Robot Creation: Error. Thread aborted";
            } else {
                label_rgProgressStatus.Text = "Robot Creation: Success";
            }
        }
        #endregion

        #region Parameters GUI & App.config update
        /// <summary>
        /// Handles the seed input textbox to only accept/display numbers.
        /// </summary>
        private void textBox_rgSeed_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            tb.Text = Regex.Replace(tb.Text, @"[^0-9]", String.Empty);
            SaveAppConfigKeyValue("rgSeed", tb.Text);
            // Set the cursor back to the front of the string
            tb.SelectionStart = tb.Text.Length;
            tb.SelectionLength = 0;
        }

        private void numericUpDown_rgRobotCount_ValueChanged(object sender, EventArgs e) {
            var nud = (NumericUpDown)sender;
            SaveAppConfigKeyValue("rgRobotCount", nud.Value.ToString());
        }
        private void textBox_rgBaseFileName_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            SaveAppConfigKeyValue("rgBaseFileName", tb.Text);
        }
        private void textBox_rgOutDir_TextChanged(object sender, EventArgs e) {
            var tb = (TextBox)sender;
            SaveAppConfigKeyValue("rgOutDir", tb.Text);
        }
        /// <summary>
        /// Start the robot generation proccess (CLICK)
        /// </summary>
        private void button_rgStart_Click(object sender, EventArgs e) {
            //GenerateRobotPrograms((int)numericUpDown_rgRobotCount.Value, Convert.ToInt32(textBox_rgSeed.Text));
            if (!_bgWorkerRG.IsBusy) {
                ((Button)sender).Enabled = false;
                groupBox_rgParameters.Enabled = false;
                _bgWorkerRG.RunWorkerAsync();
            }
        }
        #endregion
    }
}