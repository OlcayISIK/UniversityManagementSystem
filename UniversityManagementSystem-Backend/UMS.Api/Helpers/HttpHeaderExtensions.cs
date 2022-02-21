using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UMS.Core.Enums;

namespace UMS.Api.Helpers
{
    public static class HttpHeaderExtensions
    {
        private const string LanguageHeaderKey = "Language";

        /// <summary>
        /// Returns the requested language, if it is present in the request headers. Returns a default value if it does not exist.
        /// </summary>
        public static Language GetRequestedLanguage(this HttpRequest httpRequest)
        {
            var currentLanguage = Language.English;

            var success = httpRequest.Headers.TryGetValue(LanguageHeaderKey, out var languageValue);
            if (success)
            {
                Enum.TryParse(languageValue, out currentLanguage);
            }

            return currentLanguage;
        }
    }
}
