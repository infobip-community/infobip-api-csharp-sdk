using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Email.Models;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.Validation;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.Email
{
    /// <inheritdoc />
    internal class EmailEndpoints : IEmailEndpoints
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public EmailEndpoints(HttpClient client, IRequestValidator requestValidator)
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

            // Add mandatory parts
            var multipartFormDataContent = new MultipartFormDataContent
            {
                { new StringContent(requestPayload.From), "from" },
                { new StringContent(requestPayload.To), "to" },
                { new StringContent(requestPayload.Subject), "subject" },
            };

            // Others are not mandatory and add them only if specified.
            // Add cc
            if (!string.IsNullOrEmpty(requestPayload.Cc))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Cc), "cc");
            }

            // Add bcc
            if (!string.IsNullOrEmpty(requestPayload.Bcc))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Bcc), "bcc");
            }

            // Add text
            if (!string.IsNullOrEmpty(requestPayload.Text))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Text), "text");
            }

            // Add bulkId
            if (!string.IsNullOrEmpty(requestPayload.BulkId))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.BulkId), "bulkId");
            }

            // Add messageId
            if (!string.IsNullOrEmpty(requestPayload.MessageId))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.MessageId), "messageId");
            }

            // Add templateid
            if (requestPayload.TemplateId.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.TemplateId.Value.ToString()), "templateid");
            }

            // Add attachment
            if (requestPayload.Attachment != null)
            {
                var mediaContent = new StreamContent(requestPayload.Attachment);
                mediaContent.Headers.Add("Content-Type", "application/octet-stream");
                multipartFormDataContent.Add(mediaContent, "attachment", "attachment");
            }

            // Add inlineImage
            if (requestPayload.InlineImage != null)
            {
                var mediaContent = new StreamContent(requestPayload.InlineImage);
                mediaContent.Headers.Add("Content-Type", "application/octet-stream");
                multipartFormDataContent.Add(mediaContent, "inlineImage", "inlineImage");
            }

            // Add HTML
            if (!string.IsNullOrEmpty(requestPayload.Html))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Html), "HTML");
            }

            // Add replyto
            if (!string.IsNullOrEmpty(requestPayload.ReplyTo))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.ReplyTo), "replyto");
            }

            // Add defaultplaceholders
            if (!string.IsNullOrEmpty(requestPayload.DefaultPlaceholders))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.DefaultPlaceholders), "defaultplaceholders");
            }

            // Add preserverecipients
            if (requestPayload.PreserveRecipients.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.PreserveRecipients.Value.ToString()), "preserverecipients");
            }

            // Add trackingUrl
            if (!string.IsNullOrEmpty(requestPayload.TrackingUrl))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.TrackingUrl), "trackingUrl");
            }

            // Add trackclicks
            if (requestPayload.TrackClicks.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.TrackClicks.Value.ToString()), "trackclicks");
            }

            // Add trackopens
            if (requestPayload.TrackOpens.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.TrackOpens.Value.ToString()), "trackopens");
            }

            // Add track
            if (requestPayload.Track.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.Track.Value.ToString()), "track");
            }

            // Add callbackData
            if (!string.IsNullOrEmpty(requestPayload.CallbackData))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.CallbackData), "callbackData");
            }

            // Add intermediateReport
            if (requestPayload.IntermediateReport.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.IntermediateReport.Value.ToString()), "intermediateReport");
            }

            // Add notifyUrl
            if (!string.IsNullOrEmpty(requestPayload.NotifyUrl))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.NotifyUrl), "notifyUrl");
            }

            // Add notifyContentType
            if (!string.IsNullOrEmpty(requestPayload.NotifyContentType))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.NotifyContentType), "notifyContentType");
            }

            // Add sendAt
            if (requestPayload.SendAt.HasValue)
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.SendAt.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffK")), "sendAt");
            }

            // Add landingPagePlaceholders
            if (!string.IsNullOrEmpty(requestPayload.LandingPagePlaceholders))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.LandingPagePlaceholders), "landingPagePlaceholders");
            }

            // Add landingPageId
            if (!string.IsNullOrEmpty(requestPayload.LandingPageId))
            {
                multipartFormDataContent.Add(new StringContent(requestPayload.LandingPageId), "landingPageId");
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = multipartFormDataContent;

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
            // bulkId required  
            if (string.IsNullOrEmpty(bulkId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(bulkId)}'.", new List<ValidationResult>());
            }

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
            // bulkId required  
            if (string.IsNullOrEmpty(bulkId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(bulkId)}'.", new List<ValidationResult>());
            }

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
            // bulkId required  
            if (string.IsNullOrEmpty(bulkId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(bulkId)}'.", new List<ValidationResult>());
            }

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
            // bulkId required  
            if (string.IsNullOrEmpty(bulkId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(bulkId)}'.", new List<ValidationResult>());
            }

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