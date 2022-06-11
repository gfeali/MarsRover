namespace MarsRover.Application.Dtos
{
    public class RoverDto
    {
        public RoverDto(int x, int y, string direction) : this()
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public RoverDto()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }

        public override string ToString()
        {
            return $"X:{X} Y:{Y} {Direction}";
        }
    }
}