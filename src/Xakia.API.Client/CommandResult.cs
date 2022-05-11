using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client
{
    public class CommandResult
    {
        public class BuildersPendingWork
        {
            /// <summary>
            /// The total number of events raised by commands. 
            /// Note that there may be events raised included in this count
            /// that do not impact any builder.
            /// </summary>
            public int TotalEventsRaised { get; set; }

            

            /// <summary>
            /// Builders pending work. 
            /// </summary>
            public IList<Builder> Builders { get; set; } = new List<Builder>();

            
        }
        public class Builder
        {
            /// <summary>
            /// Name of the builder.
            /// </summary>
            public string BuilderName { get; set; }

            /// <summary>
            /// How many events are pending on this builder as a result of the command that was executed.
            /// </summary>
            public int EventCount { get; set; }
        }
    }
}
