using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message header.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveMultiProductTextHeaderContent), "TEXT")]
    public class WhatsAppInteractiveMultiProductHeaderContent
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MultiProductHeaderContentEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            Text = 1
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveMultiProductHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveMultiProductHeaderContent" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveMultiProductHeaderContent(MultiProductHeaderContentEnum? type = default)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        [Required(ErrorMessage = " MultiProduct Header Content Type is required")]
        public MultiProductHeaderContentEnum Type { get; set; }
    }
}