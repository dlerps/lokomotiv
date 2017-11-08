using System;

namespace Lokomotiv
{
    public class LokomotivException : Exception
    {
        public LokomotivException(string message) : base(message)
        {
        }

        public LokomotivException(string message, Exception cause) : base(message, cause)
        {
        }
    }
}