using MarsRover.Domain.Enums;
using MediatR;

namespace MarsRover.Application.Commands
{
    public class LandingRoverCommand : IRequest<string>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}