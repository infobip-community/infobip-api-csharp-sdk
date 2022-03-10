using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateImageHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateImageHeaderContent : WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateImageHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateImageHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateImageHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB. (required).</param>
        public WhatsAppTemplateImageHeaderContent(string mediaUrl = default) : base(TypeEnum.Image)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.
        /// </summary>
        /// <value>URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }
    }
}