using NUnit.Framework;
using Scorer;
using Scorer.ScoreCalculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerTests
{
    [TestFixture]
    public class FullHouseScoreCalculatorTests
    {
        [Test]
        public void TestNoMatchReturnsAScoreOfZero()
        {
            var sut = new FullHouseScoreCalculator();
            var rolls = new int[] { 1, 2, 3, 4, 5 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestSequentialFullHouseReturnsExpectedScore()
        {
            var sut = new FullHouseScoreCalculator();
            var rolls = new int[] { 1, 1, 2, 2, 2 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void TestSplitFullHouseReturnsExpectedScore()
        {
            var sut = new FullHouseScoreCalculator();
            var rolls = new int[] { 1, 2, 1, 2, 1 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void TestAllOneNumberReturnsZero()
        {
            var sut = new FullHouseScoreCalculator();
            var rolls = new int[] { 1, 1, 1, 1, 1 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(0, result);
        }
    }
}
