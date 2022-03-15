using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveButtonsTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsTextHeaderContent : WhatsAppInteractiveButtonsHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsTextHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsTextHeaderContent" /> class.
        /// </summary>
        /// <param name="text">Text of the message header. (required).</param>
        public WhatsAppInteractiveButtonsTextHeaderContent(string text = default) : base(InteractiveHeaderContentEnum.Text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Text of the message header.
        /// </summary>
        /// <value>Text of the message header.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Header Text is required")]
        [MinLength(1)]
        [MaxLength(60)]
        public string Text { get; set; }
    }
}