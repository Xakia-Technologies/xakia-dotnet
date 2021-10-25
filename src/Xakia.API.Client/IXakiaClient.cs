using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Services.Documents.Contracts;

namespace Xakia.API.Client
{
    public interface IXakiaClient
    {
        public XakiaClientOptions XakiaClientOptions { get;  }

        public AuthenticationResult Token { get; }


        public Task<T> RequestAsync<T>(HttpMethod method, string path, GetQueryParams @params, CancellationToken cancellationToken = default);

        public Task<T> RequestAsync<T>(HttpMethod method, string path, CancellationToken cancellationToken = default);

        public Task<T> RequestAsync<T, TContract>(HttpMethod method, string path, TContract payload, CancellationToken cancellationToken = default) where TContract : IContract;

        public Task RequestAsync<TContract>(HttpMethod method, string path, TContract payload, CancellationToken cancellationToken = default) where TContract : IContract;
        
        public Task RequestAsync<TContract>(HttpMethod method, string path, TContract payload, ICollection<DocumentContent> files, CancellationToken cancellationToken = default) where TContract : IContract;

        public Task<T> RequestAsyncWithFile<T>(HttpMethod method, string path, DocumentMetadata documentMetadata, DocumentContent documentContent, CancellationToken cancellationToken = default);
    }

    public interface IContract
    {

    }
}
