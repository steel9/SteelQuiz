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
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.ConfigData
{
    public enum UpdateChannel
    {
        Stable,
        Development
    }

    public enum AutomaticUpdateMode
    {
        /// <summary>
        /// Checks for, downloads, and installs updates, automatically
        /// </summary>
        CheckDownloadInstall = 2,

        /// <summary>
        /// Checks for updates and notifies the user, but does not download or install the updates automatically
        /// </summary>
        CheckOnly = 1,

        /// <summary>
        /// Does not check for updates
        /// </summary>
        Disabled = 0
    }

    public class UpdateConfig
    {
        /// <summary>
        /// The mode for automatic updates
        /// </summary>
        public AutomaticUpdateMode AutoUpdateMode { get; set; } = AutomaticUpdateMode.CheckDownloadInstall;

        /// <summary>
        /// The delay until the Update, Not now and Close button becomes enabled on the update dialog. Used to prevent misclicks.
        /// </summary>
        public int UpdateAvailableButtonEnableDelay_s { get; set; } = 1;

        /// <summary>
        /// The update channel to be used when updating
        /// </summary>
        public UpdateChannel UpdateChannel { get; set; } = UpdateChannel.Stable;

        /// <summary>
        /// The latest version of SteelQuiz that has been used. Used to make sure the application doesn't automatically get updated when the user downgrades
        /// </summary>
        public string LatestVersionRun { get; set; }

        /// <summary>
        /// The version of the update to skip. If no update is skipped, it is null
        /// </summary>
        public string VersionSkip { get; set; }
    }
}
