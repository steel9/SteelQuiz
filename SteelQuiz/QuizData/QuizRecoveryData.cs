﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    public class QuizRecoveryData
    {
        [JsonProperty]
        public Quiz Quiz { get; private set; }

        [JsonProperty]
        public string QuizPath { get; private set; }

        [JsonProperty]
        public string RecoveryFilePath { get; private set; }

        [JsonProperty]
        public DateTime LastUpdated { get; private set; }

        public QuizRecoveryData(string quizPath, string recoveryPath = null)
        {
            QuizPath = quizPath;

            if (recoveryPath == null)
            {
                SetRecoveryPath();
            }
            else
            {
                RecoveryFilePath = recoveryPath;
            }
        }

        public void SetRecoveryPath()
        {
            string recoveryFilePath;
            int untitledCounter = 1;
            if (QuizPath != null)
            {
                recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"{Path.GetFileNameWithoutExtension(QuizPath)}.steelquiz");
            }
            else
            {
                recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"Untitled{untitledCounter.ToString()}.steelquiz");
            }

            while (File.Exists(recoveryFilePath))
            {
                ++untitledCounter;
                if (QuizPath != null)
                {
                    recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER,
                        $"{Path.GetFileNameWithoutExtension(QuizPath)}_{ untitledCounter.ToString() }.steelquiz");
                }
                else
                {
                    recoveryFilePath = Path.Combine(QuizCore.QUIZ_RECOVERY_FOLDER, $"Untitled{untitledCounter.ToString()}.steelquiz");
                }
            }

            RecoveryFilePath = recoveryFilePath;
        }

        public void Save(Quiz quiz)
        {
            Quiz = quiz;
            LastUpdated = DateTime.Now;
            using (var writer = new StreamWriter(RecoveryFilePath, false))
            {
                writer.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }
    }
}
