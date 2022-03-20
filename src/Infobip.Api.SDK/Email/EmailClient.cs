using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.Validation;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email
{
    /// <inheritdoc />
    internal class EmailClient : IEmail
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public EmailClient(HttpClient client, IRequestValidator requestValidator)
        {
            _client = client;
            _requestValidator = requestValidator;
        }

        /// <inheritdoc />
        public async Task<GetEmailDeliveryReportsResponse> GetEmailDeliveryReports(GetEmailDeliveryReportsRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "email/1/reports"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "bulkId", requestPayload.BulkId },
                        { "messageId", requestPayload.MessageId },
                        { "limit",  requestPayload.Limit }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetEmailDeliveryReportsResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetEmailLogsResponse> GetEmailLogs(GetEmailLogsRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "email/1/logs"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "messageId", requestPayload.MessageId },
                        { "from", requestPayload.From },
                        { "to", requestPayload.To },
                        { "bulkId", requestPayload.BulkId },
                        { "generalStatus", requestPayload.GeneralStatus },
                        { "sentSince", requestPayload.SentSince },
                        { "sentUntil", requestPayload.SentUntil },
                        { "limit", requestPayload.Limit }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetEmailLogsResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<SendFullyFeaturedEmailResponse> SendFullyFeaturedEmail(SendFullyFeaturedEmailRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "email/2/send";

            var multipartFormDataContent = new MultipartFormDataContent
            {
                requestPayload
            };

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = multipartFormDataContent;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<SendFullyFeaturedEmailResponse>();
                }
            }
        }

        // Scheduled Email
        /// <inheritdoc />
        public async Task<GetSentEmailBulksResponse> GetSentEmailBulks(string bulkId, CancellationToken cancellationToken = default)
        {

            var url = "email/1/bulks"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "bulkId", bulkId }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetSentEmailBulksResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<RescheduleEmailMessagesResponse> RescheduleEmailMessages(string bulkId, RescheduleEmailMessagesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            var url = "email/1/bulks"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "bulkId", bulkId }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<RescheduleEmailMessagesResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetSentEmailBulksStatusResponse> GetSentEmailBulksStatus(string bulkId, CancellationToken cancellationToken = default)
        {
            var url = "email/1/bulks/status"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "bulkId", bulkId }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetSentEmailBulksStatusResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<UpdateScheduledEmailMessagesStatusResponse> UpdateScheduledEmailMessagesStatus(string bulkId, UpdateScheduledEmailMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            var url = "email/1/bulks/status"
                .AddToQueryString(
                    new Dictionary<string, object>
                    {
                        { "bulkId", bulkId }
                    }
                );

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<UpdateScheduledEmailMessagesStatusResponse>();
                }
            }
        }

        // Email Validation
        /// <inheritdoc />
        public async Task<ValidateEmailAddressesResponse> ValidateEmailAddresses(ValidateEmailAddressesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            var url = "email/2/validation";

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<ValidateEmailAddressesResponse>();
                }
            }
        }
    }
}