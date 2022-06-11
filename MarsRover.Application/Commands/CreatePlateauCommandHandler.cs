using MarsRover.Domain.Managers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.Commands
{
    public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand>
    {
        private readonly IPlateauManager _plateauManager;

        public CreatePlateauCommandHandler(IPlateauManager plateauManager)
        {
            _plateauManager = plateauManager;
        }

        public async Task<Unit> Handle(CreatePlateauCommand request, CancellationToken cancellationToken)
        {
            _plateauManager.CreatePlateau(request.X, request.Y);

            return await Task.FromResult(Unit.Value);
        }
    }
}