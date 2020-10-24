using Scorer.ScoreCalculators;
using System;
using System.Collections.Generic;
using YahtzeeInterfaces;

namespace Scorer
{
    public class GameScorer : IGameScorer
    {
        public const string Category_Ones = "ones";
        public const string Category_Twos = "twos";
        public const string Category_Threes = "threes";
        public const string Category_Fours = "fours";
        public const string Category_Fives = "fives";
        public const string Category_Sixes = "sixes";
        public const string Category_TwoPairs = "twopairs";
        public const string Category_FullHouse = "fullhouse";

        public int CurrentScore { get; private set; }

        private HashSet<string> _usedCategories = new HashSet<string>();
        private InputParser _inputParser = new InputParser();
        private IDictionary<string, IScoreCalculator> _scoreCalculators;

        public GameScorer()
        {
            _scoreCalculators = new Dictionary<string, IScoreCalculator>()
            {
                { Category_Ones, new NumberMatchScoreCalculator(1) },
                { Category_Twos, new NumberMatchScoreCalculator(2) },
                { Category_Threes, new NumberMatchScoreCalculator(3) },
                { Category_Fours, new NumberMatchScoreCalculator(4) },
                { Category_Fives, new NumberMatchScoreCalculator(5) },
                { Category_Sixes, new NumberMatchScoreCalculator(6) },
                { Category_TwoPairs, new TwoPairsScoreCalculator() },
                { Category_FullHouse, new FullHouseScoreCalculator() }
            };
        }

        public GameScorer(Dictionary<string, IScoreCalculator> customCalculations)
        {
            _scoreCalculators = customCalculations;
        }

        public int CalculateScore(string input)
        {
            // 1 Parse Input.
            var roundInfo = _inputParser.ParseInput(input);
            // 2 Validate category.
            if (_usedCategories.Contains(roundInfo.Category))
            {
                throw new ArgumentException("Category has already been used by player.");
            }
            _usedCategories.Add(roundInfo.Category);

            // Find a matching calculator.
            if (!_scoreCalculators.ContainsKey(roundInfo.Category))
            {
                throw new NotImplementedException($"Category {roundInfo.Category} is not currently supported.");
            }

            // 3 Calculate Round Score.
            var roundScore = _scoreCalculators[roundInfo.Category].CalculateScore(roundInfo.Rolls);

            // 4 Increment Current Score.
            this.CurrentScore += roundScore;

            // 5 Return Round Score?
            return roundScore;
        }
    }
}