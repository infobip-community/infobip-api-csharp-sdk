using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplatePhoneNumberButtonApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplatePhoneNumberButtonApiData : WhatsAppTemplateButtonApiData, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplatePhoneNumberButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplatePhoneNumberButtonApiData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplatePhoneNumberButtonApiData" /> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number to which a phone call would be placed by end-user when hitting the button. (required).</param>
        /// <param name="type">type.</param>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplatePhoneNumberButtonApiData(string phoneNumber = default, SendTypeEnum? type = default, string text = default) : base(type, text)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        /// <summary>
        /// Phone number to which a phone call would be placed by end-user when hitting the button.
        /// </summary>
        /// <value>Phone number to which a phone call would be placed by end-user when hitting the button.</value>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        
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