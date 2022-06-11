using MarsRover.Infrastructure;
using MarsRover.Infrastructure.Validations;

namespace MarsRover.Domain.Entities
{
    public class Plateau
    {
        private const int Origin = default;

        public Plateau(int maxX, int maxY)
        {
            Check.That(maxX.IsGreaterThanDefault()).OnFailure<DomainException>($"Plateau coordinate X must be greater than {default(int)}");
            Check.That(maxY.IsGreaterThanDefault()).OnFailure<DomainException>($"Plateau coordinate Y must be greater than {default(int)}");

            MaxX = maxX;
            MaxY = maxY;
            MinX = Origin;
            MinY = Origin;
        }

        public int MaxX { get; }
        public int MaxY { get; }
        public int MinX { get; }
        public int MinY { get; }

        public void WithinPlateau(int x, int y)
        {
            if (!(MaxX >= x && x >= MinX && MaxY >= y && y >= MinY))
            {
                throw new DomainException("Coordinates are not within the plateau");
            }
        }
    }
}