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

namespace SteelQuiz.Preferences
{
    public partial class CategoriesSync : CategoryCollection
    {
        public CategoriesSync()
        {
            InitializeComponent();

            SetTheme();
        }

        private void Pcat_quizFolders_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsQuizFolders));
        }

        private void Pcat_quizFolders_OnPrefDeselected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).Save(typeof(PrefsQuizFolders));
        }

        private void Pcat_progSync_OnPrefSelected(object sender, EventArgs e)
        {
            (ParentForm as Preferences).SwitchCategory(typeof(PrefsProgressSync));
        }

        private void Pcat_progSync_OnPrefDeselected(object sender, Util.ReturnArgs e)
        {
            bool result = (ParentForm as Preferences).Save(typeof(PrefsProgressSync));
            e.ReturnValue = result;
        }
    }
}
