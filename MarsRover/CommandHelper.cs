using MarsRover.Application.Commands;
using MarsRover.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public static class CommandHelper
    {
        private const string commandPattern = @"^(M|m|L|l|R|r)+$";

        public static List<IRequest> PrepareCommands(string roverId, string commands)
        {
            if (roverId.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(roverId), "Rover id can not be null or empty");
            }

            if (commands.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(commands), "Commands of rover can not be null or empty");
            }

            var requests = new List<IRequest>();
            commands.CheckCommands(commandPattern);
            foreach (var command in commands.ToUpper())
            {
                switch (command)
                {
                    case 'M':
                        requests.Add(new MoveCommand { RoverId = roverId });
                        break;

                    case 'L':
                        requests.Add(new TurnLeftCommand { RoverId = roverId });
                        break;

                    case 'R':
                        requests.Add(new TurnRightCommand { RoverId = roverId });
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return requests;
        }
    }
}