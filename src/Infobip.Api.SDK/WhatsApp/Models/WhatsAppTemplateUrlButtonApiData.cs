using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateUrlButtonApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplateUrlButtonApiData : WhatsAppTemplateButtonApiData
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
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplateUrlButtonApiData(string url = default, string text = default) : base(SendTypeEnum.Url, text)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// URL to which the end-user will be directed when hitting the button. URL is expected to start with &#x60;https://&#x60; or &#x60;http://&#x60;. Can be static or dynamic. For dynamic URL registration, add a placeholder {{1}} at the end of the link. Example: &#x60;https://www.infobip.com/{{1}}&#x60;
        /// </summary>
        /// <value>URL to which the end-user will be directed when hitting the button. URL is expected to start with &#x60;https://&#x60; or &#x60;http://&#x60;. Can be static or dynamic. For dynamic URL registration, add a placeholder {{1}} at the end of the link. Example: &#x60;https://www.infobip.com/{{1}}&#x60;</value>
        [JsonProperty("url")]
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
    }
}