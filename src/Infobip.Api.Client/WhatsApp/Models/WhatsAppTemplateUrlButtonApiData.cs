using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateUrlButtonApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplateUrlButtonApiData : WhatsAppTemplateButtonApiData, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateUrlButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateUrlButtonApiData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateUrlButtonApiData" /> class.
        /// </summary>
        /// <param name="url">URL to which the end-user will be directed when hitting the button. URL is expected to start with &#x60;https://&#x60; or &#x60;http://&#x60;. Can be static or dynamic. For dynamic URL registration, add a placeholder {{1}} at the end of the link. Example: &#x60;https://www.infobip.com/{{1}}&#x60; (required).</param>
        /// <param name="type">type.</param>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplateUrlButtonApiData(string url = default, SendTypeEnum? type = default, string text = default) : base()
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL to which the end-user will be directed when hitting the button. URL is expected to start with &#x60;https://&#x60; or &#x60;http://&#x60;. Can be static or dynamic. For dynamic URL registration, add a placeholder {{1}} at the end of the link. Example: &#x60;https://www.infobip.com/{{1}}&#x60;
        /// </summary>
        /// <value>URL to which the end-user will be directed when hitting the button. URL is expected to start with &#x60;https://&#x60; or &#x60;http://&#x60;. Can be static or dynamic. For dynamic URL registration, add a placeholder {{1}} at the end of the link. Example: &#x60;https://www.infobip.com/{{1}}&#x60;</value>
        [JsonProperty("url")]
        public string Url { get; set; }
        
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