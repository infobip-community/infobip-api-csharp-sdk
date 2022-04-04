using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SendSmsMessageOverQueryParametersRequest
    /// </summary>
    public class SendSmsMessageOverQueryParametersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageOverQueryParametersRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendSmsMessageOverQueryParametersRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsMessageOverQueryParametersRequest" /> class.
        /// </summary>
        /// <param name="username">Username for authentication.</param>
        /// <param name="password">Password for authentication.</param>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.</param>
        /// <param name="from">The sender ID which can be alphanumeric or numeric (e.g., CompanyName).</param>
        /// <param name="to">List of message recipients.</param>
        /// <param name="text">Content of the message being sent.</param>
        /// <param name="flash">Sends a [flash SMS](https://www.infobip.com/docs/sms/message-types#flash-sms) if set to true.</param>
        /// <param name="transliteration">Conversion of a message text from one script to another.</param>
        /// <param name="languageCode">Code for language character set of a message content.</param>
        /// <param name="intermediateReport">Use a [real-time intermediate delivery report](https://www.infobip.com/docs/api#channels/sms/receive-outbound-sms-message-report) that will be sent on your callback server.</param>
        /// <param name="notifyUrl">The URL on your call back server on to which a delivery report will be sent.</param>
        /// <param name="notifyContentType">Preferred delivery report content type, application/json or application/xml.</param>
        /// <param name="callbackData">Additional client data to be sent over the notifyUrl.</param>
        /// <param name="validityPeriod">The message validity period in minutes. When the period expires, it will not be allowed for the message to be sent. Validity period longer than 48h is not supported. Any bigger value will automatically default back to 2880.</param>
        /// <param name="sendAt">Date and time when the message is to be sent. Used for [scheduled SMS](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ. Must be sooner than 180 days from now.</param>
        /// <param name="track">Sets the conversion element to be tracked.</param>
        /// <param name="processKey">The process key which uniquely identifies conversion tracking.</param>
        /// <param name="trackingType">Sets a custom conversion type naming convention, e.g. ONE_TIME_PIN, SOCIAL_INVITES, etc.</param>
        /// <param name="indiaDltContentTemplateId">The ID of your registered DLT (Distributed Ledger Technology) content template.</param>
        /// <param name="indiaDltPrincipalEntityId">Your DLT (Distributed Ledger Technology) entity id.</param>
        public SendSmsMessageOverQueryParametersRequest(string username = default, string password = default, string bulkId = default, string from = default, 
            string to = default, string text = default, bool flash = default, string transliteration = default, string languageCode = default, bool intermediateReport = default, 
            string notifyUrl = default, string notifyContentType = default, string callbackData = default, long validityPeriod = default, DateTimeOffset sendAt = default,
            string track = default, string processKey = default, string trackingType = default, string indiaDltContentTemplateId = default, string indiaDltPrincipalEntityId = default)
        {
            Username = username;
            Password = password;
            BulkId = bulkId;
            From = from;
            To = to;
            Text = text;
            Flash = flash;
            Transliteration = transliteration;
            LanguageCode = languageCode;
            IntermediateReport = intermediateReport;
            NotifyUrl = notifyUrl;
            NotifyContentType = notifyContentType;
            CallbackData = callbackData;
            ValidityPeriod = validityPeriod;
            SendAt = sendAt;
            Track = track;
            ProcessKey = processKey;
            TrackingType = trackingType;
            IndiaDltContentTemplateId = indiaDltContentTemplateId;
            IndiaDltPrincipalEntityId = indiaDltPrincipalEntityId;
        }

        /// <summary>
        /// Username for authentication.
        /// </summary>
        [JsonProperty("username")]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password for authentication.
        /// </summary>
        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        /// The sender ID which can be alphanumeric or numeric (e.g., CompanyName).
        /// </summary>
        [JsonProperty("from")]
        [Required]
        public string From { get; set; }

        /// <summary>
        /// List of message recipients.
        /// </summary>
        [JsonProperty("to")]
        [Required]
        public string To { get; set; }

        /// <summary>
        /// Content of the message being sent.
        /// </summary>
        [JsonProperty("text")]
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Sends a [flash SMS](https://www.infobip.com/docs/sms/message-types#flash-sms) if set to true.
        /// </summary>
        [JsonProperty("flash")]
        public bool Flash { get; set; }

        /// <summary>
        /// Conversion of a message text from one script to another.
        /// </summary>
        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        /// <summary>
        /// Code for language character set of a message content.
        /// </summary>
        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Use a [real-time intermediate delivery report](https://www.infobip.com/docs/api#channels/sms/receive-outbound-sms-message-report) that will be sent on your callback server.
        /// </summary>
        [JsonProperty("intermediateReport")]
        public bool IntermediateReport { get; set; }

        /// <summary>
        /// The URL on your call back server on to which a delivery report will be sent.
        /// </summary>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Preferred delivery report content type, application/json or application/xml.
        /// </summary>
        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }

        /// <summary>
        /// Additional client data to be sent over the notifyUrl.
        /// </summary>
        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        /// <summary>
        /// The message validity period in minutes. When the period expires, it will not be allowed for the message to be sent. Validity period longer than 48h is not supported. Any bigger value will automatically default back to 2880.
        /// </summary>
        [JsonProperty("validityPeriod")]
        public long ValidityPeriod { get; set; }

        /// <summary>
        /// Date and time when the message is to be sent. Used for [scheduled SMS](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages). Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ. Must be sooner than 180 days from now.
        /// </summary>
        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }

        /// <summary>
        /// Sets the conversion element to be tracked.
        /// </summary>
        [JsonProperty("track")]
        public string Track { get; set; }

        /// <summary>
        /// The process key which uniquely identifies conversion tracking.
        /// </summary>
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        /// <summary>
        /// Sets a custom conversion type naming convention, e.g. ONE_TIME_PIN, SOCIAL_INVITES, etc.
        /// </summary>
        [JsonProperty("trackingType")]
        public string TrackingType { get; set; }

        /// <summary>
        /// The ID of your registered DLT (Distributed Ledger Technology) content template.
        /// </summary>
        [JsonProperty("indiaDltContentTemplateId")]
        public string IndiaDltContentTemplateId { get; set; }

        /// <summary>
        /// Your DLT (Distributed Ledger Technology) entity id.
        /// </summary>
        [JsonProperty("indiaDltPrincipalEntityId")]
        public string IndiaDltPrincipalEntityId { get; set; }
    }
}
