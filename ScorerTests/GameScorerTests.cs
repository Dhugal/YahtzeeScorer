using NUnit.Framework;
using Scorer;
using System;

namespace ScorerTests
{
    [TestFixture]
    public class GameScorerTests
    {
        [Test]
        public void ExampleCaseOneShouldCalculateCorrectly()
        {
            var sut = new GameScorer();

            var input = "(1, 3, 1, 4, 3) ones";

            var roundScore = sut.CalculateScore(input);

            Assert.AreEqual(2, roundScore);
            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void ExampleCaseTwoShouldCalculateCorrectly()
        {
            var sut = new GameScorer();

            var input = "(2, 1, 2, 4, 1) fullhouse";

            var roundScore = sut.CalculateScore(input);

            Assert.AreEqual(0, roundScore);
            Assert.AreEqual(0, sut.CurrentScore);
        }

        [Test]
        public void ExampleCaseThreeShouldCalculateCorrectly()
        {
            var sut = new GameScorer();

            var input = "(3, 3, 3, 3, 3) threes";

            var roundScore = sut.CalculateScore(input);

            Assert.AreEqual(15, roundScore);
            Assert.AreEqual(15, sut.CurrentScore);
        }

        [Test]
        public void ExampleCasesInSequenceShouldCalculateCorrectTotal()
        {
            var sut = new GameScorer();

            var input1 = "(1, 3, 1, 4, 3) ones";
            var input2 = "(2, 1, 2, 4, 1) fullhouse";
            var input3 = "(3, 3, 3, 3, 3) threes";

            var roundScore1 = sut.CalculateScore(input1);
            Assert.AreEqual(2, roundScore1);
            Assert.AreEqual(2, sut.CurrentScore);


            var roundScore2 = sut.CalculateScore(input2);
            Assert.AreEqual(0, roundScore2);
            Assert.AreEqual(2, sut.CurrentScore);

            var roundScore3 = sut.CalculateScore(input3);
            Assert.AreEqual(15, roundScore3);
            Assert.AreEqual(17, sut.CurrentScore);
        }



        [Test]
        public void MoreThanOneRoundAgainstTheSameCategoryShouldThrowArgumentExeption()
        {
            var sut = new GameScorer();

            var input1 = "(1, 3, 1, 4, 3) ones";
            var input2 = "(3, 3, 3, 3, 3) threes";
            var input3 = "(2, 1, 2, 4, 1) ones";

            sut.CalculateScore(input1);
            sut.CalculateScore(input2);
            Assert.Throws<ArgumentException>(() => sut.CalculateScore(input3));
        }

        [Test]
        public void UnknownCategoryShouldThrowArgumentExeption()
        {
            var sut = new GameScorer();
            var input1 = "(1, 3, 1, 4, 3) BAD_CATEGORY";
            Assert.Throws<NotImplementedException>(() => sut.CalculateScore(input1));
        }
    }
}