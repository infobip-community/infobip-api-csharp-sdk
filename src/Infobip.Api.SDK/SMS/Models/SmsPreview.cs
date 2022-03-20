using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// SmsPreview
    /// </summary>
    public class SmsPreview
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsPreview" /> class.
        /// </summary>
        [JsonConstructor]
        public SmsPreview() { }

        /// <summary>
        /// Number of remaining characters in the last part of the SMS.
        /// </summary>
        [JsonProperty("charactersRemaining")]
        public int CharactersRemaining { get; set; }

        /// <summary>
        /// Sets up additional configuration that changes the original message content you can preview with this call.
        /// </summary>
        [JsonProperty("configuration")]
        public SmsPreviewLanguageConfiguration Configuration { get; private set; }

        /// <summary>
        /// Number of SMS message parts required to deliver the message.
        /// </summary>
        [JsonProperty("messageCount")]
        public int MessageCount { get; private set; }

        /// <summary>
        /// Preview of the message content as it should appear on the recipient’s device.
        /// </summary>
        [JsonProperty("textPreview")]
        public string TextPreview { get; set; }
    }
}