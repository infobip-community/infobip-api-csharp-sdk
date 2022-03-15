using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template buttons. Can be either up to 3 &#x60;quick reply&#x60; buttons or up to 2 &#x60;call to action&#x60; buttons. Call to action buttons must be unique in type.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplateButtonApiData
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
        [Required(ErrorMessage = "Type is required")]
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
        [Required(ErrorMessage = "Text is required")]
        [MinLength(0)]
        [MaxLength(200)]
        public string Text { get; set; }
    }
}