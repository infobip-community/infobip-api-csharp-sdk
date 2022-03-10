using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsVideoHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsVideoHeaderContent : WhatsAppInteractiveButtonsHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsVideoHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsVideoHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsVideoHeaderContent" /> class.
        /// </summary>
        /// <param name="mediaUrl">URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB. (required).</param>
        public WhatsAppInteractiveButtonsVideoHeaderContent(string mediaUrl = default) : base(InteractiveHeaderContentEnum.Video)
        {
            MediaUrl = mediaUrl ?? throw new ArgumentNullException(nameof(mediaUrl));
        }

        /// <summary>
        /// URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.
        /// </summary>
        /// <value>URL of a video sent in the header. It is expected to be a valid URL starting with &#x60;https://&#x60;, &#x60;http://&#x60; or &#x60;ftp://&#x60;. Supported video types are &#x60;MP4&#x60;, &#x60;3GPP&#x60;. Maximum video size is 16MB.</value>
        [JsonProperty("mediaUrl")]
        [Required(ErrorMessage = "Header MediaUrl is required")]
        [MinLength(1)]
        [MaxLength(2048)]
        public string MediaUrl { get; set; }
    }
}