using MarsRover.Domain.Entities;

namespace MarsRover.Domain.Managers
{
    public class PlateauManager : IPlateauManager
    {
        private Plateau _plateau;

        public void CreatePlateau(int x, int y)
        {
            _plateau = new Plateau(x, y);
        }

        public Plateau Get()
        {
            return _plateau;
        }
    }
}