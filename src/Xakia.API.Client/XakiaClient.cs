using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xakia.API.Client.Helpers;
using Xakia.API.Client.Services.Documents.Contracts;

namespace Xakia.API.Client
{
    public class XakiaClient : IXakiaClient
    {
        
        private readonly HttpClient _httpClient;

        public XakiaClientOptions XakiaClientOptions { get; }

        public AuthenticationResult Token { get; private set; }


        /// <summary>
        /// Constructs a new instance of <c>XakiaClient</c> specifying <c>XakiaClientOptions</c>
        /// </summary>
        /// <param name="xakiaClientOptions">A XakiaClientOptions instance</param>
        public XakiaClient(XakiaClientOptions xakiaClientOptions) : this(xakiaClientOptions, new HttpClient()) { }

        /// <summary>
        /// Constructs a new instance of <c>XakiaClient</c> specifying <c>XakiaClientOptions</c>
        /// and <c>HttpClient</c>
        /// </summary>
        /// <param name="xakiaClientOptions">A XakiaClientOptions instance</param>
        /// <param name="httpClient">A HttpClient instance</param>
        public XakiaClient(XakiaClientOptions xakiaClientOptions, HttpClient httpClient)
        {            
            _ = xakiaClientOptions ?? throw new ArgumentNullException(nameof(xakiaClientOptions));
            _ = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            XakiaClientOptions = xakiaClientOptions;
            _httpClient = httpClient;
        }


        public async Task<T> RequestAsync<T>(HttpMethod method, string path, GetQueryParams @params, CancellationToken cancellationToken = default)
        {
            Token = await AuthenticateAsync();

            var xakiaRequestMessage = new XakiaRequest(XakiaClientOptions, method, path, Token, @params);
            return await ExecuteRequestAsync<T>(xakiaRequestMessage.HttpRequestMessage, cancellationToken);
        }

        public async Task<T> RequestAsync<T, TContract>(HttpMethod method, string path, TContract payload, CancellationToken cancellationToken = default)
            where TContract : IContract
        {
            Token = await AuthenticateAsync();

            var xakiaRequestMessage = new XakiaRequest(XakiaClientOptions, method, path, Token, payload);
            return await ExecuteRequestAsync<T>(xakiaRequestMessage.HttpRequestMessage, cancellationToken);
        }

        public async Task<T> RequestAsyncWithFile<T>(HttpMethod method, string path, DocumentMetadata documentMetadata, DocumentContent documentContent, CancellationToken cancellationToken = default) 
        {
            Token = await AuthenticateAsync();

            var xakiaRequestMessage = new XakiaRequest(XakiaClientOptions, method, path, Token, payload: null);
            xakiaRequestMessage.AddFileContent(documentContent, documentMetadata);
            return await ExecuteRequestAsync<T>(xakiaRequestMessage.HttpRequestMessage, cancellationToken);
        }

        public async Task<T> RequestAsync<T>(HttpMethod method, string path, CancellationToken cancellationToken = default)
        {
            Token = await AuthenticateAsync();

            var xakiaRequestMessage = new XakiaRequest(XakiaClientOptions, method, path, Token);
            return await ExecuteRequestAsync<T>(xakiaRequestMessage.HttpRequestMessage, cancellationToken);
        }


        private async Task<AuthenticationResult> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            if (Token == null || !Token.IsValid())
            {
                var xakiaRequestMessage = new XakiaAuthenticationRequest(XakiaClientOptions, HttpMethod.Post, XakiaClientOptions.GetTokenUrl());
                Token = await ExecuteRequestAsync<AuthenticationResult>(xakiaRequestMessage.HttpRequestMessage, cancellationToken);
            }

            return Token;
        }


        private async Task<T> ExecuteRequestAsync<T>(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
        {
            var result = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            result.EnsureSuccessStatusCode();
            var resultBody = await result.Content.ReadAsStringAsync();
            return resultBody.FromJson<T>();
        }

    }
}
