using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppInteractiveReplyButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveReplyButtonContent), "REPLY")]
    public class WhatsAppInteractiveReplyButtonContent : WhatsAppInteractiveButtonContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveReplyButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveReplyButtonContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveReplyButtonContent" /> class.
        /// </summary>
        /// <param name="id">Unique identifier of the button. (required).</param>
        /// <param name="title">Unique title of the button. Doesn&#39;t allow emojis or markdown. (required).</param>
        public WhatsAppInteractiveReplyButtonContent(string id = default, string title = default) : base(InteractiveButtonEnum.Reply)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        /// <summary>
        /// Unique identifier of the button.
        /// </summary>
        /// <value>Unique identifier of the button.</value>
        [JsonProperty("id")]
        [Required(ErrorMessage = "Button Id is required")]
        [MinLength(1)]
        [MaxLength(256)]
        public string Id { get; set; }

        /// <summary>
        /// Unique title of the button. Doesn&#39;t allow emojis or markdown.
        /// </summary>
        /// <value>Unique title of the button. Doesn&#39;t allow emojis or markdown.</value>
        [JsonProperty("title")]
        [Required(ErrorMessage = "Title is required")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}