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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace SteelQuiz
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            this.Text += $" | v{Application.ProductVersion}";
            SetControlStates();

            if (SUtil.InternetConnectionAvailable())
            {
                try
                {
                    if (SUtil.IsDirectoryWritable(Path.GetDirectoryName(Application.ExecutablePath)))
                    {
                        // if application has write permissions to application folder, admin is not required
                        AutoUpdater.RunUpdateAsAdmin = false;
                    }
                    AutoUpdater.Start("https://raw.githubusercontent.com/steel9/SteelQuiz/master/Updater/update_meta.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during the update/update check:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SetControlStates()
        {
            if (ConfigManager.Config.LastQuiz != Guid.Empty)
            {
                btn_continueLast.Enabled = true;
            }
        }

        private void btn_importQuizFromSite_Click(object sender, EventArgs e)
        {
            var import = new ImportQuizFromSite();
            if (import.ShowDialog() == DialogResult.OK)
            {
                Program.frmInQuiz = new InQuiz();
                Program.frmInQuiz.Show();
                Hide();
            }
        }

        private void btn_loadQuiz_Click(object sender, EventArgs e)
        {
            ofd_loadQuiz.InitialDirectory = QuizCore.QUIZ_FOLDER;
            if (ofd_loadQuiz.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var load = QuizCore.Load(ofd_loadQuiz.FileName);
                    if (!load)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The quiz file could not be loaded:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Program.frmInQuiz = new InQuiz();
                Program.frmInQuiz.Show();
                Hide();
            }
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigManager.SaveConfig();
            Application.Exit();
        }

        private void btn_continueLast_Click(object sender, EventArgs e)
        {
            try
            {
                var load = QuizCore.Load(ConfigManager.Config.LastQuiz);
                if (!load)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The quiz file could not be loaded:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.frmInQuiz = new InQuiz();
            Program.frmInQuiz.Show();
            Hide();
        }

        private void btn_createQuiz_Click(object sender, EventArgs e)
        {
            var quizEditor = new QuizEditor();
            quizEditor.Show();
        }
    }
}
