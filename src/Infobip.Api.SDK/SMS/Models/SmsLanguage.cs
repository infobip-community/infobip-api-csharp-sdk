using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Sets the language parameters for the message being sent.
    /// </summary>
    public class SmsLanguage : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsLanguage" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsLanguage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsLanguage" /> class.
        /// </summary>
        /// <param name="languageCode">Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.</param>
        public SmsLanguage(string languageCode = "AUTODETECT")
        {
            LanguageCode = languageCode;
        }

        /// <summary>
        /// Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.
        /// </summary>
        [JsonProperty("languageCode")]
        //[RegularExpression("^(TR|ES|PT|AUTODETECT)$")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // LanguageCode (string) pattern
            var regex = new Regex(@"^(TR|ES|PT|AUTODETECT)$", RegexOptions.CultureInvariant);
            if (false == regex.Match(LanguageCode).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for Identity, must match a pattern of {regex}", new[] { nameof(LanguageCode) });
            }
        }
    }
}