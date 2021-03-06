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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizData;
using System.IO;
using SteelQuiz.QuizProgressData;
using System.Diagnostics;
using SteelQuiz.Animations;

namespace SteelQuiz
{
    public partial class QuizOverview : AutoThemeableUserControl
    {
        private WelcomeTheme WelcomeTheme { get; set; } = new WelcomeTheme();
        public Quiz Quiz { get; set; }

        private bool __practiseQuizButtonsExpanded = false;
        private bool PractiseQuizButtonsExpanded
        {
            get
            {
                return __practiseQuizButtonsExpanded;
            }

            set
            {
                __practiseQuizButtonsExpanded = value;

                var btn_practiseWriting_loc = btn_practiseWriting.Location;
                var btn_practiseFlashcards_loc = btn_practiseFlashcards.Location;

                if (PractiseQuizButtonsExpanded)
                {
                    btn_practiseWriting.Location = btn_practiseQuiz.Location;
                    btn_practiseFlashcards.Location = btn_practiseQuiz.Location;

                    btn_practiseWriting.Visible = true;
                    btn_practiseFlashcards.Visible = true;

                    ControlMove.SmoothMove(btn_practiseWriting, btn_practiseWriting_loc, 80);
                    ControlMove.SmoothMove(btn_practiseFlashcards, btn_practiseFlashcards_loc, 80);
                }
                else
                {
                    ControlMove.SmoothMove(btn_practiseWriting, btn_practiseQuiz.Location, 80, () =>
                    {
                        btn_practiseWriting.Visible = false;

                        btn_practiseWriting.Location = btn_practiseWriting_loc;
                    });
                    ControlMove.SmoothMove(btn_practiseFlashcards, btn_practiseQuiz.Location, 80, () =>
                    {
                        btn_practiseFlashcards.Visible = false;

                        btn_practiseFlashcards.Location = btn_practiseFlashcards_loc;
                    });
                }

                if (PractiseQuizButtonsExpanded)
                {
                    btn_practiseQuiz.Text = "←";
                }
                else
                {
                    btn_practiseQuiz.Text = "Practise Quiz";
                }
            }
        }

        public QuizOverview(Quiz quiz)
        {
            InitializeComponent();

            Quiz = quiz;
            UpdateQuizNameLabel();

            SetTheme(WelcomeTheme);
            UpdateLearningProgress(false);

            switch (Quiz.ProgressData.CardsDisplayOrder)
            {
                case CardsOrderBy.SuccessRate:
                    cmb_order.SelectedItem = "Success Rate";
                    break;

                case CardsOrderBy.QuizOrder:
                    cmb_order.SelectedItem = "Quiz Order";
                    break;

                case CardsOrderBy.AlphabeticalTerm1:
                    cmb_order.SelectedItem = "Alphabetical Front";
                    break;

                case CardsOrderBy.AlphabeticalTerm2:
                    cmb_order.SelectedItem = "Alphabetical Back";
                    break;
            }

            switch (Quiz.ProgressData.CardsDisplayOrderOrder)
            {
                case CardsOrderByOrder.Ascending:
                    cmb_orderAscendingDescending.SelectedItem = "Ascending";
                    break;

                case CardsOrderByOrder.Descending:
                    cmb_orderAscendingDescending.SelectedItem = "Descending";
                    break;
            }

            LoadCards();

            cmb_order.SelectedIndexChanged += Cmb_order_SelectedIndexChanged;
            cmb_orderAscendingDescending.SelectedIndexChanged += Cmb_order_SelectedIndexChanged;

            lbl_termsCount.Text = Quiz.Cards.Count().ToString();
        }

        /// <summary>
        /// Updates the displayed learning progress for the Quiz and the Cards.
        /// </summary>
        /// <param name="reloadCards">True if the cards should be reloaded - which is needed if the learning progress value is changed.</param>
        public void UpdateLearningProgress(bool reloadCards)
        {
            lbl_learningProgress.Text = Math.Floor(Quiz.ProgressData.GetLearningProgress() * 100D).ToString() + " %";
            lbl_learningProgress_bar.Size = new Size((int)Math.Floor(Size.Width * Quiz.ProgressData.GetLearningProgress()), lbl_learningProgress_bar.Size.Height);

            if (reloadCards)
            {
                LoadCards();
            }
            else
            {
                foreach (var c in flp_words.Controls.OfType<DashboardQuizCard>())
                {
                    c.UpdateLearningProgress();
                }
            }
        }

        public void UpdateQuizNameLabel()
        {
            lbl_quizNameHere.Text = Path.GetFileNameWithoutExtension(Quiz.QuizIdentity.FindQuizPath());
        }

        /// <summary>
        /// Re-colors the cards in the list, to have every other Card in a different color, to make reading easier
        /// </summary>
        public void RecolorCards()
        {
            int count = 0;
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                // Every other Card should have a slighly different color to make reading them easier
                var bc = WelcomeTheme.GetBackColor();
                if (count % 2 == 0)
                {
                    c.BackColor = Color.FromArgb(bc.A, bc.R - 5, bc.G - 5, bc.B - 5);
                }
                else
                {
                    c.BackColor = bc;
                }

                ++count;
            }
        }

        public void LoadCards()
        {
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                c.Dispose();
            }

            flp_words.Controls.Clear();

            var controls = new List<DashboardQuizCard>();
            foreach (var card in Quiz.Cards)
            {
                var c = new DashboardQuizCard(Quiz, card);
                c.Size = new Size(flp_words.Size.Width - 34, c.Size.Height);
                controls.Add(c);
            }

