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
    public class WhatsAppTemplateQuickReplyButtonApiData : WhatsAppTemplateButtonApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateQuickReplyButtonApiData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateQuickReplyButtonApiData" /> class.
        /// </summary>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplateQuickReplyButtonApiData(string text = default) : base(SendTypeEnum.Quickreply, text)
        {
        }
    }
}