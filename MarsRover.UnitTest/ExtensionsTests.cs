using MarsRover.Infrastructure;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    [TestFixture]
    internal class ExtensionsTests
    {
        [Test, Category("IsNullOrEmpty")]
        [TestCase("")]
        [TestCase(null)]
        public void Given_Null_Or_Empty_String_When_Call_IsNullOrEmpty_Then_Return_True(string value)
        {
            Assert.IsTrue(value.IsNullOrEmpty());
        }

        [Test, Category("IsNullOrEmpty")]
        [TestCase("1234567")]
        [TestCase("345sdfsa54")]
        public void Given_Not_Null_Or_Empty_String_When_Call_IsNullOrEmpty_Then_Return_False(string value)
        {
            Assert.IsFalse(value.IsNullOrEmpty());
        }

        [Test, Category("IsGreaterThanDefault")]
        [TestCase(default(int))]
        [TestCase(-1)]
        public void Given_Default_Or_Negative_Int_When_Call_IsGreaterThanDefault_Then_Return_False(int value)
        {
            Assert.IsFalse(value.IsGreaterThanDefault());
        }

        [Test, Category("IsGreaterThanDefault")]
        [TestCase(5)]
        [TestCase(17)]
        public void Given_Greater_Than_Default_Int_When_Call_IsGreaterThanDefault_Then_Return_True(int value)
        {
            Assert.IsTrue(value.IsGreaterThanDefault());
        }

        [Test, Category("IsDefaultOrGreaterThanDefault")]
        [TestCase(-1)]
        public void Given_Negative_Int_When_Call_IsDefaultOrGreaterThanDefault_Then_Return_False(int value)
        {
            Assert.IsFalse(value.IsDefaultOrGreaterThanDefault());
        }

        [Test, Category("IsDefaultOrGreaterThanDefault")]
        [TestCase(0)]
        [TestCase(17)]
        public void Given_Default_Or_Greater_Than_Default_Int_When_Call_IsDefaultOrGreaterThanDefault_Then_Return_True(int value)
        {
            Assert.IsTrue(value.IsDefaultOrGreaterThanDefault());
        }
    }
}