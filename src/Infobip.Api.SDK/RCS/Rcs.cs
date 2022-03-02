using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.RCS.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS
{
    internal class RcsClient : IRcs
    {
        private readonly HttpClient _client;

        public RcsClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<RcsMessageResponse> SendRcsMessage(SendRcsMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "ott/rcs/1/message"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<RcsMessageResponse>();
                }
            }
        }

        public async Task<RcsMessageResponse> SendBulkRcsMessages(SendRscBulkMessagesRequest requestPayload, CancellationToken cancellationToken)
        {
            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "ott/rcs/1/message/bulk"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<RcsMessageResponse>();
                }
            }
        }
    }
}