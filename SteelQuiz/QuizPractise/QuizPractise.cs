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
    public partial class QuizPractise : AutoThemeableForm
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
        private Card __currentCard;
        /// <summary>
        /// The current Card that is being shown.
        /// </summary>
        private Card CurrentCard
        {
            get
            {
                return __currentCard;
            }

            set
            {
                __currentCard = value;

                if (value != null)
                {
                    lbl_cardSideToAsk.Text = value.GetSideToAsk(Quiz);
                    if (PractiseMode == QuizPractiseMode.Writing)
                    {
                        lbl_cardSideToAnswer.Text = "Enter your answer ...";
                    }
                    else
                    {
                        lbl_cardSideToAnswer.Text = "Click here to reveal";
                    }
                    cardSideAnswerPromptBeingShown = true;
                }

                lbl_progress.Text =
                    $"Round Progress: {Quiz.Cards.Where(x => x.GetProgressData(Quiz).AskedThisRound).Count()} " +
                    $"/ {Quiz.GetTotalCurrentCardsCount()}";

                lbl_learningProgress.Text = $"Learning Progress: {Math.Floor(Quiz.ProgressData.GetLearningProgress() * 100)} %";
            }
        }
        private string __currentInput = "";
        /// <summary>
        /// The current user input, when answering by text.
        /// </summary>
        private string CurrentInput
        {
            get
            {
                return __currentInput;
            }

            set
            {
                __currentInput = value;

                if (CurrentCard == null)
                {
                    return;
                }

                if (!IsCurrentCardMultiAnswer())
                {
                    lbl_cardSideToAnswer.Text = value;
                }
                else if (multiAnswerControl != null)
                {
                    multiAnswerControl.CurrentLabel.Text = value;
                }
            }
        }

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
        /// <summary>
        /// True if 'Enter your answer ...' or 'Click here to reveal' prompts are being shown in lbl_cardSideToAnswer
        /// </summary>
        private bool cardSideAnswerPromptBeingShown = true;

        /// <summary>
        /// True if SteelQuiz should exit when clicking the Close button; false if we should return to Dashboard
        /// </summary>
        public bool exitAppOnClose = true;

        private MultiAnswer multiAnswerControl => lbl_cardSideToAnswer.Controls.OfType<MultiAnswer>().FirstOrDefault();

        public QuizPractise(Quiz quiz, QuizPractiseMode quizPractiseMode)
        {
            InitializeComponent();

            Quiz = quiz;
            PractiseMode = quizPractiseMode;

            WindowState = Program.frmDashboard.WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                Size = Program.frmDashboard.Size;
            }
            Location = new Point(Program.frmDashboard.Location.X + (Program.frmDashboard.Size.Width / 2) - (this.Size.Width / 2),
                Program.frmDashboard.Location.Y + (Program.frmDashboard.Size.Height / 2) - (this.Size.Height / 2));

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

            if ((CurrentCard = CardPicker.GenerateCard(Quiz)) == null)
            {
                // Initiate new round if it hasn't previously been done - for instance if this quiz has never been practised before by the user.
                CardPicker.NewRound(Quiz);
            }

            SetCard();
        }

        public override void SetTheme(GeneralTheme theme)
        {
            base.SetTheme(theme);

            lbl_intelligentLearning.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_progress.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_learningProgress.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_cardQuestionSideType.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();
            lbl_cardAnswerSideType.ForeColor = GeneralTheme.GetBackgroundLabelForeColor();

            btn_knewAnswerYES.BackColor = Color.Green;
            btn_knewAnswerNO.BackColor = Color.Maroon;

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_white_with_bigger_border_512x512;
                llb_overrideIwasRight.LinkColor = Color.Aqua;
            }
            else
            {
                btn_cfg.BackgroundImage = Properties.Resources.gear_1077563_black_with_bigger_border_512x512;
                llb_overrideIwasRight.LinkColor = Color.FromArgb(0, 0, 255);
            }
        }

        /// <summary>
        /// Finds if multiple answers are required to be provided to this card.
        /// </summary>
        /// <returns>True if multiple answers must be provided; otherwise False.</returns>
        private bool IsCurrentCardMultiAnswer()
        {
            return CurrentCard.GetRequiredAnswerCards(Quiz).Count() > 1;
        }

        /// <summary>
        /// Generates a card to be shown - or shows the last one from the previous session if it hadn't been answered.
        /// </summary>
        public void SetCard()
        {
            newRoundPending = false;
            newCardPending = false;
            userCopyingAnswer = false;

            foreach (var c in lbl_cardSideToAsk.Controls.OfType<CorrectAnswer>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }
            foreach (var c in lbl_cardSideToAsk.Controls.OfType<WrongAnswer>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }
            foreach (var c in lbl_cardSideToAsk.Controls.OfType<RoundCompleted>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }
            foreach (var c in lbl_cardSideToAnswer.Controls.OfType<MultiAnswer>())
            {
                lbl_cardSideToAnswer.Controls.Remove(c);
                c.Dispose();
            }

            llb_overrideIwasRight.Visible = false;
            pnl_knewAnswer.Visible = false;

            CurrentInput = "";

            CurrentCard = CardPicker.GenerateCard(Quiz);
            if (CurrentCard == null)
            {
                // Round completed

                var roundCompleted = new RoundCompleted(Quiz, PractiseMode, this);
                lbl_cardSideToAsk.Controls.Add(roundCompleted);
                roundCompleted.Show();
                CardPicker.NewRound(Quiz);
                lbl_cardSideToAnswer.Text = "";
                newRoundPending = true;

                return;
            }

            if (PractiseMode == QuizPractiseMode.Writing)
            {
                if (!IsCurrentCardMultiAnswer())
                {
                    lbl_cardSideToAnswer.Text = "Enter your answer ...";
                }
                else
                {
                    // Multi Answer Card
                    var multiAns = new MultiAnswer();
                    lbl_cardSideToAnswer.Text = "";
                    foreach (var card in CurrentCard.MultiAnswersAlreadyEntered(Quiz))
                    {
                        multiAns.CurrentLabel.Text = card.GetSideToAnswer(Quiz);
                        multiAns.CurrentLabel.Clone();
                    }
                    multiAns.CurrentLabel.Text = "Enter your answers ...";
                    lbl_cardSideToAnswer.Controls.Add(multiAns);
                }
            }
            else
            {
                lbl_cardSideToAnswer.Text = "Click here to reveal";
            }
            cardSideAnswerPromptBeingShown = true;


            if (Quiz.ProgressData.GetLearningProgress() == 1.0)
            {
                if (!Quiz.ProgressData.MasterNoticeShowed)
                {
                    MessageBox.Show("Congratulations! It seems you have learned the whole quiz! Practise until you feel confident - then start a full test, through the " +
                        "quiz config menu, by clicking the gear button in the bottom right corner", "Quiz Mastered!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Quiz.ProgressData.MasterNoticeShowed = true;
                }
            }
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
                if (!newCardPending && !newRoundPending && CurrentInput.Length > 0)
                {
                    CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);
                }
            }
            else if (e.KeyChar == '\r')
            {
                // ENTER

                e.Handled = true;

                foreach (var c in lbl_cardSideToAsk.Controls.OfType<CorrectAnswer>())
                {
                    lbl_cardSideToAsk.Controls.Remove(c);
                    c.Dispose();
                }
                foreach (var c in lbl_cardSideToAsk.Controls.OfType<WrongAnswer>())
                {
                    lbl_cardSideToAsk.Controls.Remove(c);
                    c.Dispose();
                }
                foreach (var c in lbl_cardSideToAsk.Controls.OfType<RoundCompleted>())
                {
                    lbl_cardSideToAsk.Controls.Remove(c);
                    c.Dispose();
                }

                if (newRoundPending)
                {
                    SetCard();

                    return;
                }
                
                if (newCardPending)
                {
                    SetCard();

                    return;
                }

                // Check answer
                var chk = CurrentCard.WrittenAnswerCheck(Quiz, CurrentInput, CurrentCard.MultiAnswersAlreadyEntered(Quiz), !userCopyingAnswer);
                if (chk.IsCorrect())
                {
                    newCardPending = true;
                    llb_overrideIwasRight.Visible = false;
                    var correctAnswer = new CorrectAnswer(CurrentCard, Quiz, chk.Certainty);
                    lbl_cardSideToAsk.Controls.Add(correctAnswer);
                    correctAnswer.Show();

                    CurrentCard = CardPicker.GenerateCard(Quiz); // Generate new card now so that it will be shown on next instance if the user stops practising now
                    lbl_cardSideToAnswer.Text = CurrentInput;
                }
                else
                {
                    llb_overrideIwasRight.Visible = true;
                    userCopyingAnswer = true;
                    var wrongAnswer = new WrongAnswer(CurrentCard, Quiz);
                    lbl_cardSideToAsk.Controls.Add(wrongAnswer);
                    wrongAnswer.Show();

                    // Check if the user answered another card
                    var answeredCards = new List<Card>();
                    foreach (var card in Quiz.Cards)
                    {
                        var testCheck = card.WrittenAnswerCheck(Quiz, CurrentInput, null, false, false);
                        if (testCheck.IsCorrect())
                        {
                            answeredCards.Add(card);
                        }
                    }

                    if (answeredCards.Count > 0)
                    {
                        MessageBox.Show($"Your answer is wrong to the current card, but correct to other(s):\r\n\r\n" +
                            string.Join("\r\n", answeredCards.Select(x => x.GetSideToAsk(Quiz))),
                            "You answered other card(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    CurrentInput = "";
                }
            }
            else if (!newCardPending && !newRoundPending)
            {
                if (cardSideAnswerPromptBeingShown)
                {
                    lbl_cardSideToAnswer.Text = "";
                    cardSideAnswerPromptBeingShown = false;
                }

                CurrentInput += e.KeyChar;
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            exitAppOnClose = false;
            Close();
            Program.frmDashboard.UpdateQuizOverview(); // Update learning progress etc
            Program.frmDashboard.Show();
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

        private void InQuiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuizCore.SaveQuizProgress(Quiz);
            if (exitAppOnClose)
            {
                Application.Exit();
            }
        }

        private void lbl_cardSideToAnswer_Click(object sender, EventArgs e)
        {
            if (PractiseMode != QuizPractiseMode.Flashcards)
            {
                return;
            }

            if (newRoundPending)
            {
                return;
            }

            foreach (var c in lbl_cardSideToAsk.Controls.OfType<CorrectAnswer>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }
            foreach (var c in lbl_cardSideToAsk.Controls.OfType<WrongAnswer>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }
            foreach (var c in lbl_cardSideToAsk.Controls.OfType<RoundCompleted>())
            {
                lbl_cardSideToAsk.Controls.Remove(c);
                c.Dispose();
            }

            if (newCardPending)
            {
                SetCard();

                return;
            }

            //lbl_cardSideToAnswer.Text = CurrentCard.GetSideToAnswer(Quiz);
            lbl_cardSideToAnswer.Text = CurrentCard.GetAllAnswers(Quiz);
            pnl_knewAnswer.Visible = true;
        }

        private void btn_knewAnswerYES_Click(object sender, EventArgs e)
        {
            //CurrentCard.AddSuccessfulAttempt(Quiz, CurrentCard, true);
            foreach (var card in CurrentCard.GetRequiredAnswerCards(Quiz))
            {
                card.AddSuccessfulAttempt(Quiz, true);
            }
            SetCard();
        }

        private void btn_knewAnswerNO_Click(object sender, EventArgs e)
        {
            //CurrentCard.AddFailedAttempt(Quiz, CurrentCard, true, false);
            foreach (var card in CurrentCard.GetRequiredAnswerCards(Quiz))
            {
                card.AddFailedAttempt(Quiz, true, false);
            }
            SetCard();
        }

        private void btn_cfg_Click(object sender, EventArgs e)
        {
            var quizPractiseConfigFrm = new QuizPractiseConfig(Quiz);
            quizPractiseConfigFrm.ShowDialog();

            lbl_cardSideToAnswer.Focus();
        }

        public void UpdateCardSideTypeLabels()
        {
            lbl_cardQuestionSideType.Text = Quiz.ProgressData.AnswerCardSide == CardSide.Front ? Quiz.CardBackType : Quiz.CardFrontType;
            lbl_cardAnswerSideType.Text = Quiz.ProgressData.AnswerCardSide == CardSide.Front ? Quiz.CardFrontType : Quiz.CardBackType;
        }

        private void llb_overrideIwasRight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!userCopyingAnswer)
            {
                return;
            }

            foreach (var card in CurrentCard.GetRequiredAnswerCards(Quiz))
            {
                var answerAttempts = card.GetProgressData(Quiz).AnswerAttempts;
                answerAttempts.RemoveAt(answerAttempts.Count - 1);  // Remove last answer attempt
#warning Success attempt is not added to the end of the list, but one index before ?
                card.AddSuccessfulAttempt(Quiz, true);
            }
            SetCard();

            lbl_cardSideToAnswer.Focus();  // Needed for KeyPress() event to be triggered when it should
        }
    }
}