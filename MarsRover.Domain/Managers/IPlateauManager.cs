using MarsRover.Domain.Entities;

namespace MarsRover.Domain.Managers
{
    public interface IPlateauManager
    {
        void CreatePlateau(int x, int y);

        Plateau Get();
    }
}