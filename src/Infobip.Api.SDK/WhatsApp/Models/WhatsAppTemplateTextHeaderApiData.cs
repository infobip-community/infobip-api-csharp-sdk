using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateTextHeaderApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Format")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderApiData), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderApiData), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderApiData), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderApiData), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderApiData), "VIDEO")]
    public class WhatsAppTemplateTextHeaderApiData : WhatsAppTemplateHeaderApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTextHeaderApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateTextHeaderApiData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTextHeaderApiData" /> class.
        /// </summary>
        /// <param name="text">Template header text. Can contain up to 60 characters, with one placeholder {{1}}. (required).</param>
        /// <param name="format">format.</param>
        public WhatsAppTemplateTextHeaderApiData(string text = default, FormatEnum? format = default) : base(format)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Template header text. Can contain up to 60 characters, with one placeholder {{1}}.
        /// </summary>
        /// <value>Template header text. Can contain up to 60 characters, with one placeholder {{1}}.</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }
    }
}