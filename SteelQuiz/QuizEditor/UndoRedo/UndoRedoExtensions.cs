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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.QuizEditor.UndoRedo
{
    /// <summary>
    /// A collection of Actions used in undo/redo-stacks. For example, if an item is added to a ListBox, the RemoveItem Action should be added to the undo stack.
    /// </summary>
    public static class UndoRedoExtensions
    {
        public static Action ChangeText(this TextBox textBox, string to, Action beforeRevertAction)
        {
            return () => {
                beforeRevertAction?.Invoke();
                textBox.Text = to;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            };
        }


        public static Action ChangeText(this TextBox textBox, Func<Form> formPtr, string textBoxName, string to)
        {
            return () => {
                var txt = formPtr().Controls[textBoxName] as TextBox;
                if (txt == null)
                {
                    return;
                }
                txt.Text = to;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            };
        }

        public static Action RemoveItem(this ListBox listBox, object added)
        {
            return () => {
                listBox.Items.Remove(added);
            };
        }

        public static Action RemoveItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object added)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return;
                }
                lst.Items.Remove(added);
            };
        }

        public static Action AddItem(this ListBox listBox, object removed)
        {
            return () => {
                listBox.Items.Add(removed);
            };
        }

        public static Action AddItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object removed)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return;
                }
                lst.Items.Add(removed);
            };
        }

        public static Action ChangeItem(this ListBox listBox, object to, object from)
        {
            return () => {
                listBox.Items[listBox.Items.IndexOf(from)] = to;
            };
        }

        public static Action ChangeItem(this ListBox listBox, Func<Form> formPtr, string listBoxName, object to, object from)
        {
            return () => {
                var lst = formPtr().Controls[listBoxName] as ListBox;
                if (lst == null)
                {
                    return;
                }
                lst.Items[lst.Items.IndexOf(from)] = to;
            };
        }

        public static Action SetChecked(this CheckBox checkBox, bool state, Action beforeRevertAction)
        {
            return () =>
            {
                beforeRevertAction?.Invoke();
                checkBox.Checked = state;
            };
        }

        public static Action SetCheckState(this CheckBox checkBox, CheckState checkState, Action beforeRevertAction)
        {
            return () =>
            {
                beforeRevertAction?.Invoke();
                checkBox.CheckState = checkState;
            };
        }

        public static Action RemoveCard(this QuizEditor quizEditor, QuizEditorCard card)
        {
            return () =>
            {
                quizEditor.flp_cards.Controls.Remove(card);
                quizEditor.CheckFixEmptyCards();
            };
        }

        public static Action AddCard(this QuizEditor quizEditor, QuizEditorCard card, int index)
        {
            return () =>
            {
                quizEditor.flp_cards.Controls.Add(card);
                quizEditor.flp_cards.Controls.SetChildIndex(card, index);
                quizEditor.CheckFixEmptyCards();
            };
        }

        public static Action MoveCard(this QuizEditorCard card, int index)
        {
            return () =>
            {
                card.MoveTo(index, false);
            };
        }

        public static Action RemoveItem<T>(this IList<T> lst, T item)
        {
            return () =>
            {
                lst.Remove(item);
            };
        }

        public static Action AddItem<T>(this IList<T> lst, T item)
        {
            return () =>
            {
                lst.Add(item);
            };
        }

        public static Action Set<T>(this Pointer<T> ptr, T val)
        {
            return () =>
            {
                ptr.Data = val;
            };
        }

        public static Action SetSemiSilentUR<T>(this Pointer<T> ptr, T val)
        {
            return () =>
            {
                ptr.SetSemiSilent(val);
            };
        }
    }
}
