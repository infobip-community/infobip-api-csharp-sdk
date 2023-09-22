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
    public class WhatsAppTemplateBodyApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateBodyApiData" /> class.
        /// </summary>
        /// <param name="text">Template body. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}... (required).</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WhatsAppTemplateBodyApiData(string text = default)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
        /// <summary>
        /// Template body text. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}...
        /// </summary>
        /// <value>Template body text. Can be registered as plain text or text with placeholders. Placeholders have to be correctly formatted and in the correct order, regardless of other sections. Example: {{1}}, {{2}}, {{3}}...</value>
        [JsonProperty("text")]
        [Required(ErrorMessage = "Body text is required")]
        public string Text { get; set; }
    }
}
