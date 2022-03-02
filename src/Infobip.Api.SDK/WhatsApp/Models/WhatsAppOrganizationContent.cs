using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Contains information about contact&#39;s company.
    /// </summary>
    public class WhatsAppOrganizationContent : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppOrganizationContent" /> class.
        /// </summary>
        /// <param name="company">Company name..</param>
        /// <param name="department">Department name..</param>
        /// <param name="title">Title value..</param>
        public WhatsAppOrganizationContent(string company = default, string department = default, string title = default)
        {
            Company = company;
            Department = department;
            Title = title;
        }

        /// <summary>
        /// Company name.
        /// </summary>
        /// <value>Company name.</value>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Department name.
        /// </summary>
        /// <value>Department name.</value>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// Title value.
        /// </summary>
        /// <value>Title value.</value>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}