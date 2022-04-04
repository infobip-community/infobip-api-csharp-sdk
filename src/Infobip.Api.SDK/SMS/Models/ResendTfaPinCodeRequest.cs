using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// ResendTfaPinCodeRequest
    /// </summary>
    public class ResendTfaPinCodeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResendTfaPinCodeRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected ResendTfaPinCodeRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResendTfaPinCodeRequest" /> class.
        /// </summary>
        /// <param name="placeholders">Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets and should NOT contain a pin placeholder. Valid example: "placeholders":{"firstName":"John"}</param>
        public ResendTfaPinCodeRequest(Dictionary<string, string> placeholders = default)
        {
            Placeholders = placeholders;
        }

        /// <summary>
        /// Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets and should NOT contain a pin placeholder. Valid example: "placeholders":{"firstName":"John"}
        /// </summary>
        [JsonProperty("placeholders")]
        public Dictionary<string, string> Placeholders { get; set; }
    }
}
