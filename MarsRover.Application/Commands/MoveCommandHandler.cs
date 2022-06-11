using MarsRover.Domain.Managers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.Commands
{
    public class MoveCommandHandler : IRequestHandler<MoveCommand>
    {
        private readonly IRoverManager _roverManager;

        public MoveCommandHandler(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public async Task<Unit> Handle(MoveCommand request, CancellationToken cancellationToken)
        {
            var rover = _roverManager.GetRover(request.RoverId);
            rover.Move();
            return await Task.FromResult(Unit.Value);
        }
    }
}