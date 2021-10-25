using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xakia.API.Client.Helpers;
using Xakia.API.Client.Services.Documents.Contracts;

namespace Xakia.API.Client
{
    public abstract class XakiaRequestBase
    {
        public XakiaRequestBase(XakiaClientOptions xakiaClientOptions, HttpMethod httpMethod, string path)
        {
            _ = xakiaClientOptions ?? throw new ArgumentNullException(nameof(xakiaClientOptions));

            HttpMethod = httpMethod;
            Path = path;
            XakiaClientOptions = xakiaClientOptions;
        }

       
        public HttpMethod HttpMethod { get;  }

        public string Path { get; }

        public HttpRequestMessage HttpRequestMessage { get; protected set; }

        public XakiaClientOptions XakiaClientOptions { get; }

        protected abstract HttpRequestMessage BuildRequestMessage();
    }

    public class XakiaRequest : XakiaRequestBase
    {
        private readonly AuthenticationResult _authenticationResult;
        private readonly GetQueryParams _params;
        private readonly object _payload;

        public XakiaRequest(XakiaClientOptions xakiaClientOptions, HttpMethod httpMethod, string path, 
                            AuthenticationResult authenticationResult, 
                            GetQueryParams @params = null) :
           base(xakiaClientOptions, httpMethod, path)
        {
            _authenticationResult = authenticationResult;
            _params = @params;
            HttpRequestMessage = BuildRequestMessage();
        }

        public XakiaRequest(XakiaClientOptions xakiaClientOptions, HttpMethod httpMethod, string path,
                    AuthenticationResult authenticationResult,
                    object payload) :
           base(xakiaClientOptions, httpMethod, path)
        {
            _payload = payload;
            _authenticationResult = authenticationResult;
            HttpRequestMessage = BuildRequestMessage();
        }
       

        protected override HttpRequestMessage BuildRequestMessage()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod, BuildUri(Path));

            httpRequest.Headers.Add("x-xa-tenant", XakiaClientOptions.TenantId.ToString());
            httpRequest.Headers.Add("x-xa-location", XakiaClientOptions.LocationId.ToString());
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue(_authenticationResult.TokenType, _authenticationResult.AccessToken);
            httpRequest.Headers.Add("Accept", "application/json");

            if (_payload != null)
            {
                var json = JsonConvert.SerializeObject(_payload);
                httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return httpRequest;
        }


        private string BuildUri(string path)
        {
            var pathUri = new StringBuilder(path);
            if ((base.HttpMethod != HttpMethod.Post) && (_params != null))
            {
                var keyValues = _params.ToKeyValue();
                var queryString = keyValues.CreateQueryString();

                if (queryString != null)
                {
                    pathUri.Append("?");
                    pathUri.Append(queryString);
                }

            }
            return pathUri.ToString();
        }
    }

    public class XakiaAuthenticationRequest : XakiaRequestBase
    {
        public XakiaAuthenticationRequest(XakiaClientOptions xakiaClientOptions, HttpMethod httpMethod, string path) :
            base (xakiaClientOptions, httpMethod, path)  
        {
            HttpRequestMessage = BuildRequestMessage();
        }

        protected override HttpRequestMessage BuildRequestMessage()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod, Path);
            
            var content = new List<string>();
            content.Add($"client_id={Uri.EscapeDataString(XakiaClientOptions.ClientId)}");
            content.Add($"client_secret={Uri.EscapeDataString(XakiaClientOptions.ClientSecret)}");
            content.Add($"grant_type=client_credentials");

            httpRequest.Content = new StringContent(string.Join("&", content));
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            return httpRequest;
        }

    }


    public static class XakiaRequestHelpers
    {
        /// <summary>
        /// Adds a Document to the <c>HttpRequestMessage</c>
        /// </summary>
        /// <param name="xakiaRequest">The <c>XakiaRequest</c> for the Request</param>
        /// <param name="documentContent">The document content</param>
        /// <param name="documentMetadata">The document metadata</param>
        public static void AddDocumentContent(this XakiaRequest xakiaRequest, DocumentContent documentContent, DocumentMetadata documentMetadata) 
        {
            var content = new MultipartFormDataContent();
            var bytes = ReadStream(documentContent.Stream);
            var fileContent = new ByteArrayContent(bytes, 0, bytes.Length);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MapContentType(documentContent.Filename));
            content.Add(fileContent, "Files", documentContent.Filename);

            if (documentMetadata != null)
            {
                content.Add(new StringContent(documentMetadata.EncryptionKeyId.ToString()), $"\"{nameof(documentMetadata.EncryptionKeyId)}\"");
                content.Add(new StringContent(documentMetadata.FileName), $"\"{nameof(documentMetadata.FileName)}\"");
                content.Add(new StringContent(documentMetadata.Description), $"\"{nameof(documentMetadata.Description)}\"");

                if (!string.IsNullOrEmpty(documentMetadata.FolderId))
                    content.Add(new StringContent(documentMetadata.FolderId), $"\"{nameof(documentMetadata.FolderId)}\"");

            }

            xakiaRequest.HttpRequestMessage.Content = content;
        }

        public static void AddDocumentContent(this XakiaRequest xakiaRequest, ICollection<DocumentContent> documentContents)
        {
            var content = new MultipartFormDataContent();
            foreach(var documentContent in documentContents)
            { 
                var bytes = ReadStream(documentContent.Stream);
                var fileContent = new ByteArrayContent(bytes, 0, bytes.Length);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MapContentType(documentContent.Filename));
                content.Add(fileContent, "Files", documentContent.Filename);
            }

            xakiaRequest.HttpRequestMessage.Content = content;
        }



        public static byte[] ReadStream(Stream input)
        {
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static string MapContentType(string fileName)
        {
            var contentTypeProvider = new FileExtensionContentTypeProvider();

            if (!contentTypeProvider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
