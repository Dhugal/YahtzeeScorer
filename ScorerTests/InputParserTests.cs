using NUnit.Framework;
using Scorer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerTests
{
    [TestFixture]
    public class InputParserTests
    {
        [Test]
        public void TestExampleInput1ReturnsExpectedOutput()
        {
            var sut = new InputParser();
            var input = "(1, 3, 1, 4, 3) ones";
            var result = sut.ParseInput(input);
            Assert.AreEqual("ones", result.Category);
            Assert.AreEqual(new int[] { 1, 3, 1, 4, 3 }, result.Rolls);
        }

        [Test]
        public void TestExampleInput2ReturnsExpectedOutput()
        {
            var sut = new InputParser();
            var input = "(2, 1, 2, 4, 1) fullhouse";
            var result = sut.ParseInput(input);
            Assert.AreEqual("fullhouse", result.Category);
            Assert.AreEqual(new int[] { 2, 1, 2, 4, 1 }, result.Rolls);
        }

        [Test]
        public void TestExampleInput3ReturnsExpectedOutput()
        {
            var sut = new InputParser();
            var input = "(3, 3, 3, 3, 3) threes";
            var result = sut.ParseInput(input);
            Assert.AreEqual("threes", result.Category);
            Assert.AreEqual(new int[] { 3, 3, 3, 3, 3 }, result.Rolls);
        }


        [Test]
        public void NullInputShouldThrowArgumentException()
        {
            var sut = new InputParser();
            string input1 = null;
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void EmptyInputShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = string.Empty;
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void WhitespaceInputShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = "  ";
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void InputWithMissingRollShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = "(3, 3, 3, 3) threes";
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void InputWithMissingCategoryShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = "(3, 3, 3, 3, 3)";
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void InputWithAdditionalRollShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = "(3, 3, 3, 3, 3, 3) threes";
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

        [Test]
        public void InputWithNonNumericRollShouldThrowArgumentException()
        {
            var sut = new InputParser();
            var input1 = "(3, X, 3, 3, 3) threes";
            Assert.Throws<ArgumentException>(() => sut.ParseInput(input1));
        }

    }
}
