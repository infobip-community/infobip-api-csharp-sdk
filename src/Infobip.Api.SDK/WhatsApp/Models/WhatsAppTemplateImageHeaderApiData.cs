using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateImageHeaderApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Format")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderApiData), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderApiData), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderApiData), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderApiData), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderApiData), "VIDEO")]
    public class WhatsAppTemplateImageHeaderApiData : WhatsAppTemplateHeaderApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateImageHeaderApiData" /> class.
        /// </summary>
        public WhatsAppTemplateImageHeaderApiData() : base(FormatEnum.Image)
        {
        }
    }
}