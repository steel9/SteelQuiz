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
using SteelQuiz.Extensions;
using Microsoft.Win32;

namespace SteelQuiz.Preferences
{
    public partial class PrefsAdvanced : AutoThemeableUserControl, IPreferenceCategory
    {
        private PreferencesTheme PreferencesTheme = new PreferencesTheme();
        private bool skipConfigApply = true;

        public PrefsAdvanced()
        {
            InitializeComponent();

            LoadPreferences();
            
            SetTheme();
            skipConfigApply = false;
        }

        public void LoadPreferences()
        {
            chk_enableAtomicIO.Checked = ConfigManager.Config.AdvancedConfig.AtomicIOEnabled;
        }

        private void Chk_enableAtomicIO_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.AdvancedConfig.AtomicIOEnabled = chk_enableAtomicIO.Checked;
            ConfigManager.SaveConfig();
        }
    }
}