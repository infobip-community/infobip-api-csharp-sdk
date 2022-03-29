using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.MMS.Models;
using Infobip.Api.SDK.Validation;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS
{
    /// <inheritdoc />
    internal class MmsEndpoints : IMmsEndpoints
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public MmsEndpoints(HttpClient client, IRequestValidator requestValidator)
        {
            _client = client;
            _requestValidator = requestValidator;
        }

        /// <inheritdoc />
        public async Task<SendMmsMessageResponse> SendSingleMmsMessage(SendMmsMessageRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var multipartFormDataContent = new MultipartFormDataContent
            {
                { new StringContent(JsonConvert.SerializeObject(requestPayload.Head), Encoding.UTF8, "application/json"), "head" } // Add head as object <json>
            };

            // Add text as string <text>
            if (!string.IsNullOrEmpty(requestPayload.Text))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Text), "text");
            }

            // Add media as <binary,byte>
            if (requestPayload.Media != null)
            {
                var mediaContent = new StreamContent(requestPayload.Media);
                mediaContent.Headers.Add("Content-Type", "application/octet-stream");
                multipartFormDataContent.Add(mediaContent, "media", "media");
            }

            // Add externallyHostedMedia as object <json array>
            if (requestPayload.ExternallyHostedMedia != null && requestPayload.ExternallyHostedMedia.Any() )
            {
                multipartFormDataContent.Add(new StringContent(
                        JsonConvert.SerializeObject(requestPayload.ExternallyHostedMedia), Encoding.UTF8,
                        "application/json"),
                    "externallyHostedMedia");
            }

            // Add smil as string <xml>
            if (!string.IsNullOrEmpty(requestPayload.Smil))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Text, Encoding.UTF8, "application/smil"), "smil");
            }

            var url = "mms/1/single";

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = multipartFormDataContent;

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<SendMmsMessageResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetMmsDeliveryReportResponse> GetOutboundMmsMessageDeliveryReports(GetMmsDeliveryReportRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "mms/1/reports"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "bulkId", requestPayload.BulkId },
                    { "messageId", requestPayload.MessageId },
                    { "limit", requestPayload.Limit }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetMmsDeliveryReportResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetInboundMmsMessagesResponse> GetInboundMmsMessages(GetInboundMmsMessagesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "mms/1/inbox/reports"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "limit", requestPayload.Limit }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetInboundMmsMessagesResponse>();
                }
            }
        }
    }
}
