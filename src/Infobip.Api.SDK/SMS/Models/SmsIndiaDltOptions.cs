using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Distributed Ledger Technology (DLT) specific parameters required for sending SMS to phone numbers registered in India.
    /// </summary>
    public class SmsIndiaDltOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsIndiaDltOptions" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsIndiaDltOptions() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsIndiaDltOptions" /> class.
        /// </summary>
        /// <param name="principalEntityId">Your assigned DTL principal entity ID.</param>
        /// <param name="contentTemplateId">Registered DTL content template ID which matches message you are sending. (optional)</param>
        public SmsIndiaDltOptions(string principalEntityId = default, string contentTemplateId = default)
        {
            PrincipalEntityId = principalEntityId ?? throw new ArgumentNullException(nameof(principalEntityId));
            ContentTemplateId = contentTemplateId;
        }

        /// <summary>
        /// Id of your registered DTL content template that matches this message&#39;s text.
        /// </summary>
        /// <value>Id of your registered DTL content template that matches this message&#39;s text.</value>
        [JsonProperty("contentTemplateId")]
        [StringLength(30)]
        public string ContentTemplateId { get; set; }

        /// <summary>
        /// Your assigned DTL principal entity id.
        /// </summary>
        /// <value>Your assigned DTL principal entity id.</value>
        [JsonProperty("principalEntityId")]
        [Required]
        [StringLength(30)]
        public string PrincipalEntityId { get; set; }
    }
}