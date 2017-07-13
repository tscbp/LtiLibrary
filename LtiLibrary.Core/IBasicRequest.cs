using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace LtiLibrary.Core
{
    public interface IBasicRequest
    {
        string HttpMethod { get; set; }
        [NotMapped]
        NameValueCollection Parameters { get; }
        [NotMapped]
        Uri Url { get; set; }
    }
}
