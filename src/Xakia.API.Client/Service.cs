using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xakia.API.Client.Exceptions;

namespace Xakia.API.Client
{
    public abstract class Service
    {
        protected IXakiaClient _xakiaClient;

        public Service(IXakiaClient xakiaClient)
        {
            _ = xakiaClient ?? throw new ArgumentNullException(nameof(xakiaClient));
            _xakiaClient = xakiaClient;
        }

        public abstract string BasePath { get;  }


        public virtual string GetInstanceUrl(string path, string path2, params object[] args)
        {
            if (!EnsurePath(path2)) throw new InvalidPathException(nameof(path2), "Path must start with a / character");

            return GetInstanceUrl(path + path2, args);
        }

        public virtual string GetInstanceUrl(string path, params object[] args)
        {
            var instancePath = string.Format(path, args);
            return GetUrl(instancePath);
        }

        public virtual string GetUrl(string path)
        {
            if (!EnsurePath(path)) throw new InvalidPathException(nameof(path), "Path must start with a / character");

            var uriBuider = new UriBuilder(_xakiaClient.XakiaClientOptions.ApiEndpoint);
            uriBuider.Path = path;
            return uriBuider.Uri.AbsoluteUri;
        }

        public virtual string GetUrl(string path, string path2)
        {
            if (!EnsurePath(path2)) throw new InvalidPathException(nameof(path2), "Path must start with a / character");

            return GetUrl(path + path2);
        }


        private bool EnsurePath(string path)
        {
            _ = path ?? throw new ArgumentNullException(nameof(path));

            return path.StartsWith("/");
        }
    }
}
