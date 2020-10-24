using NUnit.Framework;
using Scorer;
using Scorer.ScoreCalculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerTests
{
    [TestFixture]
    public class NumberMatchScoreCalculatorTests
    {
        [Test]
        public void TestNoMatchingNumbersReturnsAScoreOfZero()
        {
            var sut = new NumberMatchScoreCalculator(6);
            var rolls = new int[] { 1, 2, 3, 4, 5 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestOneMatchingNumbersReturnsAScoreOfZero()
        {
            var sut = new NumberMatchScoreCalculator(1);
            var rolls = new int[] { 1, 2, 3, 4, 5 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestTwoMatchingNumbersReturnsAScoreOfZero()
        {
            var sut = new NumberMatchScoreCalculator(1);
            var rolls = new int[] { 1, 2, 3, 1, 5 };
            var result = sut.CalculateScore(rolls);
            Assert.AreEqual(2, result);
        }
    }
}
