using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template buttons. Should be defined in correct order, only if &#x60;quick reply&#x60; or &#x60;dynamic URL&#x60; buttons have been registered. It can have up to three &#x60;quick reply&#x60; buttons or only one &#x60;dynamic URL&#x60; button.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonContent), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonContent), "URL")]
    public class WhatsAppTemplateButtonContent
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum QUICK_REPLY for value: QUICK_REPLY
            /// </summary>
            [EnumMember(Value = "QUICK_REPLY")]
            QuickReply = 1,

            /// <summary>
            /// Enum URL for value: URL
            /// </summary>
            [EnumMember(Value = "URL")]
            Url = 2
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateButtonContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateButtonContent" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateButtonContent(TypeEnum? type = default)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        [Required(ErrorMessage = "Type is required")]
        public TypeEnum? Type { get; set; }
    }
}