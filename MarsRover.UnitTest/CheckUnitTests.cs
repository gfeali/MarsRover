using MarsRover.Infrastructure.Validations;
using NUnit.Framework;
using System;

namespace MarsRover.UnitTest
{
    [TestFixture]
    internal class CheckUnitTests
    {
        [Test, Category("Check")]
        [TestCase(false, "TestMessage")]
        public void Given_False_Assertion_When_Call_Check_Then_Throw_Exception(bool value, string message)
        {
            var ex = Assert.Throws<Exception>(() => Check.That(value).OnFailure<Exception>(message));

            Assert.AreEqual(ex.Message, message);
        }

        [Test, Category("Check")]
        [TestCase(true, "TestMessage")]
        public void Given_True_Assertion_When_Call_Check_Then_Not_Throw_Exception(bool value, string message)
        {
            Check.That(value).OnFailure<Exception>(message);
        }
    }
}