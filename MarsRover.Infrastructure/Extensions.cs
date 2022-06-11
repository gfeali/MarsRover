using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.Infrastructure
{
    public static class Extensions
    {
        public static void CheckCommands(this string commands, string pattern)
        {
            if (commands.Any(move => !Regex.IsMatch(move.ToString(), pattern)))
            {
                throw new ArgumentException("Please enter valid commands");
            }
        }

        public static bool IsGreaterThanDefault(this int value)
        {
            return value > default(int);
        }

        public static bool IsDefaultOrGreaterThanDefault(this int value)
        {
            return value >= default(int);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}