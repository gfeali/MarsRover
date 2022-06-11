namespace MarsRover.Domain
{
    public class DomainException : System.Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}