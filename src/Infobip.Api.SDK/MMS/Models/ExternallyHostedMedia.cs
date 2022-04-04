using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.MMS.Models
{
    /// <summary>
    /// ExternallyHostedMedia
    /// </summary>
    public class ExternallyHostedMedia
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternallyHostedMedia" /> class.
        /// </summary>
        /// <param name="contentType">Content type for media, for example 'image/png'.</param>
        /// <param name="contentId">Unique identifier for the content part.</param>
        /// <param name="contentUrl">URL for externally hosted content.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ExternallyHostedMedia(string contentType = default, string contentId = default, string contentUrl = default)
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            ContentId = contentId ?? throw new ArgumentNullException(nameof(contentId));
            ContentUrl = contentUrl ?? throw new ArgumentNullException(nameof(contentUrl));
        }

        /// <summary>
        /// Content type for media, for example 'image/png'.
        /// </summary>s
        [JsonProperty("contentType")]
        [Required]
        public string ContentType { get; set; }

        /// <summary>
        /// Unique identifier for the content part.
        /// </summary>
        [JsonProperty("contentId")]
        [Required]
        public string ContentId { get; set; }

        /// <summary>
        /// URL for externally hosted content.
        /// </summary>
        [JsonProperty("contentUrl")]
        [Required]
        public string ContentUrl { get; set; }
    }
}