using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaMessageTemplateResponse
    /// </summary>
    public class TfaMessageTemplateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaMessageTemplateResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public TfaMessageTemplateResponse() { }

        /// <summary>
        /// The ID of the application that represents your service (e.g. 2FA for login, 2FA for changing the password, etc.) for which the requested message has been created.
        /// </summary>
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Enum: "en" "es" "ca" "da" "nl" "fr" "de" "it" "ja" "ko" "no" "pl" "ru" "sv" "fi" "hr" "sl" "pt-pt" "pt-br" "zh-cn" "zh-tw".
        /// The language code which message is written in used when sending text-to-speech messages.If not defined, it will default to English (en).
        /// </summary>
        [JsonProperty("language")]
        public TfaLanguage? Language { get; set; }


        /// <summary>
        /// The ID of the message template (message body with the PIN placeholder) that is sent to the recipient.
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Text of a message that will be sent. Message text must contain pinPlaceholder.
        /// </summary>
        [JsonProperty("messageText")]
        public string MessageText { get; set; }

        /// <summary>
        /// PIN code length.
        /// </summary>
        [JsonProperty("pinLength")]
        public int PinLength { get; set; }

        /// <summary>
        /// The PIN code placeholder that will be replaced with a generated PIN code.
        /// </summary>
        [JsonProperty("pinPlaceholder")]
        public string PinPlaceholder { get; set; }

        /// <summary>
        /// Enum: "NUMERIC" "ALPHA" "HEX" "ALPHANUMERIC".
        /// The type of PIN code that will be generated and sent as part of 2FA message.You can set PIN type to numeric, alpha, alphanumeric or hex.
        /// </summary>
        [JsonProperty("pinType")]
        public TfaPinType? PinType { get; set; }

        /// <summary>
        /// Region specific parameters, often specified by local laws. Use this if country or region that you are sending SMS to requires some extra parameters.
        /// </summary>
        [JsonProperty("regional")]
        public SmsRegionalOptions Regional { get; set; }

        /// <summary>
        /// In case PIN message is sent by Voice, DTMF code will enable replaying the message.
        /// </summary>
        [JsonProperty("repeatDTMF")]
        public string RepeatDtmf { get; set; }

        /// <summary>
        /// The name that will appear as the sender of the 2FA message (Example: CompanyName).
        /// </summary>
        [JsonProperty("senderId")]
        public string SenderId { get; set; }

        /// <summary>
        /// In case PIN message is sent by Voice, the speed of speech can be set for the message. Supported range is from 0.5 to 2.
        /// </summary>
        [JsonProperty("speechRate")]
        public double SpeechRate { get; set; }
    }
}
