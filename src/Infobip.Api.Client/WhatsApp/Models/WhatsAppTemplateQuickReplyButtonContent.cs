using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateQuickReplyButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonContent), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonContent), "URL")]
    public class WhatsAppTemplateQuickReplyButtonContent : WhatsAppTemplateButtonContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateQuickReplyButtonContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonContent" /> class.
        /// </summary>
        /// <param name="parameter">Payload of a &#x60;quick reply&#x60; button. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateQuickReplyButtonContent(string parameter = default, string type = default) : base()
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        /// <summary>
        /// Payload of a &#x60;quick reply&#x60; button.
        /// </summary>
        /// <value>Payload of a &#x60;quick reply&#x60; button.</value>
        [JsonProperty("parameter")]
        public string Parameter { get; set; }
        
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
            // Parameter (string) maxLength
            if (Parameter != null && Parameter.Length > 128)
            {
                yield return new ValidationResult("Invalid value for Parameter, length must be less than 128.", new[] { "Parameter" });
            }

            // Parameter (string) minLength
            if (Parameter != null && Parameter.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Parameter, length must be greater than 1.", new[] { "Parameter" });
            }

            yield break;
        }
    }
}