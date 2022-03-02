using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// RcsMessageResponse
    /// </summary>
    public class RcsMessageResponse

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RcsMessageResponse" /> class.
        /// </summary>
        [JsonConstructor]
        public RcsMessageResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RcsMessageResponse" /> class.
        /// </summary>
        /// <param name="messages">messages (required).</param>
        public RcsMessageResponse(List<SingleMessageInfo> messages = default)
        {
            Messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [JsonProperty("messages")]
        public List<SingleMessageInfo> Messages { get; set; }
    }
}
