using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveListTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveListTextHeaderContent), "TEXT")]
    public class WhatsAppInteractiveListTextHeaderContent : WhatsAppInteractiveListHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveListTextHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveListTextHeaderContent" /> class.
        /// </summary>
        /// <param name="text">Text of the message header. (required).</param>
        public WhatsAppInteractiveListTextHeaderContent(string text = default) : base(ListHeaderContentEnum.Text)
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