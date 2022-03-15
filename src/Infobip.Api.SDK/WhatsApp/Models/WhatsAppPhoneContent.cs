using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Array of phones information.
    /// </summary>
    public class WhatsAppPhoneContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppPhoneContent" /> class.
        /// </summary>
        [JsonConstructor]
        public WhatsAppPhoneContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppPhoneContent" /> class.
        /// </summary>
        /// <param name="phone">Contact&#39;s phone number..</param>
        /// <param name="type">type.</param>
        /// <param name="waId">Contact&#39;s WhatsApp ID..</param>
        public WhatsAppPhoneContent(string phone = default, WhatsAppPhoneType type = WhatsAppPhoneType.Home, string waId = default)
        {
            Phone = phone;
            Type = type;
            WaId = waId;
        }

        /// <summary>
        /// Contact&#39;s phone number.
        /// </summary>
        /// <value>Contact&#39;s phone number.</value>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets phone number Type.
        /// </summary>
        [JsonProperty("type")]
        public WhatsAppPhoneType Type { get; set; }

        /// <summary>
        /// Contact&#39;s WhatsApp ID.
        /// </summary>
        /// <value>Contact&#39;s WhatsApp ID.</value>
        [JsonProperty("waId")]
        public string WaId { get; set; }
    }
}