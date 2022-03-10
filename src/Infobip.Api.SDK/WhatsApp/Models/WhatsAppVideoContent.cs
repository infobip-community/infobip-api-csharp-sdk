using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppVideoContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppVideoContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppVideoContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppVideoContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB. (required).</param>
        /// <param name="caption">Caption of the video..</param>
        public WhatsAppVideoContent(string mediaUrl = default, string caption = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
        }

        /// <summary>
        /// URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.
        /// </summary>
        /// <value>URL of a video sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the video.
        /// </summary>
        /// <value>Caption of the video.</value>
        [JsonProperty("caption")]
        [MinLength(0)]
        [MaxLength(3000)]
        public string Caption { get; set; }
    }
}