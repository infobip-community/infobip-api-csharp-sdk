using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsDocumentHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsDocumentHeaderContent : WhatsAppInteractiveButtonsHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsDocumentHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsDocumentHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsDocumentHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB. (required).</param>
        /// <param name="filename">Filename of the document..</param>
        public WhatsAppInteractiveButtonsDocumentHeaderContent(string mediaUrl = default, string filename = default) : base(InteractiveHeaderContentEnum.Document)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
            Filename = filename;
        }

        /// <summary>
        /// URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.
        /// </summary>
        /// <value>URL of a document sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported document type is &#x60;PDF&#x60;. Maximum document size is 100MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "Header MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }

        /// <summary>
        /// Filename of the document.
        /// </summary>
        /// <value>Filename of the document.</value>
        [JsonProperty("filename")]
        [MinLength(0)]
        [MaxLength(240)]
        public string Filename { get; set; }
    }
}