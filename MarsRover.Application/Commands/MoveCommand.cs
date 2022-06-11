using MediatR;

namespace MarsRover.Application.Commands
{
    public class MoveCommand : IRequest
    {
        public string RoverId { get; set; }
    }
}