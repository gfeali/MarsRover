using MarsRover.Application.Dtos;

namespace MarsRover.Application.Queries
{
    public interface IRoverQueries
    {
        RoverDto GetRoverById(string id);
    }
}