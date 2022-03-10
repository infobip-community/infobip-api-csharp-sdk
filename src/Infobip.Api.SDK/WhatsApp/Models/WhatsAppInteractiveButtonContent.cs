using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// An array of buttons sent in a message. It can have up to three buttons.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveReplyButtonContent), "REPLY")]
    public class WhatsAppInteractiveButtonContent
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InteractiveButtonEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "REPLY")]
            Reply = 1
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonContent" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveButtonContent(InteractiveButtonEnum? type = default)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        [Required(ErrorMessage = "Button Type is required")]
        public InteractiveButtonEnum Type { get; set; }
    }
}