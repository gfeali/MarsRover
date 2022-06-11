using MarsRover.Application.Dtos;
using MarsRover.Domain.Managers;
using System;

namespace MarsRover.Application.Queries
{
    public class RoverQueries : IRoverQueries
    {
        private readonly IRoverManager _roverManager;

        public RoverQueries(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public RoverDto GetRoverById(string id)
        {
            var rover = _roverManager.GetRover(id);
            if (rover is null)
            {
                throw new ArgumentNullException(id, nameof(rover));
            }
            return new RoverDto
            {
                X = rover.X,
                Y = rover.Y,
                Direction = rover.Direction.ToString()
            };
        }
    }
}