﻿using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using LtiLibrary.Core.Common;

namespace LtiLibrary.Core.OAuth
{
    public class OAuthRequest : BasicRequest, IOAuthRequest
    {
        /// <summary>
        /// The OAuth body hash.
        /// </summary>
        public string BodyHash
        {
            get
            {
                return Parameters[OAuthConstants.BodyHashParameter];
            }
            set
            {
                Parameters[OAuthConstants.BodyHashParameter] = value;
            }
        }

        public string CallBack
        {
            get
            {
                return Parameters[OAuthConstants.CallbackParameter];
            }
            set
            {
                Parameters[OAuthConstants.CallbackParameter] = value;
            }
        }

        /// <summary>
        /// OAuth consumer key
        /// </summary>
        public string ConsumerKey
        {
            get
            {
                return Parameters[OAuthConstants.ConsumerKeyParameter];
            }
            set
            {
                Parameters[OAuthConstants.ConsumerKeyParameter] = value;
            }
        }

        /// <summary>
        /// The custom_ and ext_ parameters in Querystring format suitable for saving in the database.
        /// </summary>
        public string CustomParameters
        {
            get
            {
                var customParameters = new UrlEncodingParser("");
                foreach (var key in Parameters.AllKeys)
                {
                    if (key.StartsWith("custom_") || key.StartsWith("ext_"))
                    {
                        customParameters.Add(key, Parameters[key]);
                    }
                }

                return customParameters.Count == 0 ? null : customParameters.ToString();
            }
            set
            {
                var customParameters = new UrlEncodingParser(value);
                foreach (var key in customParameters.AllKeys)
                {
                    if (key.StartsWith("custom_") || key.StartsWith("_ext"))
                    {
                        Parameters[key] = customParameters[key];
                    }
                }
            }
        }

        /// <summary>
        /// OAuth nonce
        /// </summary>
        public string Nonce
        {
            get
            {
                return Parameters[OAuthConstants.NonceParameter];
            }
            set
            {
                Parameters[OAuthConstants.NonceParameter] = value;
            }
        }

        /// <summary>
        /// OAuth signature
        /// </summary>
        [NotMapped]
        public string Signature
        {
            get
            {
                return Parameters[OAuthConstants.SignatureParameter];
            }
            set
            {
                Parameters[OAuthConstants.SignatureParameter] = value;
            }
        }

        /// <summary>
        /// The OAuth signature method.
        /// </summary>
        public string SignatureMethod
        {
            get
            {
                return Parameters[OAuthConstants.SignatureMethodParameter];
            }
            set
            {
                Parameters[OAuthConstants.SignatureMethodParameter] = value;
            }
        }

        /// <summary>
        /// OAuth timestamp (number of seconds since 1/1/1970)
        /// </summary>
        public Int64 Timestamp
        {
            get
            {
                return Convert.ToInt64(Parameters[OAuthConstants.TimestampParameter]);
            }
            set
            {
                Parameters[OAuthConstants.TimestampParameter] = Convert.ToString(value);
            }
        }

        /// <summary>
        /// Convenience property to get and set the OAuth Timestamp using DateTime
        /// </summary>
        [NotMapped]
        public DateTime TimestampAsDateTime
        {
            get
            {
                return OAuthConstants.Epoch.AddSeconds(Timestamp);
            }
            set
            {
                Timestamp = Convert.ToInt64((value - OAuthConstants.Epoch).TotalSeconds);                
            }
        }

        /// <summary>
        /// The OAuth version.
        /// </summary>
        public string Version
        {
            get
            {
                return Parameters[OAuthConstants.VersionParameter];
            }
            set
            {
                Parameters[OAuthConstants.VersionParameter] = value;
            }
        }

        /// <summary>
        /// Calculate the OAuth Signature for this request using the parameters in the request.
        /// </summary>
        /// <param name="consumerSecret">The OAuth Consumer Secret to use.</param>
        /// <returns>The calculated OAuth Signature.</returns>
        /// <remarks>This is typically used by Tool Providers to verify the incoming request signature.</remarks>
        public string GenerateSignature(string consumerSecret)
        {
            var parameters = new NameValueCollection(Parameters);
            return GenerateSignature(parameters, consumerSecret);
        }

        /// <summary>
        /// Calculate the OAuth Signature for this request using custom parameters.
        /// </summary>
        /// <param name="parameters">The set of parameters to be included in the signature.</param>
        /// <param name="consumerSecret">The OAuth Consumer Secret to use.</param>
        /// <returns>The calculated OAuth Signature.</returns>
        /// <remarks>
        /// This is typically used by Tool Consumers that perform custom parameter substitution prior 
        /// to signing the request.
        /// </remarks>
        public string GenerateSignature(NameValueCollection parameters, string consumerSecret)
        {
            var signature = OAuthUtility.GenerateSignature(HttpMethod, Url, parameters, consumerSecret);
            return signature;
        }
    }
}
