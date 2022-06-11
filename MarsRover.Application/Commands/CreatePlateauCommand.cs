using MediatR;

namespace MarsRover.Application.Commands
{
    public class CreatePlateauCommand : IRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}