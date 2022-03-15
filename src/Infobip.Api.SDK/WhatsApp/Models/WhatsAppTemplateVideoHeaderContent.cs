using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateVideoHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateVideoHeaderContent : WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateVideoHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateVideoHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateVideoHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateVideoHeaderContent(string mediaUrl = default, string type = default) : base()
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.
        /// </summary>
        /// <value>URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }
    }
}