using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace LtiLibrary.Core.OAuth
{
    public interface IOAuthRequest : IBasicRequest
    {
        string BodyHash { get; set; }
        string CallBack { get; set; }
        string ConsumerKey { get; set; }
        string CustomParameters { get; set; }
        string Nonce { get; set; }
        [NotMapped]
        string Signature { get; set; }
        string SignatureMethod { get; set; }
        Int64 Timestamp { get; set; }
        [NotMapped]
        DateTime TimestampAsDateTime { get; set; }
        string Version { get; set; }
    }
}
