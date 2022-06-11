using System;

namespace MarsRover.Infrastructure.Validations
{
    public sealed class CheckConstraint
    {
        private readonly bool _assertion;

        public CheckConstraint(bool assertion)
        {
            _assertion = assertion;
        }

        public void OnFailure<T>(string message) where T : System.Exception
        {
            if (_assertion) return;
            throw ((T)Activator.CreateInstance(typeof(T), message))!;
        }
    }

    public sealed class Check
    {
        public static CheckConstraint That(bool assertion = false)
        {
            return new CheckConstraint(assertion);
        }
    }
}