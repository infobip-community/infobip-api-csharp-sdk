using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsImageHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsImageHeaderContent : WhatsAppInteractiveButtonsHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsImageHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsImageHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsImageHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB. (required).</param>
        public WhatsAppInteractiveButtonsImageHeaderContent(string mediaUrl = default) : base(InteractiveHeaderContentEnum.Image)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.
        /// </summary>
        /// <value>URL of an image sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported image types are &#x60;JPG&#x60;, &#x60;JPEG&#x60;, &#x60;PNG&#x60;. Maximum image size is 5MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "Header MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }
    }
}