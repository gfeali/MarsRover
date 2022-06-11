using MarsRover.Domain.Enums;
using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Validations;
using System;

namespace MarsRover.Domain.Entities
{
    public class Rover
    {
        public Rover(Plateau plateau, int x, int y, Direction direction)
        {
            Check.That(x.IsDefaultOrGreaterThanDefault()).OnFailure<DomainException>($"Rover X position must be positive");
            Check.That(y.IsDefaultOrGreaterThanDefault()).OnFailure<DomainException>($"Rover Y position must be positive");

            IsReadyForLanding(plateau, x, y);

            this.Plateau = plateau;
            Id = Guid.NewGuid();
            X = x;
            Y = y;
            Direction = direction;
        }

        public Guid Id { get; }
        public Plateau Plateau { get; }
        public Direction Direction { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        private static void IsReadyForLanding(Plateau plateau, int positionX, int positionY)
        {
            if (plateau is null)
            {
                throw new DomainException("");
            }

            plateau.WithinPlateau(positionX, positionY);
        }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.West,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                Direction.West => Direction.South,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.North => Direction.East,
                Direction.South => Direction.West,
                Direction.East => Direction.South,
                Direction.West => Direction.North,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    MoveNorth();
                    break;

                case Direction.East:
                    MoveEast();
                    break;

                case Direction.South:
                    MoveSouth();
                    break;

                case Direction.West:
                    MoveWest();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveSouth()
        {
            Plateau.WithinPlateau(X, Y - 1);
            Y--;
        }

        private void MoveWest()
        {
            Plateau.WithinPlateau(X - 1, Y);
            X--;
        }

        private void MoveEast()
        {
            Plateau.WithinPlateau(X + 1, Y);
            X++;
        }

        private void MoveNorth()
        {
            Plateau.WithinPlateau(X, Y + 1);
            Y++;
        }
    }
}