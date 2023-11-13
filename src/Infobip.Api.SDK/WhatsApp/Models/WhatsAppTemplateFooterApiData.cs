using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Template structure.
    /// </summary>
    public class WhatsAppTemplateFooterApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateFooterApiData" /> class.
        /// </summary>
        /// <param name="text">Template footer. Plain text, up to 60 characters..</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhatsAppTemplateFooterApiData(string text = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
        /// <summary>
        /// Template footer. Plain text, up to 60 characters..
        /// </summary>
        /// <value>Template footer. Plain text, up to 60 characters..</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Footer text is required")]
        public string Text { get; set; }
    }
}
