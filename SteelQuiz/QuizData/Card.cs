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
using SteelQuiz.QuizPractise;
using SteelQuiz.QuizProgressData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.QuizData
{
    /// <summary>
    /// A pair of a question and its answer.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The GUID of this card.
        /// </summary>
        public Guid Guid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// The term/word/question/answer on the front of the "flashcard"
        /// </summary>
        public string Front { get; set; }
        /// <summary>
        /// The synonym(s) to Front
        /// </summary>
        public List<string> FrontSynonyms { get; set; } = new List<string>();

        /// <summary>
        /// The term/word/question/answer on the back of the "flashcard"
        /// </summary>
        public string Back { get; set; }
        /// <summary>
        /// The synonym(s) to Back
        /// </summary>
        public List<string> BackSynonyms { get; set; } = new List<string>();
        /// <summary>
        /// The Smart Comparison rules to use when comparing answers to this Card.
        /// </summary>
        public StringComp.Rules SmartComparisonRules { get; set; }

        #region Obsolete properties
        [JsonProperty]
        [Obsolete("Use Front instead", true)]
        private string Word1 { set => Front = value; }

        [JsonProperty]
        [Obsolete("Use Back instead", true)]
        private string Word2 { set => Back = value; }

        [JsonProperty]
        [Obsolete("Use FrontSynonyms instead", true)]
        private List<string> Word1Synonyms { set => FrontSynonyms = value; }

        [JsonProperty]
        [Obsolete("Use BackSynonyms instead", true)]
        private List<string> Word2Synonyms { set => BackSynonyms = value; }

        [JsonProperty]
        [Obsolete("Use SmartComparisonRules instead", true)]
        private StringComp.Rules TranslationRules { set => SmartComparisonRules = value; }
        #endregion

        /// <summary>
        /// Creates a new card, that is, a question and answer pair, with the specified content and Smart Comparison rules.
        /// </summary>
        /// <param name="frontContent">The text on the front of the Card.</param>
        /// <param name="backContent">The text on the back of the Card.</param>
        /// <param name="smartComparisonRules">The Smart Comparison rules to use when comparing answers to this Card.</param>
        /// <param name="frontSynonyms">Eventual synonyms to frontContent</param>
        /// <param name="backSynonyms">Eventual synonyms to backContent</param>
        public Card(string frontContent, string backContent, StringComp.Rules smartComparisonRules, List<string> frontSynonyms = null, List<string> backSynonyms = null)
        {
            Front = frontContent;
            Back = backContent;
            SmartComparisonRules = smartComparisonRules;

            if (frontSynonyms != null)
            {
                FrontSynonyms = frontSynonyms;
            }
            if (backSynonyms != null)
            {
                BackSynonyms = backSynonyms;
            }
        }

        /// <summary>
        /// Retrieves the content of the side of the flashcard which the user should be prompted with - and give an answer to.
        /// </summary>
        /// <param name="quiz">The Quiz which this Card belongs to.</param>
        /// <returns>Returns the content of the question card.</returns>
        public string GetSideToAsk(Quiz quiz)
        {
            return quiz.ProgressData.AnswerCardSide == CardSide.Back ? Front : Back;
        }

        /// <summary>
        /// Retrieves the content of the side of the flashcard which the user's answer should be equal/similar to.
        /// </summary>
        /// <param name="quiz">The Quiz which this Card belongs to.</param>
        /// <returns>Returns the content of the answer card.</returns>
        public string GetSideToAnswer(Quiz quiz)
        {
            return quiz.ProgressData.AnswerCardSide == CardSide.Back ? Back : Front;
        }

        /// <summary>
        /// Gets all answers to this Card if it has multiple required answers, or just the answer to this card if it only has one required answer, and joins them to a string with the specified separator.
        /// </summary>
        /// <param name="quiz">The quiz which this card belongs to.</param>
        /// <param name="separator">The string that should be put between all answers.</param>
        /// <returns>All answers joined together to a string.</returns>
        public string GetAllAnswers(Quiz quiz, string separator = "\n\n")
        {
            var answers = GetRequiredAnswerCards(quiz);
            return string.Join(separator, answers.Select(x => x.GetSideToAnswer(quiz)));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card, true, true);
        }

        public bool Equals(Card card2, bool ignoreSynonyms, bool ignoreTranslationRules)
        {
            if (card2 == null)
            {
                return false;
            }

            return
                this.Front == ((Card)card2).Front &&
                (ignoreSynonyms || this.FrontSynonyms.SequenceEqual(((Card)card2).FrontSynonyms)) &&
                this.Back == ((Card)card2).Back &&
                (ignoreSynonyms || this.BackSynonyms.SequenceEqual(((Card)card2).BackSynonyms)) &&
                (ignoreTranslationRules || this.SmartComparisonRules == ((Card)card2).SmartComparisonRules);
        }

        public override int GetHashCode()
        {
            var hashCode = -295472895;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Front);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(FrontSynonyms);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Back);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(BackSynonyms);
            hashCode = hashCode * -1521134295 + SmartComparisonRules.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Retrieves the progress data belonging to this Card, from the specified Quiz.
        /// </summary>
        /// <param name="quiz">The quiz this Card belongs to, and that contains the progress data for this Card.</param>
        /// <returns>The CardProgress object belonging to this Card.</returns>
        public CardProgress GetProgressData(Quiz quiz)
        {
            foreach (var p in quiz.ProgressData.CardProgress)
            {
                if (p.CardGuid == Guid)
                {
                    return p;
                }
            }

            var cardProgress = new CardProgress(Guid);
            quiz.ProgressData.CardProgress.Add(cardProgress);
            return cardProgress;
        }

        /// <summary>
        /// Finds all cards with the same "question" side as this card, and an alternative answer side to this card, that are required to be answered, including this card.
        /// </summary>
        /// <returns>A collection of Cards required to be answered.</returns>
        public IEnumerable<Card> GetRequiredAnswerCards(Quiz quiz)
        {
            if (quiz.ProgressData.AnswerCardSide == CardSide.Back)
            {
                return quiz.Cards.Where(x => x.Front == Front);
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Front)
            {
                return quiz.Cards.Where(x => x.Back == Back);
            }
            else
            {
                // should never be reached
                throw new Exception("GetRequiredAlternativeCards() reached end");
            }
        }

        /// <summary>
        /// Retrieves a collection of answers already provided to this card, if it is a multi-answer card.
        /// </summary>
        /// <returns>The card collection</returns>
        public IEnumerable<Card> MultiAnswersAlreadyEntered(Quiz quiz)
        {
            return GetRequiredAnswerCards(quiz).Where(x => x.GetProgressData(quiz).AskedThisRound);
        }

        public class AnswerDiff
        {
            public string MostSimilarAnswer { get; set; }
            public int Difference { get; set; }
            public StringComp.CorrectCertainty Certainty { get; set; }
            public Card Card { get; set; }

            public AnswerDiff(int difference, string mostSimilarAnswer, StringComp.CorrectCertainty certainty, Card card)
            {
                Difference = difference;
                MostSimilarAnswer = mostSimilarAnswer;
                Certainty = certainty;
                Card = card;
            }

            public bool IsCorrect()
            {
                return Difference == 0;
            }
        }

        /// <summary>
        /// Adds successful to AnswerAttempts if updateProgress; then marks the card as answered and calculates when to show it next time.
        /// </summary>
        /// <param name="quiz">The quiz which the card belongs to.</param>
        /// <param name="card">The card to add attempt for.</param>
        /// <param name="updateProgress">True if the attempt should be added to AnswerAttempts and CorrectAnswersThisRound.</param>
        public void AddSuccessfulAttempt(Quiz quiz, bool updateProgress)
        {
            var progressData = GetProgressData(quiz);

            if (updateProgress)
            {
                progressData.AnswerAttempts.Add(new AnswerAttempt(true));
                ++quiz.ProgressData.CorrectAnswersThisRound;
            }

            progressData.AskedThisRound = true;
            quiz.ProgressData.CurrentCard = Guid.Empty;
            if (progressData.AnswerAttempts.Count >= quiz.ProgressData.MinimumTriesCountToConsiderSkippingQuestion)
            {
                progressData.RoundsToSkip = (int)Math.Floor(Math.Pow(progressData.GetLearningProgress(quiz.ProgressData), 2) * 5);
            }
        }

        /// <summary>
        /// Adds a failed attempt to AnswerAttempts if updateProgress
        /// </summary>
        /// <param name="quiz">The quiz which the card belongs to.</param>
        /// <param name="card">The card to add attempt for.</param>
        /// <param name="updateProgress">True if the attempt should be added to AnswerAttempts.</param>
        /// <param name="userGoingToCopy">True if the user needs to copy the correct answer and answer correct before continuing; false to mark the question as answered and move on.</param>
        public void AddFailedAttempt(Quiz quiz, bool updateProgress, bool userGoingToCopy)
        {
            var progressData = GetProgressData(quiz);

            if (updateProgress)
            {
                progressData.AnswerAttempts.Add(new AnswerAttempt(false));
            }

            if (!userGoingToCopy)
            {
                progressData.AskedThisRound = true;
                quiz.ProgressData.CurrentCard = Guid.Empty;
            }
        }

        /// <summary>
        /// Checks the answer to see if it is correct, and returns data about the closest match
        /// </summary>
        /// <param name="input">The user answer</param>
        /// <param name="answerIgnores">In case of a question with multiple answers, contains the cards belonging to answers already provided</param>
        /// <param name="updateProgress">True if progress should be updated, otherwise false</param>
        /// <param name="markAsAnswered">True if the matched Card should be marked as answered.</param>
        /// <returns></returns>
        public AnswerDiff WrittenAnswerCheck(Quiz quiz, string input, IEnumerable<Card> answerIgnores = null, bool updateProgress = true, bool markAsAnswered = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            foreach (var card in GetRequiredAnswerCards(quiz).Where(x => answerIgnores == null || !answerIgnores.Contains(x)))
            {
                similarityData = similarityData.Concat(SimilarityData(quiz, card, input, updateProgress)).ToList();
            }

            StringComp.SimilarityData bestSimilarityData = similarityData.OrderBy(x => x.Difference).ThenBy(x => (int)x.Certainty).First();

            var ansDiff = new AnswerDiff(bestSimilarityData.Difference, bestSimilarityData.CorrectAnswer, bestSimilarityData.Certainty, bestSimilarityData.Card);

            if (markAsAnswered)
            {
                if (ansDiff.IsCorrect())
                {
                    ansDiff.Card.AddSuccessfulAttempt(quiz, updateProgress);
                }
                else
                {
                    ansDiff.Card.AddFailedAttempt(quiz, updateProgress, true);
                }

                QuizCore.SaveQuizProgress(quiz);
            }

            return ansDiff;
        }

        private IEnumerable<StringComp.SimilarityData> SimilarityData(Quiz quiz, Card card, string input, bool updateProgress = true)
        {
            var similarityData = new List<StringComp.SimilarityData>();

            if (quiz.ProgressData.AnswerCardSide == CardSide.Back)
            {
                similarityData.Add(StringComp.Similarity(input, card.Back, card, SmartComparisonRules));
                foreach (var synonym in card.BackSynonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, card, SmartComparisonRules));
                }
            }
            else if (quiz.ProgressData.AnswerCardSide == CardSide.Front)
            {
                similarityData.Add(StringComp.Similarity(input, card.Front, card, SmartComparisonRules));
                foreach (var synonym in card.FrontSynonyms)
                {
                    similarityData.Add(StringComp.Similarity(input, synonym, card, SmartComparisonRules));
                }
            }
            else
            {
                throw new NotImplementedException("What");
            }

            return similarityData;
        }
    }
}