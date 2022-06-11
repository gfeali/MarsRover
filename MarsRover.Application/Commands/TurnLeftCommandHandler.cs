using MarsRover.Domain.Managers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.Commands
{
    public class TurnLeftCommandHandler : IRequestHandler<TurnLeftCommand>
    {
        private readonly IRoverManager _roverManager;

        public TurnLeftCommandHandler(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public async Task<Unit> Handle(TurnLeftCommand request, CancellationToken cancellationToken)
        {
            var rover = _roverManager.GetRover(request.RoverId);
            rover.TurnLeft();
            return await Task.FromResult(Unit.Value);
        }
    }
}