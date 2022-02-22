using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateUrlButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonContent), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonContent), "URL")]
    public class WhatsAppTemplateUrlButtonContent : WhatsAppTemplateButtonContent, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateUrlButtonContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateUrlButtonContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateUrlButtonContent" /> class.
        /// </summary>
        /// <param name="parameter">URL extension of a &#x60;dynamic URL&#x60; defined in the registered template. (required).</param>
        /// <param name="type">type (required).</param>
        public WhatsAppTemplateUrlButtonContent(string parameter = default, string type = default) : base()
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        /// <summary>
        /// URL extension of a &#x60;dynamic URL&#x60; defined in the registered template.
        /// </summary>
        /// <value>URL extension of a &#x60;dynamic URL&#x60; defined in the registered template.</value>
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
            yield break;
        }
    }
}