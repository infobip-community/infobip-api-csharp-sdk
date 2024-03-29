﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Message action.
    /// </summary>
    public class WhatsAppInteractiveButtonsActionContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsActionContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppInteractiveButtonsActionContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppInteractiveButtonsActionContent" /> class.
        /// </summary>
        /// <param name="buttons">An array of buttons sent in a message. It can have up to three buttons. (required).</param>
        public WhatsAppInteractiveButtonsActionContent(List<WhatsAppInteractiveButtonContent> buttons = default)
        {
            Buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
        }

        /// <summary>
        /// An array of buttons sent in a message. It can have up to three buttons.
        /// </summary>
        /// <value>An array of buttons sent in a message. It can have up to three buttons.</value>
        [JsonProperty("buttons")]
        [MinLength(1)]
        [MaxLength(3)]
        public List<WhatsAppInteractiveButtonContent> Buttons { get; set; }
    }
}