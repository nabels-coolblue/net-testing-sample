using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_ZeroString_ReturnsZero()
        {
            var sut = new StringCalculator();
            var result = sut.Add(string.Empty);

            result.Should().Be(0);
        }

        [TestMethod]
        public void Add_OneNumber_ReturnsTheSameNumber()
        {
            var sut = new StringCalculator();
            var expected = 1;
            var result = sut.Add(expected.ToString());
            

            result.Should().Be(1);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsTheSum()
        {
            var sut = new StringCalculator();
            var result = sut.Add("1,2");

            result.Should().Be(3);
        }

        [TestMethod]
        public void Add_LotsOfNumbers_ReturnsTheSum()
        {
            var sut = new StringCalculator();
            var result = sut.Add("1,2,4,5,6,6,4");

            result.Should().Be(1 + 2 + 4 + 5 + 6 + 6 + 4);
        }

        [TestMethod]
        public void Add_UsingMixOfDelimiters_ReturnsTheSum()
        {
            var sut = new StringCalculator();
            var result = sut.Add("1\n2,3");

            result.Should().Be(1 + 2 + 3);
        }

        [TestMethod]
        public void Add_UsingACustomDelimiter_ReturnsTheSum()
        {
            var sut = new StringCalculator();
            var result = sut.Add("//;\n1;2");

            result.Should().Be(1 + 2);
        }


        [TestMethod]
        public void Add_AddingNegativeNumber_ThrowsException()
        {
            var sut = new StringCalculator();

            Action act = () => sut.Add("-2");

            act.ShouldThrow<NoNegativesAllowedException>();
        }

        [TestMethod]
        public void Add_AddingNegativeNumbers_ThrowsException()
        {
            var sut = new StringCalculator();
            Action act = () => sut.Add("-2,-3");

            act.ShouldThrow<NoNegativesAllowedException>();
        }

        [TestMethod]
        public void Add_AddingNegativeNumbersWithCustomDelimiter_ThrowsException()
        {
            var sut = new StringCalculator();
            Action act = () => sut.Add("//;\n-2;-3");

            act.ShouldThrow<NoNegativesAllowedException>();
        }
    }
}
