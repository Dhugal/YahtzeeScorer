using NUnit.Framework;
using Scorer;
using Scorer.ScoreCalculators;
using System;
using System.Collections.Generic;
using YahtzeeInterfaces;

namespace ScorerTests
{
    [TestFixture]
    public class GameScorerWithCustomCalculatorTests
    {
        [Test]
        public void TestSingleCustomCalculationWorks()
        {
            var calulations = new Dictionary<string, IScoreCalculator>
            {
                { "Calc1", new NumberMatchScoreCalculator(1) }
            };
            var sut = new GameScorer(calulations);
            var input = "(1, 3, 1, 4, 3) Calc1";
            var roundScore = sut.CalculateScore(input);
            Assert.AreEqual(2, roundScore);
            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void TestCategoryOutsideOfCustomCalculationWorks()
        {
            var calulations = new Dictionary<string, IScoreCalculator>
            {
                { "Calc1", new NumberMatchScoreCalculator(1) }
            };
            var sut = new GameScorer(calulations);
            var input = "(1, 3, 1, 4, 3) BAD_CALC";
            Assert.Throws<NotImplementedException>(() => sut.CalculateScore(input));
        }
    }
}