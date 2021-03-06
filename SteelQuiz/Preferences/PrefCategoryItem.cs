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

namespace SteelQuiz
{
    public partial class PrefCategoryItem : UserControl, ThemeManager.IThemeable
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        public event EventHandler OnPrefSelected = null;
        public event EventHandler<Util.ReturnArgs> OnPrefDeselected = null;

        public bool Selectable { get; set; } = true;

        private bool _selected = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }

            set
            {
                if (value == _selected)
                {
                    // selection is already set
                    return;
                }

                // update color and eventually call selected events
                if (value)
                {
                    SelectWithoutInvokeEvent();
                    _selected = value;

                    InvokePrefSelected();
                }
                else
                {
                    _selected = value;
                    this.lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
                    this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();

                    InvokePrefDeselected();
                }
            }
        }

        public string PrefText
        {
            get
            {
                return this.lbl_text.Text;
            }

            set
            {
                this.lbl_text.Text = value;
            }
        }

        /// <summary>
        /// A control used as a category in a category collection
        /// </summary>
        public PrefCategoryItem()
        {
            InitializeComponent();
            SetTheme();
        }

        /// <summary>
        /// Selects the category without invoking its selection event
        /// </summary>
        public void SelectWithoutInvokeEvent()
        {
            if (_selected)
            {
                return;
            }

            _selected = true;

            this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedBackColor();
            this.lbl_selectedIndicator.BackColor = Color.FromArgb(255, 128, 0);

            if (Parent != null)
            {
                // deselect other categories
                foreach (var pcat in Parent.Controls.OfType<PrefCategoryItem>())
                {
                    if (pcat != this && pcat.Selected)
                    {
                        //(this.ParentForm as Preferences.Preferences).lastSelectedCategory = pcat;
                        pcat.Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the event which should be fired after selecting the category
        /// </summary>
        public void InvokePrefSelected()
        {
            this.OnPrefSelected?.Invoke(this, null);
        }

        /// <summary>
        /// Invokes the event which should be fired after deselecting the category
        /// </summary>
        public bool InvokePrefDeselected()
        {
            var args = new Util.ReturnArgs();
            this.OnPrefDeselected?.Invoke(this, args);
            return args.ReturnValue is bool ? (bool)args.ReturnValue : true;
        }

        public void SetTheme()
        {
            lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
            lbl_text.ForeColor = PreferencesTheme.GetPrefForeColor();

            lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();
        }

        /// <summary>
        /// Updates the colors for mouse hover
        /// </summary>
        private void StartHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedHoverBackColor();
            }
            else
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPreferenceHoverBackColor();
                this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPreferenceHoverBackColor();
            }
        }

        /// <summary>
        /// Updates the colors for no mouse hover
        /// </summary>
        private void StopHover()
        {
            if (Selected)
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefSelectedBackColor();
            }
            else
            {
                this.lbl_text.BackColor = PreferencesTheme.GetPrefBackColor();
                this.lbl_selectedIndicator.BackColor = PreferencesTheme.GetPrefBackColor();
            }
        }

        private void Lbl_text_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_text_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_selectedIndicator_MouseEnter(object sender, EventArgs e)
        {
            StartHover();
        }

        private void Lbl_selectedIndicator_MouseLeave(object sender, EventArgs e)
        {
            StopHover();
        }

        private void Lbl_text_Click(object sender, EventArgs e)
        {
            if (Selectable)
            {
                Selected = true;
            }
            else
            {
                InvokePrefSelected();
            }
        }

        private void Lbl_selectedIndicator_Click(object sender, EventArgs e)
        {
            if (Selectable)
            {
                Selected = true;
            }
            else
            {
                InvokePrefSelected();
            }
        }
    }
}
