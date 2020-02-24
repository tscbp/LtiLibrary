﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LtiLibrary.NetCore.Common;
using LtiLibrary.NetCore.Extensions;
using LtiLibrary.NetCore.Lti.v2;

namespace LtiLibrary.NetCore.Clients
{
    /// <summary>
    /// Helper class for Tool Providers requesting a <see cref="ToolConsumerProfile"/> from a Tool Consumer.
    /// </summary>
    public static class ToolConsumerProfileClient
    {
        /// <summary>
        /// Get a ToolConsumerProfile from the service endpoint.
        /// </summary>
        /// <param name="client">The HttpClient to use for the request.</param>
        /// <param name="serviceUrl">The full URL of the ToolConsumerProfile service.</param>
        /// <returns>A <see cref="ClientResponse"/> with the <see cref="ToolConsumerProfile"/> successful.</returns>
        public static async Task<ClientResponse<ToolConsumerProfile>> GetToolConsumerProfileAsync(HttpClient client, string serviceUrl)
        {
            var profileResponse = new ClientResponse<ToolConsumerProfile>();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, serviceUrl);
            webRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(LtiConstants.LtiToolConsumerProfileMediaType));
            using (var response = await client.SendAsync(webRequest).ConfigureAwait(false))
            {
                profileResponse.StatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    profileResponse.Response =
                        await response.Content.ReadJsonAsObjectAsync<ToolConsumerProfile>().ConfigureAwait(false);
                }
#if DEBUG
                profileResponse.HttpRequest = await response.RequestMessage.ToFormattedRequestStringAsync()
                    .ConfigureAwait(false);
                profileResponse.HttpResponse = await response.ToFormattedResponseStringAsync()
                    .ConfigureAwait(false);
#endif
            }
            return profileResponse;
        }
    }
}
