using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.WebRtc.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WebRtc
{
    /// <inheritdoc />
    internal class WebRtcEndpoints : IWebRtcEndpoints
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public WebRtcEndpoints(HttpClient client, IRequestValidator requestValidator)
        {
            _client = client;
            _requestValidator = requestValidator;
        }

        /// <inheritdoc />
        public async Task<WebRtcTokenResponse> GenerateWebRtcToken(WebRtcTokenRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "webrtc/1/token"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WebRtcTokenResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<List<WebRtcApplicationResponse>> GetWebRtcApplications(CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "webrtc/1/applications"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<List<WebRtcApplicationResponse>>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WebRtcApplicationResponse> SaveWebRtcApplication(WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "webrtc/1/applications"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WebRtcApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WebRtcApplicationResponse> GetWebRtcApplication(string id, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"webrtc/1/applications/{id}"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WebRtcApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WebRtcApplicationResponse> UpdateWebRtcApplication(string id, WebRtcApplicationRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, $"webrtc/1/applications/{id}"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WebRtcApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task DeleteWebRtcApplication(string id, CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Delete, $"webrtc/1/applications/{id}"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();
                }
            }
        }
    }
}