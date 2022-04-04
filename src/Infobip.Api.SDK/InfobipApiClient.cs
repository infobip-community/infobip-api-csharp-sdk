using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Infobip.Api.SDK.Email;
using Infobip.Api.SDK.MMS;
using Infobip.Api.SDK.RCS;
using Infobip.Api.SDK.SMS;
using Infobip.Api.SDK.Validation;
using Infobip.Api.SDK.Validation.DataAnnotations;
using Infobip.Api.SDK.WebRtc;
using Infobip.Api.SDK.WhatsApp;

namespace Infobip.Api.SDK
{
    /// <inheritdoc />
    public sealed class InfobipApiClient : IInfobipApiClient
    {
        private static readonly IRequestValidator RequestValidator = new RequestValidator(new DataAnnotationsValidator());
        private static HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipApiClient"/> class.
        /// </summary>
        public InfobipApiClient(ApiClientConfiguration configuration)
        {
            CreateAndConfigureHttpClient(configuration);
            Initialize(_httpClient);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfobipApiClient"/> class.
        /// </summary>
        /// <param name="client">An instance of the <see cref="HttpClient"/></param>
        public InfobipApiClient(HttpClient client)
        {
            Initialize(client);
        }

        private void CreateAndConfigureHttpClient(ApiClientConfiguration configuration)
        {
            if (_httpClient != null)
            {
                return;
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration.BaseUrl),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("App", configuration.ApiKey)
                }
            };
        }

        private void Initialize(HttpClient client)
        {
            WhatsApp = new WhatsAppEndpoints(client, RequestValidator);
            Rcs = new RcsEndpoints(client, RequestValidator);
            WebRtc = new WebRtcEndpoints(client, RequestValidator);
            Email = new EmailEndpoints(client, RequestValidator);
            Sms = new SmsEndpoints(client, RequestValidator);
            Mms = new MmsEndpoints(client, RequestValidator);
        }


        /// <inheritdoc />
        public IWhatsAppEndpoints WhatsApp { get; private set; }

        /// <inheritdoc />
        public IRcsEndpoints Rcs { get; private set; }

        /// <inheritdoc />
        public IWebRtcEndpoints WebRtc { get; private set; }

        /// <inheritdoc />
        public IEmailEndpoints Email { get; private set; }

        /// <inheritdoc />
        public ISmsEndpoints Sms { get; private set; }

        /// <inheritdoc />
        public IMmsEndpoints Mms { get; private set; }
    }
}