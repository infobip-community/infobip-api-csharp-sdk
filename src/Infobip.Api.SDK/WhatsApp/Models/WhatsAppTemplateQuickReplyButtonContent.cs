using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateQuickReplyButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonContent), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonContent), "URL")]
    public class WhatsAppTemplateQuickReplyButtonContent : WhatsAppTemplateButtonContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateQuickReplyButtonContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonContent" /> class.
        /// </summary>
        /// <param name="parameter">Payload of a &#x60;quick reply&#x60; button. (required).</param>
        public WhatsAppTemplateQuickReplyButtonContent(string parameter = default) : base(TypeEnum.QuickReply)
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        /// <summary>
        /// Payload of a &#x60;quick reply&#x60; button.
        /// </summary>
        /// <value>Payload of a &#x60;quick reply&#x60; button.</value>
        [JsonProperty("parameter")]
        [Required(ErrorMessage = "Parameter is required")]
        [MinLength(1)]
        [MaxLength(128)]
        public string Parameter { get; set; }
    }
}