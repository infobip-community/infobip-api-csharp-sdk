using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppImageContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppImageContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppImageContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppImageContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB. (required).</param>
        /// <param name="caption">Caption of the image..</param>
        public WhatsAppImageContent(string mediaUrl = default, string caption = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
        }

        /// <summary>
        /// URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.
        /// </summary>
        /// <value>URL of an image sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the image.
        /// </summary>
        /// <value>Caption of the image.</value>
        [JsonProperty("caption")]
        [MinLength(0)]
        [MaxLength(3000)]
        public string Caption { get; set; }
    }
}