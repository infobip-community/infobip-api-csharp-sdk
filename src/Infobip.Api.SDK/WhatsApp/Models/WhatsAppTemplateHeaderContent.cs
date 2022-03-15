using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template header. Should be defined, only if placeholders or media have been registered in the template&#39;s header.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Defines Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            Text = 1,

            /// <summary>
            /// Enum IMAGE for value: IMAGE
            /// </summary>
            [EnumMember(Value = "IMAGE")]
            Image = 2,

            /// <summary>
            /// Enum VIDEO for value: VIDEO
            /// </summary>
            [EnumMember(Value = "VIDEO")]
            Video = 3,

            /// <summary>
            /// Enum DOCUMENT for value: DOCUMENT
            /// </summary>
            [EnumMember(Value = "DOCUMENT")]
            Document = 4,

            /// <summary>
            /// Enum LOCATION for value: LOCATION
            /// </summary>
            [EnumMember(Value = "LOCATION")]
            Location = 5
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateHeaderContent" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateHeaderContent(TypeEnum? type = default)
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