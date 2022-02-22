using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// Template buttons. Can be either up to 3 &#x60;quick reply&#x60; buttons or up to 2 &#x60;call to action&#x60; buttons. Call to action buttons must be unique in type.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplateButtonApiData : IValidatableObject
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SendTypeEnum
        {
            /// <summary>
            /// Enum PHONENUMBER for value: PHONE_NUMBER
            /// </summary>
            [EnumMember(Value = "PHONE_NUMBER")]
            Phonenumber = 1,

            /// <summary>
            /// Enum URL for value: URL
            /// </summary>
            [EnumMember(Value = "URL")]
            Url = 2,

            /// <summary>
            /// Enum QUICKREPLY for value: QUICK_REPLY
            /// </summary>
            [EnumMember(Value = "QUICK_REPLY")]
            Quickreply = 3

        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty("type")]
        public SendTypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateButtonApiData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateButtonApiData" /> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplateButtonApiData(SendTypeEnum? type = default, string text = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Type = type;
        }

        /// <summary>
        /// Button text.
        /// </summary>
        /// <value>Button text.</value>
        [JsonProperty("text")]
        public string Text { get; set; }
        
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
            // Text (string) maxLength
            if (Text != null && Text.Length > 200)
            {
                yield return new ValidationResult("Invalid value for Text, length must be less than 200.", new[] { "Text" });
            }

            // Text (string) minLength
            if (Text != null && Text.Length <= 0)
            {
                yield return new ValidationResult("Invalid value for Text, length must be greater than 0.", new[] { "Text" });
            }
        }
    }
}