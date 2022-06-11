using MarsRover.Domain.Managers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.Commands
{
    public class TurnRightCommandHandler : IRequestHandler<TurnRightCommand>
    {
        private readonly IRoverManager _roverManager;

        public TurnRightCommandHandler(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public async Task<Unit> Handle(TurnRightCommand request, CancellationToken cancellationToken)
        {
            var rover = _roverManager.GetRover(request.RoverId);
            rover.TurnRight();
            return await Task.FromResult(Unit.Value);
        }
    }
}