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
using SteelQuiz.QuizEditor.UndoRedo;
using SteelQuiz.ThemeManager.Colors;
using SteelQuiz.QuizPractise;

namespace SteelQuiz.QuizEditor
{
    public partial class QuizEditorCard : AutoThemeableUserControl
    {
        public int Number { get; set; } // number in flowlayoutpanel, the first one has number 0 for instance
        public Guid Guid { get; set; } = Guid.NewGuid(); // The Guid of the card belonging to this control
        public string Front => txt_front.Text;
        public string Back => txt_back.Text;

        public List<string> FrontSynonyms { get; set; } = new List<string>();
        public List<string> BackSynonyms { get; set; } = new List<string>();

        public Pointer<StringComp.Rules> ComparisonRules { get; set; } = new Pointer<StringComp.Rules>(StringComp.SMART_RULES);

        public EditCardSynonyms EditCardSynonyms { get; set; } = null;

        public QuizEditor QuizEditor { get; set; }

        public bool ignore_txt_cardSide_change = false;
        public bool ignore_chk_smartComp_change = false;

        public QuizEditorCard(QuizEditor owner, int number)
        {
            InitializeComponent();
            QuizEditor = owner;
            Number = number;
            RemoveSynonymsEqualToWords();

            ComparisonRules.BeforeDataChanged += (sender, e) =>
            {
                if (QuizEditor.UpdateUndoRedoStacks)
                {
                    QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                        new Action[] { ComparisonRules.SetSemiSilentUR(ComparisonRules.Data) },
                        new Action[] { ComparisonRules.SetSemiSilentUR(e) },
                        "Change comparison rules",
                        new OwnerControlData(this, this.Parent)
                        ));
                    QuizEditor.UpdateUndoRedoTooltips();
                }

                QuizEditor.ChangedSinceLastSave = true;
            };

            ComparisonRules.AfterDataChanged += (sender, e) =>
            {
                chk_smartComp.CheckStateChanged -= Chk_smartComp_CheckStateChanged;
                if (ComparisonRules.Data.HasFlag(StringComp.SMART_RULES))
                {
                    chk_smartComp.CheckState = CheckState.Checked;
                }
                else if (ComparisonRules.Data == StringComp.Rules.None)
                {
                    chk_smartComp.CheckState = CheckState.Unchecked;
                }
                else
                {
                    chk_smartComp.CheckState = CheckState.Indeterminate;
                }
                chk_smartComp.CheckStateChanged += Chk_smartComp_CheckStateChanged;
                QuizEditor.SetGlobalSmartComparisonState();
            };

