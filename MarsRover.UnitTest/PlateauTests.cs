using MarsRover.Domain;
using MarsRover.Domain.Entities;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MarsRover.UnitTest
{
    [TestFixture]
    internal class PlateauTests
    {
        private Plateau _plateau;

        private Plateau _createdValidPlateau;

        [SetUp]
        public async Task SetUp()
        {
            _createdValidPlateau = new Plateau(5, 5);
        }

        [Test, Category("Plateau")]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void Given_Negative_Or_Default_MaxX_When_Create_Plateau_Then_Throw_Exception(int maxX, int maxY)
        {
            Assert.Throws<DomainException>(() => _plateau = new Plateau(maxX, maxY));
        }

        [Test, Category("Plateau")]
        [TestCase(1, 0)]
        [TestCase(2, -1)]
        public void Given_Negative_Or_Default_MaxY_When_Create_Plateau_Then_Throw_Exception(int maxX, int maxY)
        {
            Assert.Throws<DomainException>(() => _plateau = new Plateau(maxX, maxY));
        }

        [Test, Category("Plateau")]
        [TestCase(5, 5)]
        public void Given_Valid_MaxX_And_MaxY_When_Create_Plateau_Then_Create_Plateau(int maxX, int maxY)
        {
            _plateau = new Plateau(maxX, maxY);
            Assert.IsNotNull(_plateau);
            Assert.AreEqual(_plateau.MaxX, maxX);
            Assert.AreEqual(_plateau.MaxY, maxY);
        }

        [Test, Category("Plateau")]
        [TestCase(2, 3)]
        [TestCase(4, 5)]
        public void Given_Coordinates_Are_Within_The_Plateau_When_Call_WithinPlateau_Then_Not_Throw_Exception(int maxX, int maxY)
        {
            _createdValidPlateau.WithinPlateau(maxX, maxY);
        }

        [Test, Category("Plateau")]
        [TestCase(6, 7)]
        [TestCase(7, 9)]
        public void Given_Coordinates_Are_Not_Within_The_Plateau_When_Call_WithinPlateau_Then_Throw_Exception(int maxX, int maxY)
        {
            Assert.Throws<DomainException>(() => _createdValidPlateau.WithinPlateau(maxX, maxY));
        }
    }
}