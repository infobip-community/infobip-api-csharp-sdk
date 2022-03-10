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
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppInteractiveButtonsVideoHeaderContent), "VIDEO")]
    public class WhatsAppInteractiveButtonsHeaderContent
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InteractiveHeaderContentEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            Text = 1,

            /// <summary>
            /// Enum VIDEO for value: VIDEO
            /// </summary>
            [EnumMember(Value = "VIDEO")]
            Video = 2,

            /// <summary>
            /// Enum IMAGE for value: IMAGE
            /// </summary>
            [EnumMember(Value = "IMAGE")]
            Image = 3,

            /// <summary>
            /// Enum DOCUMENT for value: DOCUMENT
            /// </summary>
            [EnumMember(Value = "DOCUMENT")]
            Document = 4
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsHeaderContent" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public WhatsAppInteractiveButtonsHeaderContent(InteractiveHeaderContentEnum? type = default)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        [Required(ErrorMessage = "Header Content Type is required")]
        public InteractiveHeaderContentEnum Type { get; set; }
    }
}