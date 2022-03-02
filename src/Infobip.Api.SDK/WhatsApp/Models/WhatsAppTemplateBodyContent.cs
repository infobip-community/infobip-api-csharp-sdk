using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template body.
    /// </summary>
    public class WhatsAppTemplateBodyContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateBodyContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateBodyContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateBodyContent" /> class.
        /// </summary>
        /// <param name="placeholders">Template&#39;s parameters values ordered as registered in the template. The value must not be null, but can be an empty array if the template was registered without placeholders. Values within the array must not be null or empty. (required).</param>
        public WhatsAppTemplateBodyContent(List<string> placeholders = default)
        {
            Placeholders = placeholders ?? throw new ArgumentNullException(nameof(placeholders));
        }

        /// <summary>
        /// Template&#39;s parameters values ordered as registered in the template. The value must not be null, but can be an empty array if the template was registered without placeholders. Values within the array must not be null or empty.
        /// </summary>
        /// <value>Template&#39;s parameters values ordered as registered in the template. The value must not be null, but can be an empty array if the template was registered without placeholders. Values within the array must not be null or empty.</value>
        [JsonProperty("placeholders")]
        public List<string> Placeholders { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}