using MarsRover.Domain.Managers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.Commands
{
    public class LandingRoverCommandHandler : IRequestHandler<LandingRoverCommand, string>
    {
        private readonly IRoverManager _roverManager;

        public LandingRoverCommandHandler(IRoverManager roverManager)
        {
            _roverManager = roverManager;
        }

        public async Task<string> Handle(LandingRoverCommand request, CancellationToken cancellationToken)
        {
            var roverId = _roverManager.LandingRover(request.X, request.Y, request.Direction);

            return await Task.FromResult(roverId);
        }
    }
}