using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveMultiProductTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveMultiProductTextHeaderContent), "TEXT")]
    public class WhatsAppInteractiveMultiProductTextHeaderContent : WhatsAppInteractiveMultiProductHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductTextHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductTextHeaderContent" /> class.
        /// </summary>
        /// <param name="text">Text of the message header. (required).</param>
        public WhatsAppInteractiveMultiProductTextHeaderContent(string text = default) : base(MultiProductHeaderContentEnum.Text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Text of the message header.
        /// </summary>
        /// <value>Text of the message header.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        [MinLength(1)]
        [MaxLength(60)]
        public string Text { get; set; }
    }
}