using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template data. Values have to be set as registered in the template.
    /// </summary>
    public class WhatsAppTemplateDataContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateDataContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateDataContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateDataContent" /> class.
        /// </summary>
        /// <param name="body">body (required).</param>
        /// <param name="header">header.</param>
        /// <param name="buttons">Template buttons. Should be defined in correct order, only if &#x60;quick reply&#x60; or &#x60;dynamic URL&#x60; buttons have been registered. It can have up to three &#x60;quick reply&#x60; buttons or only one &#x60;dynamic URL&#x60; button..</param>
        public WhatsAppTemplateDataContent(WhatsAppTemplateBodyContent body = default, WhatsAppTemplateHeaderContent header = default, List<WhatsAppTemplateButtonContent> buttons = default)
        {
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Header = header;
            Buttons = buttons;
        }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [JsonProperty("body")]
        [Required(ErrorMessage = "Body is required")]
        public WhatsAppTemplateBodyContent Body { get; set; }

        /// <summary>
        /// Gets or Sets Header
        /// </summary>
        [JsonProperty("header")]
        public WhatsAppTemplateHeaderContent Header { get; set; }

        /// <summary>
        /// Template buttons. Should be defined in correct order, only if &#x60;quick reply&#x60; or &#x60;dynamic URL&#x60; buttons have been registered. It can have up to three &#x60;quick reply&#x60; buttons or only one &#x60;dynamic URL&#x60; button.
        /// </summary>
        /// <value>Template buttons. Should be defined in correct order, only if &#x60;quick reply&#x60; or &#x60;dynamic URL&#x60; buttons have been registered. It can have up to three &#x60;quick reply&#x60; buttons or only one &#x60;dynamic URL&#x60; button.</value>
        [JsonProperty("buttons")]
        public List<WhatsAppTemplateButtonContent> Buttons { get; set; }
    }
}