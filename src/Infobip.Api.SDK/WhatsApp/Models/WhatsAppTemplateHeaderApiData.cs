using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template header. Can be &#x60;image&#x60;, &#x60;document&#x60;, &#x60;video&#x60;, &#x60;location&#x60; or &#x60;text&#x60;.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Format")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderApiData), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderApiData), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderApiData), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderApiData), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderApiData), "VIDEO")]
    public class WhatsAppTemplateHeaderApiData : IValidatableObject
    {
        /// <summary>
        /// Defines Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SendFormatEnum
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
        /// Gets or Sets Format
        /// </summary>
        [JsonProperty("format")]
        public SendFormatEnum? Format { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateHeaderApiData" /> class.
        /// </summary>
        /// <param name="format">format.</param>
        public WhatsAppTemplateHeaderApiData(SendFormatEnum? format = default)
        {
            Format = format;
        }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}