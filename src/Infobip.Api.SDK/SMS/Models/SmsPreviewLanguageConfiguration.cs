using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsPreviewLanguageConfiguration
    /// </summary>
    public class SmsPreviewLanguageConfiguration
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsPreviewLanguageConfiguration" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsPreviewLanguageConfiguration() { }

        /// <summary>
        ///     Gets or Sets Language
        /// </summary>
        [JsonProperty("language")]
        public SmsLanguage Language { get; set; }

        /// <summary>
        /// Conversion of a message text from one script to another. Possible values: TURKISH, GREEK, CYRILLIC, SERBIAN_CYRILLIC, CENTRAL_EUROPEAN, BALTIC and NON_UNICODE.
        /// </summary>
        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }
    }
}