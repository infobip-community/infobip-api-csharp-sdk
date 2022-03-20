using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// PreviewSmsMessageResponse
    /// </summary>
    public class PreviewSmsMessageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewSmsMessageResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public PreviewSmsMessageResponse() { }

        /// <summary>
        /// Message content supplied in the request.
        /// </summary>
        [JsonProperty("originalText")]
        public string OriginalText { get; set; }

        /// <summary>
        /// Allows for previewing the original message content once additional language configuration has been applied to it.
        /// </summary>
        [JsonProperty("previews")]
        public List<SmsPreview> Previews { get; set; }
    }
}
