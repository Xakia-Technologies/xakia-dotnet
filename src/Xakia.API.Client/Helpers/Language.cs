using System;
using System.Collections.Generic;
using System.Text;

namespace Xakia.API.Client.Helpers
{
    public class Language
    {
        protected Language(){ }

        public static List<string> Languages { get; set; } = new List<string>()
        {
            English, Japanese, French, Danish, Dutch, Portuguese, Spanish
        };

        public const string English = "en-US";
        public const string Japanese = "jp-JP";
        public const string French = "fr-FR";
        public const string Dutch = "nl-NL";
        public const string Portuguese = "pt-PT";
        public const string Spanish = "es-ES";
        public const string Danish = "da-DK";
    }
}
