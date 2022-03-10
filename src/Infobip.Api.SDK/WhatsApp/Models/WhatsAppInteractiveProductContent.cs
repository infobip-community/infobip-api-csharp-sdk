using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppInteractiveProductContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveProductContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveProductContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveProductContent" /> class.
        /// </summary>
        /// <param name="action">action (required).</param>
        /// <param name="body">body.</param>
        /// <param name="footer">footer.</param>
        public WhatsAppInteractiveProductContent(WhatsAppInteractiveProductActionContent action = default, WhatsAppInteractiveBodyContent body = default, WhatsAppInteractiveFooterContent footer = default)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Body = body;
            Footer = footer;
        }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [JsonProperty("action")]
        [Required(ErrorMessage = "Action is required")]
        public WhatsAppInteractiveProductActionContent Action { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [JsonProperty("body")]
        public WhatsAppInteractiveBodyContent Body { get; set; }

        /// <summary>
        /// Gets or Sets Footer
        /// </summary>
        [JsonProperty("footer")]
        public WhatsAppInteractiveFooterContent Footer { get; set; }
    }
}