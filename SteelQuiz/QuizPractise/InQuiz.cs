﻿/*
    SteelQuiz - A quiz program designed to make learning easier.
    Copyright (C) 2020  Steel9Apps

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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.Extensions;
using SteelQuiz.QuizData;
using SteelQuiz.QuizProgressData;
using SteelQuiz.ThemeManager.Colors;
using static SteelQuiz.Dashboard;

namespace SteelQuiz.QuizPractise
{
    public partial class InQuiz : AutoThemeableForm
    {
        private GeneralTheme GeneralTheme = new GeneralTheme();

        /// <summary>
        /// The Quiz being practised.
        /// </summary>
        private Quiz Quiz { get; set; }
        /// <summary>
        /// The Practise mode being used.
        /// </summary>
        private QuizPractiseMode PractiseMode { get; set; }
        /// <summary>
        /// The current Card that is being shown.
        /// </summary>
        private Card CurrentCard { get; set; }
        /// <summary>
        /// The current user input, when answering by text.
        /// </summary>
        private string CurrentInput { get; set; } = "";

        /// <summary>
        /// True if round summary (RoundCompleted) user control is being shown, and a new round should start when pressing ENTER.
        /// </summary>
        private bool newRoundPending = false;
        /// <summary>
        /// True if "Correct" or "Wrong" messages is being shown for a Card, and that a new one should be shown when pressing ENTER.
        /// </summary>
        private bool newCardPending = false;
        /// <summary>
        /// True if the user has entered the wrong answer and is currently transcribing the correct one.
        /// </summary>
        private bool userCopyingAnswer = false;

        public InQuiz(Quiz quiz, QuizPractiseMode quizPractiseMode)
        {
            InitializeComponent();

            Quiz = quiz;
            PractiseMode = quizPractiseMode;

            WindowState = Program.frmWelcome.WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Size = Program.frmWelcome.Size;
            }
            Location = new Point(Program.frmWelcome.Location.X + (Program.frmWelcome.Size.Width / 2) - (this.Size.Width / 2),
                Program.frmWelcome.Location.Y + (Program.frmWelcome.Size.Height / 2) - (this.Size.Height / 2));

            lbl_cardQuestionSideType.Text = Quiz.ProgressData.AnswerCardSide == CardSide.Front ? Quiz.CardBackType : Quiz.CardFrontType;
            lbl_cardAnswerSideType.Text = Quiz.ProgressData.AnswerCardSide == CardSide.Front ? Quiz.CardFrontType : Quiz.CardBackType;

            this.Text = $"{Path.GetFileNameWithoutExtension(Quiz.QuizIdentity.FindQuizPath())} - SteelQuiz";
            if (MetaData.PRE_RELEASE)
            {
                this.Text += $" v{Application.ProductVersion} PRE-RELEASE";
            }

            if (Quiz.ProgressData.FullTestInProgress)
            {
                lbl_intelligentLearning.Text = "Intelligent Learning: Disabled";
            }
            else
            {
                lbl_intelligentLearning.Text = "Intelligent Learning: Enabled";
            }

            SetTheme(GeneralTheme);

            SetCard();
        }

        public override void SetTheme(GeneralTheme theme)
        {
            base.SetTheme(theme);

            lbl_intelligentLearning.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_progress.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_cardQuestionSideType.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_cardAnswerSideType.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();

            btn_knewAnswerYES.BackColor = Color.Green;
            btn_knewAnswerNO.BackColor = Color.Maroon;

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_white_with_bigger_border_512x512;
            }
            else
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_black_with_bigger_border_512x512;
            }
        }

        /// <summary>
        /// Generates a card to be shown - or shows the last one from the previous session if it hadn't been answered.
        /// </summary>
        private void SetCard()
        {
            CurrentCard = QuestionSelector.GenerateCard(Quiz);
            if (CurrentCard == null)
            {
                // Round completed

                var roundCompleted = new RoundCompleted(Quiz);
                pnl_cardSideToAsk.Controls.Add(roundCompleted);
                newRoundPending = true;

                return;
            }
            lbl_cardQuestionSideType.Text = CurrentCard.GetSideToAsk(Quiz);
        }

        /// <summary>
        /// Retrieves a collection of answers already entered in a multi-answer question.
        /// </summary>
        /// <returns>Returns the collection</returns>
        private IEnumerable<Card> MultiAnswersAlreadyEntered()
        {
            return CurrentCard.GetRequiredAnswerSynonyms(Quiz).Where(x => x.GetProgressData(Quiz).AskedThisRound);
        }

        private void InQuiz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PractiseMode != QuizPractiseMode.Writing)
            {
                return;
            }

            if (e.KeyChar == '\u001b')
            {
                // ignore ESC
                return;
            }

            if (e.KeyChar == '\b')
            {
                // BACKSPACE
                if (CurrentInput.Length > 0)
                {
                    CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);
                }
            }
            else if (e.KeyChar == '\r')
            {
                e.Handled = true;

                // ENTER
                if (newRoundPending)
                {
                    foreach (var c in pnl_cardSideToAsk.Controls.OfType<RoundCompleted>())
                    {
                        pnl_cardSideToAsk.Controls.Remove(c);
                        c.Dispose();
                    }

                    SetCard();

                    return;
                }
                
                if (newCardPending)
                {
                    SetCard();

                    return;
                }

                // Check answer
                var chk = CurrentCard.AnswerCheck(Quiz, CurrentInput);
                if (chk.IsCorrect())
                {
                    newCardPending = true;
                    var correctAnswer = new CorrectAnswer(CurrentCard, Quiz, chk.Certainty);
                }
                else
                {
                    userCopyingAnswer = true;
                    var wrongAnswer = new WrongAnswer();
                }
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            ReturnToDashboard();
        }

        private void InQuiz_KeyDown(object sender, KeyEventArgs e)
        {
            if (PractiseMode != QuizPractiseMode.Writing)
            {
                return;
            }

            if (e.KeyData.HasFlag(Keys.Oemplus) && e.Shift && e.Alt && e.Control)
            {
                CurrentInput += "¿";
                lbl_cardSideToAnswer.Text = CurrentInput;
            }
            else if (e.KeyData.HasFlag(Keys.D1) && e.Shift && e.Alt && e.Control)
            {
                CurrentInput += "¡";
                lbl_cardSideToAnswer.Text = CurrentInput;
            }
        }
    }
}