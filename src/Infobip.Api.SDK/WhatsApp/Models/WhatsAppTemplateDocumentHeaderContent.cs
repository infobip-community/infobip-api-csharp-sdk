using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateDocumentHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateDocumentHeaderContent : WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateDocumentHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateDocumentHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateDocumentHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB. (required).</param>
        /// <param name="filename">Filename of the document. (required).</param>
        public WhatsAppTemplateDocumentHeaderContent(string mediaUrl = default, string filename = default) : base(TypeEnum.Document)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Filename = filename ?? throw new ArgumentNullException(nameof(filename));
        }

        /// <summary>
        /// URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.
        /// </summary>
        /// <value>URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Filename of the document.
        /// </summary>
        /// <value>Filename of the document.</value>
        [JsonProperty("filename")]
        [Required(ErrorMessage = "Filename is required")]
        [MinLength(1)]
        [MaxLength(240)]
        public string Filename { get; set; }
    }
}