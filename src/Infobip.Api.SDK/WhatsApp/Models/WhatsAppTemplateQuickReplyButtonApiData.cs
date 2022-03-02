using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateQuickReplyButtonApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplateQuickReplyButtonApiData : WhatsAppTemplateButtonApiData, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateQuickReplyButtonApiData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonApiData" /> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplateQuickReplyButtonApiData(SendTypeEnum? type = default, string text = default) : base()
        {
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
            foreach (var x in BaseValidate(validationContext))
            {
                yield return x;
            }
            yield break;
        }
    }
}