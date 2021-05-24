using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Xakia.API.Client.Helpers
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert an object to a Dictionary of key value pairs
        /// </summary>
        /// <param name="metaToken"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                            .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                jValue?.ToString("o", CultureInfo.InvariantCulture) :
                jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }



        /// <summary>Creates the HTTP query string for a collection of name/value pairs.</summary>
        /// <param name="nameValueCollection">The collection of name/value pairs</param>
        /// <returns>The query string.</returns>
        public static string CreateQueryString(this IDictionary<string, string> nameValueCollection)
        {
            return string.Join("&",
                nameValueCollection.Select(kvp => $"{UrlEncode(kvp.Key)}={UrlEncode(kvp.Value)}"));
        }


        /// <summary>URL-encodes a string.</summary>
        /// <param name="value">The string to URL-encode.</param>
        /// <returns>The URL-encoded string.</returns>
        private static string UrlEncode(string value)
        {
            return WebUtility.UrlEncode(value);
        }



    }
}
