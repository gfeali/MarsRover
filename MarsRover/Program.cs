using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Domain.Enums;
using MarsRover.Domain.Managers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var mediator = host.Services.GetService<IMediator>();
            var queryService = host.Services.GetService<IRoverQueries>();

            await mediator.Send(new CreatePlateauCommand { X = 5, Y = 5 });

            var roverOneId = await mediator.Send(new LandingRoverCommand { X = 1, Y = 2, Direction = Direction.North });

            foreach (var command in CommandHelper.PrepareCommands(roverOneId, "LMLMLMLMM"))
            {
                await mediator.Send(command);
            }

            var roverOne = queryService.GetRoverById(roverOneId);

            Console.WriteLine($"Rover One {roverOne.ToString()}");

            var roverTwoId = await mediator.Send(new LandingRoverCommand { X = 3, Y = 3, Direction = Direction.East });

            foreach (var command in CommandHelper.PrepareCommands(roverTwoId, "MMRMMRMRRM"))
            {
                await mediator.Send(command);
            }

            var roverTwo = queryService.GetRoverById(roverTwoId);

            Console.WriteLine($"Rover Two {roverTwo.ToString()}");

            Console.Read();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IPlateauManager, PlateauManager>();
                    services.AddSingleton<IRoverManager, RoverManager>();
                    services.AddTransient<IRoverQueries, RoverQueries>();
                    services.AddMediatR(typeof(CreatePlateauCommand));
                    services.AddMediatR(typeof(LandingRoverCommand));
                    services.AddMediatR(typeof(MoveCommand));
                    services.AddMediatR(typeof(TurnLeftCommand));
                    services.AddMediatR(typeof(TurnRightCommand));
                });

            return hostBuilder;
        }
    }
}