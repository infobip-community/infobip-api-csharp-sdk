using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.SMS.Models;
using Infobip.Api.SDK.Validation;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS
{
    /// <inheritdoc />
    internal class SmsEndpoints : ISmsEndpoints
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public SmsEndpoints(HttpClient client, IRequestValidator requestValidator)
        {
            _client = client;
            _requestValidator = requestValidator;
        }

        /// <inheritdoc />
        public async Task<SendSmsMessageResponse> SendSmsMessage(SendSmsMessageRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "sms/2/text/advanced"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<SendSmsMessageResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<SendSmsMessageResponse> SendSmsMessageOverQueryParameters(SendSmsMessageOverQueryParametersRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/text/query"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "username", requestPayload.Username },
                    { "password", requestPayload.Password },
                    { "bulkId", requestPayload.BulkId },
                    { "from", requestPayload.From },
                    { "to", requestPayload.To },
                    { "text", requestPayload.Text },
                    { "flash", requestPayload.Flash },
                    { "transliteration", requestPayload.Transliteration },
                    { "languageCode", requestPayload.LanguageCode },
                    { "intermediateReport", requestPayload.IntermediateReport },
                    { "notifyUrl", requestPayload.NotifyUrl },
                    { "notifyContentType", requestPayload.NotifyContentType },
                    { "callbackData", requestPayload.CallbackData },
                    { "validityPeriod", requestPayload.ValidityPeriod },
                    { "sendAt", requestPayload.SendAt },
                    { "track", requestPayload.Track },
                    { "processKey", requestPayload.ProcessKey },
                    { "trackingType", requestPayload.TrackingType },
                    { "indiaDltContentTemplateId", requestPayload.IndiaDltContentTemplateId },
                    { "indiaDltPrincipalEntityId", requestPayload.IndiaDltPrincipalEntityId }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<SendSmsMessageResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<SendSmsMessageResponse> SendBinarySmsMessage(SendSmsBinaryMessageRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "sms/2/binary/advanced"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<SendSmsMessageResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<PreviewSmsMessageResponse> PreviewSmsMessage(PreviewSmsMessageRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "/sms/1/preview"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<PreviewSmsMessageResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetSmsDeliveryReportResponse> GetOutboundSmsMessageDeliveryReports(GetSmsDeliveryReportRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/reports"
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
                    return stream.ReadAndDeserializeFromJson<GetSmsDeliveryReportResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<GetSmsLogsResponse> GetOutboundSmsMessageLogs(GetSmsLogsRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/logs"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "from", requestPayload.From },
                    { "to", requestPayload.To },
                    { "bulkId", requestPayload.BulkId },
                    { "messageId", requestPayload.MessageId },
                    { "generalStatus", requestPayload.GeneralStatus },
                    { "sentSince", requestPayload.SentSince },
                    { "sentUntil", requestPayload.SentUntil },
                    { "limit", requestPayload.Limit },
                    { "mcc", requestPayload.Mcc },
                    { "mnc", requestPayload.Mnc }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetSmsLogsResponse>();
                }
            }
        }

        // Receive SMS
        /// <inheritdoc />
        public async Task<GetInboundSmsMessagesResponse> GetInboundSmsMessages(GetInboundSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/inbox/reports"
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
                    return stream.ReadAndDeserializeFromJson<GetInboundSmsMessagesResponse>();
                }
            }
        }

        // Scheduled SMS
        /// <inheritdoc />
        public async Task<ScheduledSmsMessagesResponse> GetScheduledSmsMessages(GetScheduledSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/bulks"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "bulkId", requestPayload.BulkId }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<ScheduledSmsMessagesResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<ScheduledSmsMessagesResponse> RescheduleSmsMessages(RescheduleSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/bulks"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "bulkId", requestPayload.BulkId }
                });

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<ScheduledSmsMessagesResponse>();
                }
            }
        }


        /// <inheritdoc />
        public async Task<ScheduledSmsMessagesStatusResponse> GetScheduledSmsMessagesStatus(GetScheduledSmsMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/bulks/status"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "bulkId", requestPayload.BulkId }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<ScheduledSmsMessagesStatusResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<ScheduledSmsMessagesStatusResponse> UpdateScheduledSmsMessagesStatus(UpdateScheduledSmsMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "sms/1/bulks/status"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "bulkId", requestPayload.BulkId }
                });

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<ScheduledSmsMessagesStatusResponse>();
                }
            }
        }

        // 2FA Over SMS And Voice (Tfa - Two-Factor Authentication)
        /// <inheritdoc />
        public async Task<List<TfaApplicationResponse>> GetTfaApplications(CancellationToken cancellationToken = default)
        {
            var url = "2fa/2/applications";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<List<TfaApplicationResponse>>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaApplicationResponse> CreateTfaApplication(TfaApplicationRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "2fa/2/applications";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaApplicationResponse> GetTfaApplication(string appId, CancellationToken cancellationToken = default)
        {
            var url = $"2fa/2/applications/{appId}";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaApplicationResponse> UpdateTfaApplication(string appId, TfaApplicationRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/applications/{appId}";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaApplicationResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<List<TfaMessageTemplateResponse>> GetTfaMessageTemplates(string appId, CancellationToken cancellationToken = default)
        {
            var url = $"2fa/2/applications/{appId}/messages";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<List<TfaMessageTemplateResponse>>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaMessageTemplateResponse> CreateTfaMessageTemplate(string appId, TfaMessageTemplateRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/applications/{appId}/messages";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaMessageTemplateResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaMessageTemplateResponse> GetTfaMessageTemplate(string appId, string msgId, CancellationToken cancellationToken = default)
        {
            var url = $"2fa/2/applications/{appId}/messages/{msgId}";

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaMessageTemplateResponse>();
                }
            }
        }
        
        /// <inheritdoc />
        public async Task<TfaMessageTemplateResponse> UpdateTfaMessageTemplate(string appId, string msgId, TfaMessageTemplateRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/applications/{appId}/messages/{msgId}";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaMessageTemplateResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaPinCodeResponse> SendTfaPinCodeOverSms(SendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "2fa/2/pin"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "ncNeeded", requestPayload.NcNeeded }
                });

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaPinCodeResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaPinCodeResponse> ResendTfaPinCodeOverSms(string pinId, ResendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/pin/{pinId}/resend";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaPinCodeResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaPinCodeResponse> SendTfaPinCodeOverVoice(SendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = "2fa/2/pin/voice";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaPinCodeResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaPinCodeResponse> ResendTfaPinCodeOverVoice(string pinId, ResendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/pin/{pinId}/resend/voice";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaPinCodeResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<VerifyPhoneNumberResponse> VerifyPhoneNumber(string pinId, VerifyPhoneNumberRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/pin/{pinId}/verify";

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<VerifyPhoneNumberResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<TfaVerificationStatusResponse> GetTfaVerificationStatus(string appId, TfaVerificationStatusRequest requestPayload, CancellationToken cancellationToken = default)
        {
            _requestValidator.Validate(requestPayload);

            var url = $"2fa/2/applications/{appId}/verifications"
                .AddToQueryString(new Dictionary<string, object>
                {
                    { "msisdn", requestPayload.Msisdn },
                    { "verified", requestPayload.Verified },
                    { "sent", requestPayload.Sent }
                });

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<TfaVerificationStatusResponse>();
                }
            }
        }
    }
}