            switch (cmb_orderAscendingDescending.SelectedItem)
            {
                case "Ascending":
                    switch (cmb_order.SelectedItem)
                    {
                        case "Success Rate":
                            controls = controls.OrderBy(x => x.SuccessRate).ToList();
                            break;
                        case "Quiz Order":
                            break;
                        case "Alphabetical Front":
                            controls = controls.OrderBy(x => x.Card.Front).ToList();
                            break;
                        case "Alphabetical Back":
                            controls = controls.OrderBy(x => x.Card.Back).ToList();
                            break;
                    }
                    break;

                case "Descending":
                    switch (cmb_order.SelectedItem)
                    {
                        case "Success Rate":
                            controls = controls.OrderByDescending(x => x.SuccessRate).ToList();
                            break;
                        case "Quiz Order":
                            controls.Reverse();
                            break;
                        case "Alphabetical Front":
                            controls = controls.OrderByDescending(x => x.Card.Front).ToList();
                            break;
                        case "Alphabetical Back":
                            controls = controls.OrderByDescending(x => x.Card.Back).ToList();
                            break;
                    }
                    break;
            }

            int count = 0;
            foreach (var c in controls)
            {
                // Every other Card should have a slighly different color to make reading them easier
                var bc = WelcomeTheme.GetBackColor();
                if (count % 2 == 0)
                {
                    c.BackColor = Color.FromArgb(bc.A, bc.R - 5, bc.G - 5, bc.B - 5);
                }
                else
                {
                    c.BackColor = bc;
                }
                flp_words.Controls.Add(c);
                flp_words.SetFlowBreak(c, true);

                ++count;
            }
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null || theme.GetType() != typeof(WelcomeTheme))
            {
                theme = new WelcomeTheme();
            }

            var lbl_learningProgress_bar_color = lbl_learningProgress_bar.ForeColor;

            base.SetTheme(theme);

            lbl_learningProgress_bar.ForeColor = lbl_learningProgress_bar_color;

            RecolorCards();
        }

        private void Btn_practiseQuiz_Click(object sender, EventArgs e)
        {
            PractiseQuizButtonsExpanded = !PractiseQuizButtonsExpanded;
        }

        private void QuizProgressInfo_SizeChanged(object sender, EventArgs e)
        {
            flp_words.Size = new Size(Size.Width - 12, Size.Height - 157);
            foreach (var c in flp_words.Controls.OfType<Control>())
            {
                c.Size = new Size(flp_words.Size.Width - 34, c.Size.Height);
            }

            UpdateLearningProgress(false);
        }

        private void Btn_editQuiz_Click(object sender, EventArgs e)
        {
            Program.frmDashboard.OpenQuizEditor(Quiz, Quiz.QuizIdentity.FindQuizPath());
        }

        private void Lbl_learningProgress_bar_SizeChanged(object sender, EventArgs e)
        {
            double progress = Quiz.ProgressData.GetLearningProgress();

            lbl_learningProgress_bar.ForeColor = Color.FromArgb(
                255,
                (int)Math.Floor(255 - progress * 255),
                (int)Math.Floor(progress * 255),
                0);
        }

        private void Btn_more_Click(object sender, EventArgs e)
        {
            var cm = new ContextMenu();
            cm.MenuItems.Add("Export", (a, b) =>
            {
                var quizExport = new QuizExport(Quiz);
                quizExport.ShowDialog();
            });

            //cm.Show(btn_more, new Point(0, btn_more.Size.Height));
        }

        private void Cmb_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_order.SelectedItem)
            {
                case "Success Rate":
                    Quiz.ProgressData.CardsDisplayOrder = CardsOrderBy.SuccessRate;
                    break;

                case "Quiz Order":
                    Quiz.ProgressData.CardsDisplayOrder = CardsOrderBy.QuizOrder;
                    break;

                case "Alphabetical Front":
                    Quiz.ProgressData.CardsDisplayOrder = CardsOrderBy.AlphabeticalTerm1;
                    break;

                case "Alphabetical Back":
                    Quiz.ProgressData.CardsDisplayOrder = CardsOrderBy.AlphabeticalTerm2;
                    break;
            }

            switch (cmb_orderAscendingDescending.SelectedItem)
            {
                case "Ascending":
                    Quiz.ProgressData.CardsDisplayOrderOrder = CardsOrderByOrder.Ascending;
                    break;

                case "Descending":
                    Quiz.ProgressData.CardsDisplayOrderOrder = CardsOrderByOrder.Descending;
                    break;
            }

            QuizCore.SaveQuizProgress(Quiz);

            LoadCards();
        }

        private void btn_practiseWriting_Click(object sender, EventArgs e)
        {
            PractiseQuizButtonsExpanded = false;

            if (Quiz.Cards.Count == 0)
            {
                MessageBox.Show("Cannot practise quiz with no terms", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            (ParentForm as Dashboard).PractiseQuiz(Quiz, Dashboard.QuizPractiseMode.Writing);
        }

        private void btn_practiseFlashcards_Click(object sender, EventArgs e)
        {
            PractiseQuizButtonsExpanded = false;

            if (Quiz.Cards.Count == 0)
            {
                MessageBox.Show("Cannot practise quiz with no terms", "SteelQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            (ParentForm as Dashboard).PractiseQuiz(Quiz, Dashboard.QuizPractiseMode.Flashcards);
        }
    }
}
