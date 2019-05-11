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

using SteelQuiz.ThemeManager.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteelQuiz.Preferences
{
    public class CategoryCollection : AutoThemeableUserControl
    {
        private Button backButton;
        private bool _isSubCategory = false;
        public bool IsSubCategory
        {
            get
            {
                return _isSubCategory;
            }

            set
            {
                if (value)
                {
                    this.backButton = new Button();
                    this.backButton.Click += BackButton_Click;
                    this.backButton.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
                    this.backButton.FlatAppearance.BorderSize = 0;
                    this.backButton.FlatStyle = FlatStyle.Flat;
                    this.backButton.ForeColor = System.Drawing.Color.White;
                    this.backButton.Location = new System.Drawing.Point(0, 13);
                    this.backButton.Name = "btn_back";
                    this.backButton.Size = new System.Drawing.Size(130, 23);
                    this.backButton.TabIndex = 14;
                    this.backButton.Text = "←";
                    this.backButton.UseVisualStyleBackColor = false;
                    Controls.Add(backButton);

                    /*
                    foreach (var prefCategory in Controls.OfType<PrefCategory>())
                    {
                        prefCategory.Location = new System.Drawing.Point(prefCategory.Location.X, prefCategory.Location.Y + 35);
                    }
                    */
                }
                else
                {
                    backButton.Dispose();

                    /*
                    foreach (var prefCategory in Controls.OfType<PrefCategory>())
                    {
                        prefCategory.Location = new System.Drawing.Point(prefCategory.Location.X, prefCategory.Location.Y - 35);
                    }
                    */
                }
                _isSubCategory = value;
            }
        }

        private PreferencesTheme PreferencesTheme = new PreferencesTheme();

        private void BackButton_Click(object sender, EventArgs e)
        {
            (ParentForm as Preferences).PopCategoryCollection(this);
        }

        protected override void SetTheme()
        {
            base.SetTheme();

            BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
            if (backButton != null)
            {
                backButton.BackColor = PreferencesTheme.GetPrefCatPanelBackColor();
            }
        }

        public void InvokeSelectedEvent()
        {
            foreach (var cat in Controls.OfType<PrefCategory>())
            {
                if (cat.Selected)
                {
                    cat.InvokePrefSelected();
                }
            }
        }

        public new void Show()
        {
            base.Show();

            // animation
        }

        public new void Hide()
        {
            base.Hide();

            // animation

        }
    }
}