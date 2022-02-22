using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateTextHeaderContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderContent), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateImageHeaderContent), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateLocationHeaderContent), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(SendWhatsAppTemplateTextHeaderContent), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderContent), "VIDEO")]
    public class SendWhatsAppTemplateTextHeaderContent : WhatsAppTemplateHeaderContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWhatsAppTemplateTextHeaderContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected SendWhatsAppTemplateTextHeaderContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWhatsAppTemplateTextHeaderContent" /> class.
        /// </summary>
        /// <param name="placeholder">Value of a placeholder in the text header. (required).</param>
        /// <param name="type">type (required).</param>
        public SendWhatsAppTemplateTextHeaderContent(string placeholder = default, string type = default) : base()
        {
            Placeholder = placeholder ?? throw new ArgumentNullException(nameof(placeholder));
        }

        /// <summary>
        /// Value of a placeholder in the text header.
        /// </summary>
        /// <value>Value of a placeholder in the text header.</value>
        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        
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
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }
}