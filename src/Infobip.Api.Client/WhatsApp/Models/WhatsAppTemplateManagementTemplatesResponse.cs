using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infobip.Api.Client.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateManagementTemplatesResponse
    /// </summary>
    public class WhatsAppTemplateManagementTemplatesResponse
    {
        /// <summary>
        /// List of all templates for given sender.
        /// </summary>
        /// <value>List of all templates for given sender.</value>
        [JsonProperty("templates")]
        public List<WhatsAppTemplateManagementTemplateResponse> Templates { get; set; }
    }
}