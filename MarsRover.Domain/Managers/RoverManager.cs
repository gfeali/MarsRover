using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Domain.Managers
{
    public class RoverManager : IRoverManager
    {
        private readonly IPlateauManager _plateauManager;

        private readonly List<Rover> _rovers = new();

        public RoverManager(IPlateauManager plateauManager)
        {
            _plateauManager = plateauManager;
        }

        public string LandingRover(int x, int y, Direction direction)
        {
            var rover = new Rover(_plateauManager.Get(), x, y, direction);
            _rovers.Add(rover);
            return rover.Id.ToString();
        }

        public Rover GetRover(string roverId)
        {
            return _rovers.First(x => x.Id.Equals(Guid.Parse(roverId)));
        }
    }
}