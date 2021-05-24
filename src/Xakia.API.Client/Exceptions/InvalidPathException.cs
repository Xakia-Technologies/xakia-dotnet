using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Exceptions
{
    public class InvalidPathException : Exception
    {
        public  string Path { get; set; }

        public InvalidPathException(string path, string message) : base(message)
        {
            Path = path;
        }
    }
}
