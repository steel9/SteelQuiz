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

using Newtonsoft.Json;
using SteelQuiz.ThemeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.ConfigData
{
    public class Config
    {
        public string FileFormatVersion { get; set; }

        /// <summary>
        /// True if the user has accepted the terms of use when starting the application for the first time, otherwise false.
        /// </summary>
        public bool AcceptedTermsOfUse { get; set; } = false;

        /// <summary>
        /// True if file associations have been registered upon application upgrade (to v5.0), or if it has been offered during setup.
        /// </summary>
        public bool FileAssociationsOfferedOrRegistered { get; set; } = false;

        /// <summary>
        /// The GUID of the last quiz practised.
        /// </summary>
        public Guid LastQuiz { get; set; } = Guid.Empty;

        /// <summary>
        /// The set application theme.
        /// </summary>
        public ThemeCore.Theme Theme { get; set; } = ThemeCore.Theme.Light;

        /// <summary>
        /// True if the application should use the same theme as Windows 10 apps.
        /// </summary>
        public bool SyncWin10Theme { get; set; } = true;

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// True if name is allowed to be displayed on welcome messages on the welcome screen, otherwise false.
        /// </summary>
        public bool ShowNameOnWelcomeScreen { get; set; } = true;

        /// <summary>
        /// The config for the quiz editor.
        /// </summary>
        public QuizEditorConfig QuizEditorConfig { get; set; } = new QuizEditorConfig();

        /// <summary>
        /// The config for updates.
        /// </summary>
        public UpdateConfig UpdateConfig { get; set; } = new UpdateConfig();

        /// <summary>
        /// The config for storage.
        /// </summary>
        public StorageConfig StorageConfig { get; set; } = new StorageConfig();

        [Obsolete("Use StorageConfig instead", true)]
        [JsonProperty]
        /// <summary>
        /// The legacy config for synchronization. Its property remains to ensure it gets copied over into StorageConfig upon upgrade to SteelQuiz v5.0.0.
        /// </summary>
        private StorageConfig SyncConfig { set => StorageConfig = value; }

        /// <summary>
        /// Statistics that have been collected.
        /// </summary>
        public Statistics Statistics { get; set; } = new Statistics();

        /// <summary>
        /// Advanced config.
        /// </summary>
        public AdvancedConfig AdvancedConfig { get; set; } = new AdvancedConfig();

        public Config()
        {
            FileFormatVersion = MetaData.CONFIG_FILE_FORMAT_VERSION;
        }
    }
}