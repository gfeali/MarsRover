using MarsRover.Application.Commands;
using NUnit.Framework;
using System;
using System.Linq;

namespace MarsRover.UnitTest
{
    [TestFixture]
    internal class CommandHelperTests
    {
        [Test, Category("CommandHelper")]
        [TestCase(null)]
        [TestCase("")]
        public void Given_RoverId_Null_Or_Empty_When_PrepareCommands_Then_Throw_Exception(string value)
        {
            const string commands = "MMM";
            Assert.Throws<ArgumentNullException>(() =>
            {
                CommandHelper.PrepareCommands(value, commands);
            });
        }

        [Test, Category("CommandHelper")]
        [TestCase(null)]
        [TestCase("")]
        public void Given_Command_Null_Or_Empty_When_PrepareCommands_Then_Throw_Exception(string value)
        {
            var roverId = Guid.NewGuid();
            Assert.Throws<ArgumentNullException>(() =>
            {
                CommandHelper.PrepareCommands(roverId.ToString(), value);
            });
        }

        [Test, Category("CommandHelper")]
        public void Given_Invalid_Command_Null_Or_Empty_When_PrepareCommands_Then_Throw_Exception()
        {
            var roverId = Guid.NewGuid();
            const string commands = "MLRmlrxX";
            Assert.Throws<ArgumentException>(() =>
            {
                CommandHelper.PrepareCommands(roverId.ToString(), commands);
            });
        }

        [Test, Category("CommandHelper")]
        [TestCase("m", typeof(MoveCommand))]
        [TestCase("M", typeof(MoveCommand))]
        [TestCase("L", typeof(TurnLeftCommand))]
        [TestCase("l", typeof(TurnLeftCommand))]
        [TestCase("r", typeof(TurnRightCommand))]
        [TestCase("R", typeof(TurnRightCommand))]
        public void Given_Valid_Command_Null_Or_Empty_When_PrepareCommands_Then_Return_Commands(string value, Type expectedResult)
        {
            var roverId = Guid.NewGuid();

            var result = CommandHelper.PrepareCommands(roverId.ToString(), value).First();
            Assert.AreEqual(result.GetType(), expectedResult);
        }
    }
}