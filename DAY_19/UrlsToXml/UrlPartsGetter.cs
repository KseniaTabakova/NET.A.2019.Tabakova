using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace UrlsToXml
{
    public class UrlPartsGetter
    {
        private readonly Uri url;
      
        public UrlPartsGetter(string inputUrl)
        {
            if (!Uri.IsWellFormedUriString(inputUrl, UriKind.Absolute)) {throw new ArgumentException("Invalid URL.");}
            url = new Uri(inputUrl);
        }

        public string GetHost()
        {
            return url.Host;
        }
          
        public IEnumerable<string> GetUriParts()
        {
            foreach (var part in url.Segments)
            {
                if (part == "/"){continue;}

                string newPart = part.Replace("/", "");
                yield return newPart;
            }
        }

        public Dictionary<string, string> GetParameters()
        {
            string query = url.Query;

            NameValueCollection parameters = HttpUtility.ParseQueryString(query);

            if (parameters.AllKeys.Any(key => key == null))
            {
                throw new ArgumentException("Parameter key cannot be null.");
            }
            return parameters.AllKeys.ToDictionary(key => key, key => parameters[key]);
        }
    }
}
