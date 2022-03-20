using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// PreviewSmsMessageRequest
    /// </summary>
    public class PreviewSmsMessageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewSmsMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected PreviewSmsMessageRequest() { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PreviewSmsMessageRequest" /> class.
        /// </summary>
        /// <param name="languageCode">Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.</param>
        /// <param name="text">Content of the message being sent. (required).</param>
        /// <param name="transliteration">The transliteration of your sent message from one script to another. Transliteration is used to replace characters which are not recognized as part of your defaulted alphabet. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.</param>
        public PreviewSmsMessageRequest(string languageCode = default, string text = default,
            string transliteration = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            LanguageCode = languageCode;
            Transliteration = transliteration;
        }

        /// <summary>
        /// Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.
        /// </summary>
        [JsonProperty("languageCode")]
        [RegularExpression("^(TR|ES|PT|AUTODETECT)$")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Content of the message being sent.
        /// </summary>
        [JsonProperty("text")]
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// The transliteration of your sent message from one script to another. Transliteration is used to replace characters which are not recognized as part of your defaulted alphabet. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.
        /// </summary>
        [JsonProperty("transliteration")]
        [RegularExpression("^(TURKISH|GREEK|CYRILLIC|SERBIAN_CYRILLIC|CENTRAL_EUROPEAN|BALTIC|NON_UNICODE)$")]
        public string Transliteration { get; set; }
    }
}
