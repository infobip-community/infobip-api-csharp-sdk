using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateLocationHeaderApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Format")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateDocumentHeaderApiData), "DOCUMENT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateImageHeaderApiData), "IMAGE")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateLocationHeaderApiData), "LOCATION")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateTextHeaderApiData), "TEXT")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateVideoHeaderApiData), "VIDEO")]
    public class WhatsAppTemplateLocationHeaderApiData : WhatsAppTemplateHeaderApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateLocationHeaderApiData" /> class.
        /// </summary>
        public WhatsAppTemplateLocationHeaderApiData() : base(FormatEnum.Location)
        {
        }
    }
}