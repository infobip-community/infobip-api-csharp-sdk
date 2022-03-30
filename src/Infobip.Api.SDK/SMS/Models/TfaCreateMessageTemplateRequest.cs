using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaMessageTemplateRequest
    /// </summary>
    public class TfaMessageTemplateRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaMessageTemplateRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaMessageTemplateRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TfaMessageTemplateRequest" /> class.
        /// </summary>
        /// <param name="messageText">Content of the message being sent which contains at minimum one placeholder for a PIN code ({{pin}}). Placeholder format is {{placeholderName}}.</param>
        /// <param name="pinType">Enum: "NUMERIC" "ALPHA" "HEX" "ALPHANUMERIC". Type of PIN code that will be generated and sent as part of 2FA message.</param>
        /// <param name="language">Enum: "en" "es" "ca" "da" "nl" "fr" "de" "it" "ja" "ko" "no" "pl" "ru" "sv" "fi" "hr" "sl" "pt-pt" "pt-br" "zh-cn" "zh-tw". The language code which message is written in used when sending text-to-speech messages.If not defined, it will default to English (en).</param>
        /// <param name="pinLength">PIN code length.</param>
        /// <param name="regional">Region-specific parameters, often imposed by local laws. Use this, if country or region that you are sending a message to requires additional information.</param>
        /// <param name="repeatDtmf">If the PIN is sent as a voice message, the DTMF code allows the recipient to replay the message.</param>
        /// <param name="senderId">The name that will appear as the sender of the 2FA message (Example: CompanyName).</param>
        /// <param name="speechRate">The speed of narration for messages sent as voice. Supported range is from 0.5 to 2.</param>
        public TfaMessageTemplateRequest(string messageText, TfaPinType pinType,
            TfaLanguage? language = default, int pinLength = default,
            SmsRegionalOptions regional = default, string repeatDtmf = default,
            string senderId = default, double speechRate = 1)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText));
            PinType = pinType;
            Language = language;
            PinLength = pinLength;
            Regional = regional;
            RepeatDtmf = repeatDtmf;
            SenderId = senderId;
            SpeechRate = speechRate;
        }

        /// <summary>
        /// Enum: "en" "es" "ca" "da" "nl" "fr" "de" "it" "ja" "ko" "no" "pl" "ru" "sv" "fi" "hr" "sl" "pt-pt" "pt-br" "zh-cn" "zh-tw".
        /// The language code which message is written in used when sending text-to-speech messages.If not defined, it will default to English (en).
        /// </summary>
        [JsonProperty("language")]
        public TfaLanguage? Language { get; set; }

        /// <summary>
        /// Content of the message being sent which contains at minimum one placeholder for a PIN code ({{pin}}). Placeholder format is {{placeholderName}}.
        /// </summary>
        [JsonProperty("messageText")]
        [Required]
        //[RegularExpression(@"\{\{pin\}\}", ErrorMessage = "Content of the message being sent which contains at minimum one placeholder for a PIN code ({{pin}}). Placeholder format is {{placeholderName}}.")]
        public string MessageText { get; set; }

        /// <summary>
        /// PIN code length.
        /// </summary>
        [JsonProperty("pinLength")]
        [Required]
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
        [Required]
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
        [Range(0.5, 20.0)]
        public double SpeechRate { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // MessageText (string) pattern
            var regexMessageText = new Regex(@"\{\{pin\}\}", RegexOptions.CultureInvariant);
            if (false == regexMessageText.Match(MessageText).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for MessageText, must match a pattern of {regexMessageText}", new[] { nameof(MessageText) });
            }
        }
    }
}
