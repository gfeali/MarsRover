using MarsRover.Domain;
using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MarsRover.UnitTest
{
    [TestFixture]
    internal class RoverTests
    {
        private Plateau _createdValidPlateau;

        [SetUp]
        public async Task SetUp()
        {
            _createdValidPlateau = new Plateau(5, 5);
        }

        [Test, Category("Rover")]
        [TestCase(-2, 0)]
        [TestCase(-1, 1)]
        public void Given_Valid_Plateau_And_Negative_X_When_Create_Rover_Then_Throw_Exception(int x, int y)
        {
            Assert.Throws<DomainException>(() =>
            {
                var rover = new Rover(_createdValidPlateau, x, y, Direction.East);
            });
        }

        [Test, Category("Rover")]
        [TestCase(3, -4)]
        [TestCase(2, -1)]
        public void Given_Valid_Plateau_And_Negative_Y_When_Create_Rover_Then_Throw_Exception(int x, int y)
        {
            Assert.Throws<DomainException>(() =>
            {
                var rover = new Rover(_createdValidPlateau, x, y, Direction.East);
            });
        }

        [Test, Category("Rover")]
        [TestCase(1, 2)]
        public void Given_Null_Plateau_And_Valid_X_Y_When_Create_Rover_Then_Throw_Exception(int x, int y)
        {
            Assert.Throws<DomainException>(() =>
            {
                var rover = new Rover(null, x, y, Direction.East);
            });
        }

        [Test, Category("Rover")]
        [TestCase(7, 9)]
        public void Given_Valid_Plateau_And_Rover_Position_Is_Not_Within_The_Plateau_When_Create_Rover_Then_Throw_Exception(int x, int y)
        {
            Assert.Throws<DomainException>(() =>
            {
                var rover = new Rover(_createdValidPlateau, x, y, Direction.East);
            });
        }

        [Test, Category("Rover")]
        [TestCase(2, 3)]
        public void Given_Valid_Plateau_And_Valid_Rover_Position_When_Create_Rover_Then_Create_Rover(int x, int y)
        {
            var rover = new Rover(_createdValidPlateau, x, y, Direction.East);
            Assert.IsNotNull(rover);
        }

        [Test, Category("Rover")]
        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.East, Direction.North)]
        [TestCase(Direction.West, Direction.South)]
        public void Given_Rover_When_Call_Turn_Left_Then_Rover_Change_Direction(Direction direction, Direction expectedResult)
        {
            var rover = new Rover(_createdValidPlateau, 2, 3, direction);
            rover.TurnLeft();
            Assert.AreEqual(rover.Direction, expectedResult);
        }

        [Test, Category("Rover")]
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.West, Direction.North)]
        public void Given_Rover_When_Call_Turn_Right_Then_Rover_Change_Direction(Direction direction, Direction expectedResult)
        {
            var rover = new Rover(_createdValidPlateau, 2, 3, direction);
            rover.TurnRight();
            Assert.AreEqual(rover.Direction, expectedResult);
        }

        [Test, Category("Rover")]
        [TestCase(Direction.North)]
        [TestCase(Direction.South)]
        [TestCase(Direction.East)]
        [TestCase(Direction.West)]
        public void Given_Rover_When_Call_Move_Then_Rover_Move(Direction direction)
        {
            const int x = 2;
            const int y = 3;
            var rover = new Rover(_createdValidPlateau, x, y, direction);
            switch (direction)
            {
                case Direction.North:
                    rover.Move();
                    Assert.AreEqual(y + 1, rover.Y);
                    break;

                case Direction.East:
                    rover.Move();
                    Assert.AreEqual(x + 1, rover.X);
                    break;

                case Direction.South:
                    rover.Move();
                    Assert.AreEqual(y - 1, rover.Y);
                    break;

                case Direction.West:
                    rover.Move();
                    Assert.AreEqual(x - 1, rover.X);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}