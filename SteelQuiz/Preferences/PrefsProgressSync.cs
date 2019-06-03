﻿/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SteelQuiz.Preferences
{
    public partial class PrefsProgressSync : AutoThemeableUserControl, IPreferenceCategory, ICustomSaveCategory
    {
        public PrefsProgressSync()
        {
            InitializeComponent();
            LoadPreferences();
            SetTheme();
        }

        private void Btn_browseQuizProgPath_Click(object sender, EventArgs e)
        {
            fbd_quizProgFolder.SelectedPath = Path.GetDirectoryName(ConfigManager.Config.SyncConfig.QuizProgressPath);
            if (fbd_quizProgFolder.ShowDialog() == DialogResult.OK)
            {
                txt_quizProgPath.Text = Path.Combine(fbd_quizProgFolder.SelectedPath, "SteelQuizProgress.json");
                Save(true);
            }
        }

        public void LoadPreferences()
        {
            txt_quizProgPath.Text = ConfigManager.Config.SyncConfig.QuizProgressPath;
        }

        public bool Save(bool saveConfig)
        {
            var oldPath = ConfigManager.Config.SyncConfig.QuizProgressPath;
            var newPath = txt_quizProgPath.Text;

            if (newPath == oldPath)
            {
                return true;
            }

            if (!Directory.Exists(Path.GetDirectoryName(newPath)))
            {
                MessageBox.Show("Selected directory to store quiz progress data in does not exist", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool bkp = QuizCore.BackupProgress(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION));
            if (!bkp)
            {
                return false;
            }

            if (File.Exists(newPath))
            {
                var msg = MessageBox.Show("A quiz progress data file already exists in the selected folder. Overwrite?\r\n\r\nWarning: Overwriting may cause data loss." +
                    " If you are unsure, select a different folder, or move the quiz progress data file currently existing in the folder", "SteelQuiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msg == DialogResult.No)
                {
                    return false;
                }
                File.Delete(newPath);
            }

            File.Move(oldPath, newPath);
            ConfigManager.Config.SyncConfig.QuizProgressPath = newPath;

            return true;
        }
    }
}
