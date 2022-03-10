using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class WhatsAppTemplateTextHeaderContent : WhatsAppTemplateHeaderContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateTextHeaderContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateTextHeaderContent" /> class.
        /// </summary>
        /// <param name="placeholder">Value of a placeholder in the text header. (required).</param>
        public WhatsAppTemplateTextHeaderContent(string placeholder = default) : base(TypeEnum.Text)
        {
            Placeholder = placeholder ?? throw new ArgumentNullException(nameof(placeholder));
        }

        /// <summary>
        /// Value of a placeholder in the text header.
        /// </summary>
        /// <value>Value of a placeholder in the text header.</value>
        [JsonProperty("placeholder")]
        [Required(ErrorMessage = "Placeholder is required")]
        public string Placeholder { get; set; }
    }
}