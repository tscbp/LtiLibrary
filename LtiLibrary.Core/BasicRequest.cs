using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LtiLibrary.Core
{
    public class BasicRequest : IBasicRequest
    {
        public BasicRequest()
        {
            Parameters = new NameValueCollection();
        }

        /// <summary>
        /// The HTTP Method of the request
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// All the POST parameters in the request
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public NameValueCollection Parameters
        {
            get;
        }

        /// <summary>
        /// The resource URL.
        /// </summary>
        [NotMapped]
        public Uri Url { get; set; }
    }
}
