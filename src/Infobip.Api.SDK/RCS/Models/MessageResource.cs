using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.RCS.Models
{
    /// <summary>
    /// Resource object describing the thumbnail of the card
    /// </summary>
    public class MessageResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResource" /> class.
        /// </summary>
        [JsonConstructor]
        protected MessageResource() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageResource" /> class.
        /// </summary>
        /// <param name="url">URL of the given resource (required).</param>
        public MessageResource(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL of the given resource
        /// </summary>
        /// <value>URL of the given resource</value>
        [JsonProperty("url")]
        [StringLength(1000, MinimumLength = 1)]
        public string Url { get; set; }
    }
}