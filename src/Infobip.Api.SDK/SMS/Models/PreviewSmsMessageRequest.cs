using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// PreviewSmsMessageRequest
    /// </summary>
    public class PreviewSmsMessageRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewSmsMessageRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected PreviewSmsMessageRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewSmsMessageRequest" /> class.
        /// </summary>
        /// <param name="text">Content of the message being sent. (required).</param>
        /// <param name="languageCode">Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.</param>
        /// <param name="transliteration">The transliteration of your sent message from one script to another. Transliteration is used to replace characters which are not recognized as part of your defaulted alphabet. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.</param>
        public PreviewSmsMessageRequest(string text, string languageCode = default,
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
        //[RegularExpression("^(TR|ES|PT|AUTODETECT)$")]
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
        //[RegularExpression("^(TURKISH|GREEK|CYRILLIC|SERBIAN_CYRILLIC|CENTRAL_EUROPEAN|BALTIC|NON_UNICODE)$")]
        public string Transliteration { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Transliteration (string) pattern
            var regexTransliteration = new Regex(@"^(TURKISH|GREEK|CYRILLIC|SERBIAN_CYRILLIC|CENTRAL_EUROPEAN|BALTIC|NON_UNICODE)$", RegexOptions.CultureInvariant);
            if (false == regexTransliteration.Match(Transliteration).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for Transliteration, must match a pattern of {regexTransliteration}", new[] { nameof(Transliteration) });
            }

            // LanguageCode (string) pattern
            var regexLanguageCode = new Regex(@"^(TR|ES|PT|AUTODETECT)$", RegexOptions.CultureInvariant);
            if (false == regexLanguageCode.Match(LanguageCode).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for LanguageCode, must match a pattern of {regexLanguageCode}", new[] { nameof(LanguageCode) });
            }
        }
    }
}
