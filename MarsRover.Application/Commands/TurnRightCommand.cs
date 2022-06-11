using MediatR;

namespace MarsRover.Application.Commands
{
    public class TurnRightCommand : IRequest
    {
        public string RoverId { get; set; }
    }
}