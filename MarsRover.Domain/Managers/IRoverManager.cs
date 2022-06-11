using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Managers
{
    public interface IRoverManager
    {
        string LandingRover(int x, int y, Direction direction);

        Rover GetRover(string roverId);
    }
}