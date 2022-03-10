using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateUrlButtonContent
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonContent), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonContent), "URL")]
    public class WhatsAppTemplateUrlButtonContent : WhatsAppTemplateButtonContent
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
        public WhatsAppTemplateUrlButtonContent(string parameter = default) : base(TypeEnum.Url)
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
        }

        /// <summary>
        /// URL extension of a &#x60;dynamic URL&#x60; defined in the registered template.
        /// </summary>
        /// <value>URL extension of a &#x60;dynamic URL&#x60; defined in the registered template.</value>
        [JsonProperty("parameter")]
        [Required(ErrorMessage = "Parameter is required")]
        public string Parameter { get; set; }
    }
}