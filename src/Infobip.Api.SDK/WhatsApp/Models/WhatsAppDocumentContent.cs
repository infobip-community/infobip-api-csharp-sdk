using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppDocumentContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppDocumentContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppDocumentContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppDocumentContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB. (required).</param>
        /// <param name="caption">Caption of the document..</param>
        /// <param name="filename">File name of the document..</param>
        public WhatsAppDocumentContent(string mediaUrl = default, string caption = default, string filename = default)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Caption = caption;
            Filename = filename;
        }

        /// <summary>
        /// URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB.
        /// </summary>
        /// <value>URL of a document sent in a WhatsApp message. Must be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Maximum document size is 100MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Caption of the document.
        /// </summary>
        /// <value>Caption of the document.</value>
        [JsonProperty("caption")]
        [MinLength(0)]
        [MaxLength(3000)]
        public string Caption { get; set; }

        /// <summary>
        /// File name of the document.
        /// </summary>
        /// <value>File name of the document.</value>
        [JsonProperty("filename")]
        [MinLength(0)]
        [MaxLength(240)]
        public string Filename { get; set; }
    }
}