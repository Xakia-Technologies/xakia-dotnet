using System;
using System.Collections.Generic;

namespace Xakia.API.Client.Exceptions
{
    public class LegalInkakeRequestValidationException : Exception
    {
        public List<LegalInkakeRequestValidationEvent> LegalInkakeRequestValidationEvents { get; set; }

        public LegalInkakeRequestValidationException(string message, List<LegalInkakeRequestValidationEvent> @events) : base(message)
        {
            LegalInkakeRequestValidationEvents = events;
        }
    }
}

