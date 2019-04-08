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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class Quiz
    {
        public Guid GUID { get; set; }
        public string FileFormatVersion { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public List<WordPair> WordPairs { get; set; }

        public Quiz(string lang1, string lang2, string quizFileFormatVersion, Guid? guid = null)
        {
            if (guid == null)
            {
                GUID = Guid.NewGuid();
            }
            else
            {
                GUID = (Guid)guid;
            }
            Language1 = lang1;
            Language2 = lang2;
            WordPairs = new List<WordPair>();
            FileFormatVersion = quizFileFormatVersion;
        }
    }
}