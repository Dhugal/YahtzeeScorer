using NUnit.Framework;
using Scorer;
using Scorer.ScoreCalculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerTests
{
    [TestFixture]
    public class TwoPairsScoreCalculatorTests
    {
        [Test]
        public void TestNoPairsNumbersReturnsAScoreOfZero()
        {
            var sut = new TwoPairsScoreCalculator();
            var rolls = new int[] { 1, 2, 3, 4, 5 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestExamplePairsReturnsExpectedScore()
        {
            var sut = new TwoPairsScoreCalculator();
            var rolls = new int[] { 1, 1, 2, 3, 3 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void TestThreeInOnePairStillOnlyCountsTwoPairsReturnsExpectedScore()
        {
            var sut = new TwoPairsScoreCalculator();
            var rolls = new int[] { 1, 1, 1, 3, 3 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(8, result);
        }
    }
}
