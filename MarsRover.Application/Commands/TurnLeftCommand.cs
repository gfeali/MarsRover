using MediatR;

namespace MarsRover.Application.Commands
{
    public class TurnLeftCommand : IRequest
    {
        public string RoverId { get; set; }
    }
}