using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Sets the language parameters for the message being sent.
    /// </summary>
    [DataContract(Name = "SmsLanguage")]
    public class SmsLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsLanguage" /> class.
        /// </summary>
        /// <param name="languageCode">Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.</param>
        public SmsLanguage(string languageCode = default)
        {
            LanguageCode = languageCode;
        }

        /// <summary>
        /// Language code for the correct character set. Possible values: TR for Turkish, ES for Spanish, PT for Portuguese, or AUTODETECT to let platform select the character set based on message content.
        /// </summary>
        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }
}