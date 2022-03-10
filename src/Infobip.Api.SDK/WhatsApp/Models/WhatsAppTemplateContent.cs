using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// The content object to build a message that will be sent.
    /// </summary>
    public class WhatsAppTemplateContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateContent" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateContent() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateContent" /> class.
        /// </summary>
        /// <param name="templateName">Template name. Should only contain lowercase alphanumeric characters and underscores. (required).</param>
        /// <param name="templateData">templateData (required).</param>
        /// <param name="language">The code of language or locale to use. Must be the same code used when registering the template. (required).</param>
        public WhatsAppTemplateContent(string templateName = default, WhatsAppTemplateDataContent templateData = default, string language = default)
        {
            TemplateName = templateName ?? throw new ArgumentNullException(nameof(templateName));
            TemplateData = templateData ?? throw new ArgumentNullException(nameof(templateData));
            Language = language ?? throw new ArgumentNullException(nameof(language));
        }

        /// <summary>
        /// Template name. Should only contain lowercase alphanumeric characters and underscores.
        /// </summary>
        /// <value>Template name. Should only contain lowercase alphanumeric characters and underscores.</value>
        [JsonProperty("templateName")]
        [Required(ErrorMessage = "TemplateName is required")]
        [MinLength(1)]
        [MaxLength(512)]
        public string TemplateName { get; set; }

        /// <summary>
        /// Gets or Sets TemplateData
        /// </summary>
        [JsonProperty("templateData")]
        [Required(ErrorMessage = "TemplateData is required")]
        public WhatsAppTemplateDataContent TemplateData { get; set; }

        /// <summary>
        /// The code of language or locale to use. Must be the same code used when registering the template.
        /// </summary>
        /// <value>The code of language or locale to use. Must be the same code used when registering the template.</value>
        [JsonProperty("language")]
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; }
    }
}