using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Exceptions
{
    public class RequestValidationException : Exception
    {
        public IEnumerable<RequestValidationEvent> RequestValidationEvents { get; set; }

        public RequestValidationException(string message, IEnumerable<RequestValidationEvent> @events) : base(message)
        {
            RequestValidationEvents = events;
        }
    }
}