            SetTheme();
        }

        public override void SetTheme(GeneralTheme theme = null)
        {
            if (theme == null)
            {
                theme = new GeneralTheme();
            }

            base.SetTheme(theme);

            if (ConfigManager.Config.Theme == ThemeManager.ThemeCore.Theme.Dark)
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_white_with_bigger_border_512x512");
                btn_delete.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("bin_bigger_border_white");
                btn_editSynonymsFront.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("edit_synonyms_bigger_border_white");
                btn_editSynonymsBack.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("edit_synonyms_bigger_border_white");
            }
            else
            {
                btn_smartCompSettings.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("gear_1077563_black_with_bigger_border_512x512");
                btn_delete.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("bin_bigger_border_black");
                btn_editSynonymsFront.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("edit_synonyms_bigger_border_black");
                btn_editSynonymsBack.BackgroundImage = CachedResourceManager.LoadResource<Bitmap>("edit_synonyms_bigger_border_black");
            }

            lbl_ansCompRules.ForeColor = theme.GetBackgroundLabelForeColor();
            chk_smartComp.ForeColor = theme.GetBackgroundLabelForeColor();
        }

        public void InitEditWordSynonyms(int language)
        {
            if (EditCardSynonyms == null)
            {
                EditCardSynonyms = new EditCardSynonyms(this, language == 1 ? txt_front.Text : txt_back.Text, language);
            }
        }

        public void DisposeEditWordSynonyms()
        {
            if (EditCardSynonyms != null)
            {
                EditCardSynonyms.DialogResult = DialogResult.Cancel;
                EditCardSynonyms.Dispose();
                EditCardSynonyms = null;
            }
        }

        private void btn_editSynonymsFront_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(1);
            if (EditCardSynonyms.ShowDialog() == DialogResult.OK)
            {
                FrontSynonyms = EditCardSynonyms.Synonyms;
                QuizEditor.CheckFixEmptyCards();
            }
            DisposeEditWordSynonyms();
        }

        private void btn_editSynonymsBack_Click(object sender, EventArgs e)
        {
            InitEditWordSynonyms(2);
            if (EditCardSynonyms.ShowDialog() == DialogResult.OK)
            {
                BackSynonyms = EditCardSynonyms.Synonyms;
                QuizEditor.CheckFixEmptyCards();
            }
            DisposeEditWordSynonyms();
        }

        private string txt_front_text_old = "";

        private void txt_front_TextChanged(object sender, EventArgs e)
        {
            QuizEditor.CheckFixEmptyCards();

            if (ignore_txt_cardSide_change)
            {
                txt_front_text_old = txt_front.Text;
                ignore_txt_cardSide_change = false;
                return;
            }

            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                    new Action[] { txt_front.ChangeText(txt_front_text_old, () => { ignore_txt_cardSide_change = true; }) },
                    new Action[] { txt_front.ChangeText(txt_front.Text, () => { ignore_txt_cardSide_change = true; }) },
                    "Change text",
                    new OwnerControlData(this, this.Parent)));
                QuizEditor.UpdateUndoRedoTooltips();
            }
            QuizEditor.ChangedSinceLastSave = true;

            txt_front_text_old = txt_front.Text;
        }

        private string txt_back_text_old = "";

        private void txt_back_TextChanged(object sender, EventArgs e)
        {
            QuizEditor.CheckFixEmptyCards();

            if (ignore_txt_cardSide_change)
            {
                txt_back_text_old = txt_back.Text;
                ignore_txt_cardSide_change = false;
                return;
            }

            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                new Action[] { txt_back.ChangeText(txt_back_text_old, () => { ignore_txt_cardSide_change = true; }) },
                new Action[] { txt_back.ChangeText(txt_back.Text, () => { ignore_txt_cardSide_change = true; }) },
                "Change text",
                new OwnerControlData(this, this.Parent)));
                QuizEditor.UpdateUndoRedoTooltips();
            }
            QuizEditor.ChangedSinceLastSave = true;

            txt_back_text_old = txt_back.Text;
        }

        private void txt_cardSide_Click(object sender, EventArgs e)
        {
            QuizEditor.CheckFixEmptyCards();
        }

        private void txt_front_Enter(object sender, EventArgs e)
        {
            QuizEditor.CheckFixEmptyCards();
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (QuizEditor.UpdateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                    new Action[] { QuizEditor.AddCard(this, QuizEditor.flp_cards.Controls.GetChildIndex(this)) },
                    new Action[] { QuizEditor.RemoveCard(this) },
                    "Remove card",
                    new OwnerControlData(this, this.Parent)
                    ));
            }
            QuizEditor.UpdateUndoRedoTooltips();
            QuizEditor.flp_cards.Controls.Remove(this);
            QuizEditor.CheckFixEmptyCards();
            QuizEditor.ChangedSinceLastSave = true;
        }

        public void RemoveSynonymsEqualToWords(int word = -1)
        {
            // check if synonyms contains word entered

            if ((word == -1 || word == 1) && FrontSynonyms != null && FrontSynonyms.Contains(Front))
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                    new Action[] { FrontSynonyms.AddItem(Front) },
                    new Action[] { FrontSynonyms.RemoveItem(Front) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QuizEditor.UpdateUndoRedoTooltips();
                FrontSynonyms.Remove(Front);

                QuizEditor.ShowNotification($"A synonym to '{Front}' has been removed, due to it being equal to the word itself", 0);
            }

            if ((word == -1 || word == 2) && BackSynonyms != null && BackSynonyms.Contains(Back))
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                    new Action[] { BackSynonyms.AddItem(Back) },
                    new Action[] { BackSynonyms.RemoveItem(Back) },
                    "Auto-remove synonym",
                    new OwnerControlData(this, this.Parent)
                    ));
                QuizEditor.UpdateUndoRedoTooltips();
                BackSynonyms.Remove(Back);

                QuizEditor.ShowNotification($"A synonym to '{Back}' has been removed, due to it being equal to the word itself", 0);
            }
        }

        private void Txt_front_Leave(object sender, EventArgs e)
        {
            RemoveSynonymsEqualToWords(1);
        }

        private void Txt_back_Leave(object sender, EventArgs e)
        {
            RemoveSynonymsEqualToWords(2);
        }

        private void Btn_smartCompSettings_Click(object sender, EventArgs e)
        {
            var smartCompSettings = new SmartComparisonSettings(ComparisonRules.Data);
            var result = smartCompSettings.ShowDialog();
            if (result == DialogResult.OK)
            {
                ComparisonRules.Data = smartCompSettings.Rules;
            }
        }

        private void Chk_smartComp_Click(object sender, EventArgs e)
        {
            if (chk_smartComp.CheckState == CheckState.Checked)
            {
                chk_smartComp.CheckState = CheckState.Unchecked;
            }
            else if (chk_smartComp.CheckState == CheckState.Unchecked)
            {
                chk_smartComp.CheckState = CheckState.Checked;
            }
            else if (chk_smartComp.CheckState == CheckState.Indeterminate)
            {
                chk_smartComp.CheckState = CheckState.Checked;
            }
        }

        private void Chk_smartComp_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignore_chk_smartComp_change)
            {
                ignore_chk_smartComp_change = false;
                return;
            }

            if (chk_smartComp.CheckState == CheckState.Checked)
            {
                ComparisonRules.Data = StringComp.SMART_RULES;
            }
            else if (chk_smartComp.CheckState == CheckState.Unchecked)
            {
                ComparisonRules.Data = StringComp.Rules.None;
            }

            QuizEditor.ChangedSinceLastSave = true;
        }

        private void QuizEditorWordPair_SizeChanged(object sender, EventArgs e)
        {
            int width = (int)Math.Floor(Size.Width / 2d - 30);

            txt_front.Size = new Size(width, txt_front.Size.Height);
            txt_back.Size = new Size(width, txt_back.Size.Height);
        }

        public void MoveTo(int newIndex, bool updateUndoRedoStacks = true)
        {
            if (QuizEditor.UpdateUndoRedoStacks && updateUndoRedoStacks)
            {
                QuizEditor.UndoStack.Push(new UndoRedoActionPair(
                    new Action[] { this.MoveCard(QuizEditor.flp_cards.Controls.GetChildIndex(this)) },
                    new Action[] { this.MoveCard(newIndex) },
                    "Move card",
                    new OwnerControlData(this, this.Parent)
                    ));
                QuizEditor.UpdateUndoRedoTooltips();
            }

            QuizEditor.flp_cards.Controls.SetChildIndex(this, newIndex);

            QuizEditor.ChangedSinceLastSave = true;
            QuizEditor.CheckFixEmptyCards();

            QuizEditor.UpdateCardTabIndexes();
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            int newIndex = QuizEditor.flp_cards.Controls.GetChildIndex(this) - 1;
            if (newIndex >= 0)
            {
                MoveTo(newIndex);
            }
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            int newIndex = QuizEditor.flp_cards.Controls.GetChildIndex(this) + 1;
            if (newIndex < QuizEditor.flp_cards.Controls.Count)
            {
                MoveTo(newIndex);
            }
        }

        private void btn_moveTo_Click(object sender, EventArgs e)
        {
            var prompt = new QuizEditorCardMoveTo(QuizEditor.flp_cards.Controls.GetChildIndex(this), QuizEditor.flp_cards.Controls.Count - 1);
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                MoveTo(prompt.NewIndex);
            }
        }
    }
}
