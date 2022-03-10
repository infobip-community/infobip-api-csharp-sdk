using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template structure.
    /// </summary>
    public class WhatsAppTemplateTemplateStructureApiData
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SendTypeEnum
        {
            /// <summary>
            /// Enum TEXT for value: TEXT
            /// </summary>
            [EnumMember(Value = "TEXT")]
            Text = 1,

            /// <summary>
            /// Enum MEDIA for value: MEDIA
            /// </summary>
            [EnumMember(Value = "MEDIA")]
            Media = 2,

            /// <summary>
            /// Enum UNSUPPORTED for value: UNSUPPORTED
            /// </summary>
            [EnumMember(Value = "UNSUPPORTED")]
            Unsupported = 3

        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public SendTypeEnum? Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTemplateStructureApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateTemplateStructureApiData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTemplateStructureApiData" /> class.
        /// </summary>
        /// <param name="header">header.</param>
        /// <param name="body">Template body. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}... (required).</param>
        /// <param name="footer">Template footer. Plain text, up to 60 characters..</param>
        /// <param name="buttons">Template buttons. Can be either up to 3 &#x60;quick reply&#x60; buttons or up to 2 &#x60;call to action&#x60; buttons. Call to action buttons must be unique in type..</param>
        public WhatsAppTemplateTemplateStructureApiData(WhatsAppTemplateHeaderApiData header = default, string body = default, string footer = default, List<WhatsAppTemplateButtonApiData> buttons = default)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Header = header;
            Footer = footer;
            Buttons = buttons;
        }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [JsonProperty("header")]
        public WhatsAppTemplateHeaderApiData Header { get; set; }

        /// <summary>
        /// Template body. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}...
        /// </summary>
        /// <value>Template body. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}...</value>
        [JsonProperty("body")]
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        /// <summary>
        /// Template footer. Plain text, up to 60 characters.
        /// </summary>
        /// <value>Template footer. Plain text, up to 60 characters.</value>
        [JsonProperty("footer")]
        [MaxLength(60)]
        public string Footer { get; set; }

        /// <summary>
        /// Template buttons. Can be either up to 3 &#x60;quick reply&#x60; buttons or up to 2 &#x60;call to action&#x60; buttons. Call to action buttons must be unique in type.
        /// </summary>
        /// <value>Template buttons. Can be either up to 3 &#x60;quick reply&#x60; buttons or up to 2 &#x60;call to action&#x60; buttons. Call to action buttons must be unique in type.</value>
        [JsonProperty("buttons")]
        [MinLength(1)]
        [MaxLength(3)]
        public List<WhatsAppTemplateButtonApiData> Buttons { get; set; }
    }
}