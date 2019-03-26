﻿/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  steel9apps

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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SteelQuiz.QuizData;

namespace SteelQuiz
{
    public static class QuizCompatibilityConverter
    {
        /*
         * Returns quiz if quiz doesn't need to be converted, or if it was converted successfully. Otherwise it returns null
         */
        public static Quiz ChkUpgradeQuiz(dynamic quiz)
        {
            Quiz newQuiz = null;

            Version fromVer;

            var V2 = new Version(1, 1, 0); // changed wordpair synonyms default value from null to new List<string>(), renamed QuizFileFormatVersion to FileFormatVersion

            var fileFormatVersionDefined = SUtil.PropertyDefined(quiz.FileFormatVersion);
            if (fileFormatVersionDefined)
            {
                fromVer = new Version(quiz.FileFormatVersion);
            }
            else
            {
                fromVer = new Version(1, 0, 0);
            }

            if (fromVer.CompareTo(new Version(MetaData.QUIZ_FILE_FORMAT_VERSION)) < 0)
            {
                //conversion required

                var msg = MessageBox.Show("The quiz file you have selected was made for an older version of SteelQuiz and must be converted to "
                    + "the current format to load it. A backup will be created automatically, meaning that you won't lose anything when converting.\r\n\r\n"
                    + "Warning! The quiz will probably be incompatible with older versions of SteelQuiz after the conversion. To use the quiz with "
                    + "older versions of SteelQuiz after the conversion, you must use the backup quiz, which is created automatically."
                    + "\r\n\r\nProceed with conversion?", "Quiz conversion required - SteelQuiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                {
                    return null;
                }

                var bkp = BackupQuiz(fromVer);
                if (!bkp)
                {
                    return null;
                }
            }
            else
            {
                return quiz;
            }

            if (V2.CompareTo(fromVer) > 0)
            {
                // initialize synonyms (ver x --> 1.0.1)
                // synonyms in v1.0.0 were string arrays initialized to null
                // should now be string lists initialized to new List<string>()
                // QuizFileFormatVersion is renamed to FileFormatVersion

                newQuiz = new Quiz(quiz.Language1, quiz.Language2,
                    fileFormatVersionDefined ? quiz.FileFormatVersion : quiz.QuizFileFormatVersion,
                    quiz.GUID);
                newQuiz.WordPairs = quiz.WordPairs.Clone();

                foreach (var wp in newQuiz.WordPairs)
                {
                    if (wp.Word1Synonyms == null)
                    {
                        wp.Word1Synonyms = new List<string>();
                    }

                    if (wp.Word2Synonyms == null)
                    {
                        wp.Word2Synonyms = new List<string>();
                    }
                }
            }

            if (newQuiz != null)
            {
                newQuiz.FileFormatVersion = MetaData.QUIZ_FILE_FORMAT_VERSION;
            }
            return newQuiz;
        }

        public static bool BackupQuiz(Version quizVer)
        {
            var extStartIndex = QuizCore.QuizPath.Length - QuizCore.QUIZ_EXTENSION.Length;
            var bkpQuizPath = Path.Combine(
                QuizCore.QUIZ_BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(QuizCore.QuizPath) + "_" + quizVer.ToString() + QuizCore.QUIZ_EXTENSION);
            var exCount = 1;
            while (File.Exists(bkpQuizPath))
            {
                ++exCount;
                //newQuizPath = QuizPath.Insert(extStartIndex, "_" + quizVer.ToString() + "_" + exCount);
                bkpQuizPath = Path.Combine(
                    QuizCore.QUIZ_BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(QuizCore.QuizPath) + "_" + quizVer.ToString() + "_" + exCount + QuizCore.QUIZ_EXTENSION);
            }

            try
            {
                File.Copy(QuizCore.QuizPath, bkpQuizPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the quiz, the conversion will not run:\r\n\r\n" + ex.ToString(), "SteelQuiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool BackupProgress(Version progressVer)
        {
            var extStartIndex = QuizCore.PROGRESS_FILE_PATH.Length - ".json".Length;
            var bkpProgressPath = Path.Combine(
                QuizCore.BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(QuizCore.PROGRESS_FILE_PATH) + "_" + progressVer.ToString() + ".json");
            var exCount = 1;
            while (File.Exists(bkpProgressPath))
            {
                ++exCount;
                bkpProgressPath = Path.Combine(
                    QuizCore.BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(QuizCore.PROGRESS_FILE_PATH) + "_" + progressVer.ToString() + "_" + exCount + ".json");
            }

            try
            {
                File.Copy(QuizCore.PROGRESS_FILE_PATH, bkpProgressPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the quiz progress, the conversion will not run:\r\n\r\n" + ex.ToString(),
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool BackupConfig(Version cfgVer)
        {
            var extStartIndex = ConfigManager.CONFIG_PATH.Length - ".json".Length;
            var bkpCfgPath = Path.Combine(
                QuizCore.BACKUP_FOLDER,
                Path.GetFileNameWithoutExtension(ConfigManager.CONFIG_PATH) + "_" + cfgVer.ToString() + ".json");
            var exCount = 1;
            while (File.Exists(bkpCfgPath))
            {
                ++exCount;
                bkpCfgPath = Path.Combine(
                    QuizCore.BACKUP_FOLDER,
                    Path.GetFileNameWithoutExtension(ConfigManager.CONFIG_PATH) + "_" + cfgVer.ToString() + "_" + exCount + ".json");
            }

            try
            {
                File.Copy(ConfigManager.CONFIG_PATH, bkpCfgPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while backing up the configuration file, the conversion will not run:\r\n\r\n" + ex.ToString(),
                    "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}