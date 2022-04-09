using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// ConfirmIdentityRequest
    /// </summary>
    public class ConfirmIdentityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmIdentityRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected ConfirmIdentityRequest() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmIdentityRequest" /> class.
        /// </summary>
        /// <param name="hash">Identity hash.</param>
        public ConfirmIdentityRequest(string hash = default)
        {
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
        }

        /// <summary>
        /// The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one destination address.
        /// </summary>
        [JsonProperty("hash")]
        [Required]
        public string Hash { get; set; }
    }
}
