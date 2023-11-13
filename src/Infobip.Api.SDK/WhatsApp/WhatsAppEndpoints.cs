using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.Extensions;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.WhatsApp.Models;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp
{
    /// <inheritdoc />
    internal class WhatsAppEndpoints : IWhatsAppEndpoints
    {
        private readonly HttpClient _client;
        private readonly IRequestValidator _requestValidator;

        public WhatsAppEndpoints(HttpClient client, IRequestValidator requestValidator)
        {
            _client = client;
            _requestValidator = requestValidator;
        }

        // Send WhatsApp Message
        /// <inheritdoc />
        public async Task<WhatsAppBulkMessageInfoResponse> SendWhatsAppTemplateMessage(WhatsAppBulkMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/template"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppBulkMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage(WhatsAppTextMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/text"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppDocumentMessage(WhatsAppDocumentMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/document"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppImageMessage(WhatsAppImageMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/image"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppAudioMessage(WhatsAppAudioMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/audio"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppVideoMessage(WhatsAppVideoMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/video"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppStickerMessage(WhatsAppStickerMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/sticker"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppLocationMessage(WhatsAppLocationMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/location"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppContactMessage(WhatsAppContactsMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/contact"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveButtonsMessage(WhatsAppInteractiveButtonsMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/interactive/buttons"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveListMessage(WhatsAppInteractiveListMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/interactive/list"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveProductMessage(WhatsAppInteractiveProductMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/interactive/product"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveMultiProductMessage(WhatsAppInteractiveMultiProductMessageRequest requestPayload, CancellationToken cancellationToken)
        {
            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/1/message/interactive/multi-product"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppSingleMessageInfoResponse>();
                }
            }
        }


        // Receive WhatsApp Message
        /// <inheritdoc />
        public async Task<Stream> DownloadWhatsAppInboundMedia(string sender, string mediaId, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            // mediaId required
            if (string.IsNullOrEmpty(mediaId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(mediaId)}'.", new List<ValidationResult>());
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, $"whatsapp/1/senders/{sender}/media/{mediaId}"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    return await response.Content.ReadAsStreamAsync();
                }
            }
        }

        /// <inheritdoc />
        public async Task<string> GetWhatsAppMediaMetadata(string sender, string mediaId, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            // mediaId required
            if (string.IsNullOrEmpty(mediaId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(mediaId)}'.", new List<ValidationResult>());
            }

            using (var request = new HttpRequestMessage(HttpMethod.Head, $"whatsapp/1/senders/{sender}/media/{mediaId}"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        /// <inheritdoc />
        public async Task MarkWhatsAppMessageAsRead(string sender, string messageId, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            // messageId required
            if (string.IsNullOrEmpty(messageId))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(messageId)}'.", new List<ValidationResult>());
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, $"whatsapp/1/senders/{sender}/message/{messageId}/read"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();
                }
            }
        }

        // Manage WhatsApp
        /// <inheritdoc />
        public async Task<WhatsAppTemplateManagementTemplatesResponse> GetWhatsAppTemplates(string sender, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, $"whatsapp/2/senders/{sender}/templates"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppTemplateManagementTemplatesResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<WhatsAppTemplateManagementTemplateResponse> CreateWhatsAppTemplate(string sender, WhatsAppTemplateManagementTemplateRequest requestPayload, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "whatsapp/2/senders/{sender}/templates"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<WhatsAppTemplateManagementTemplateResponse>();
                }
            }
        }

        /// <inheritdoc />
        public async Task<string> DeleteWhatsAppMedia(string sender, DeleteWhatsAppMediaRequest requestPayload, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Delete, $"whatsapp/1/senders/{sender}/media"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        // Identity Change
        /// <inheritdoc />
        public async Task<GetIdentityResponse> GetIdentity(string sender, string userNumber, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            // userNumber required
            if (string.IsNullOrEmpty(userNumber))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(userNumber)}'.", new List<ValidationResult>());
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, $"/whatsapp/1/{sender}/contacts/{userNumber}/identity"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();

                    var stream = await response.Content.ReadAsStreamAsync();
                    return stream.ReadAndDeserializeFromJson<GetIdentityResponse>();
                }
            }
        }

        public async Task ConfirmIdentity(string sender, string userNumber, ConfirmIdentityRequest requestPayload, CancellationToken cancellationToken = default)
        {
            // sender required  
            if (string.IsNullOrEmpty(sender))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(sender)}'.", new List<ValidationResult>());
            }

            // userNumber required
            if (string.IsNullOrEmpty(userNumber))
            {
                throw new InfobipRequestNotValidException($"Missing required parameter '{nameof(userNumber)}'.", new List<ValidationResult>());
            }

            _requestValidator.Validate(requestPayload);

            var serializedPayload = JsonConvert.SerializeObject(requestPayload);

            using (var request = new HttpRequestMessage(HttpMethod.Put, $"whatsapp/1/{sender}/contacts/{userNumber}/identity"))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedPayload);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    await response.ThrowIfRequestWasUnsuccessful();
                }
            }
        }
    }
}