using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// Contains information about contact&#39;s name.
    /// </summary>
    public class WhatsAppNameContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppNameContent" /> class.
        /// </summary>
        [JsonConstructor]
        public WhatsAppNameContent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppNameContent" /> class.
        /// </summary>
        /// <param name="firstName">Contact&#39;s first name. (required).</param>
        /// <param name="lastName">Contact&#39;s last name..</param>
        /// <param name="middleName">Contact&#39;s middle name..</param>
        /// <param name="nameSuffix">Contact&#39;s name suffix..</param>
        /// <param name="namePrefix">Contact&#39;s name prefix..</param>
        /// <param name="formattedName">Contact&#39;s full name as it normally appears. (required).</param>
        public WhatsAppNameContent(string firstName = default, string lastName = default, string middleName = default, string nameSuffix = default, string namePrefix = default, string formattedName = default)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            FormattedName = formattedName ?? throw new ArgumentNullException(formattedName);
            LastName = lastName;
            MiddleName = middleName;
            NameSuffix = nameSuffix;
            NamePrefix = namePrefix;
        }

        /// <summary>
        /// Contact&#39;s first name.
        /// </summary>
        /// <value>Contact&#39;s first name.</value>
        [JsonProperty("firstName")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Contact&#39;s last name.
        /// </summary>
        /// <value>Contact&#39;s last name.</value>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Contact&#39;s middle name.
        /// </summary>
        /// <value>Contact&#39;s middle name.</value>
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Contact&#39;s name suffix.
        /// </summary>
        /// <value>Contact&#39;s name suffix.</value>
        [JsonProperty("nameSuffix")]
        public string NameSuffix { get; set; }

        /// <summary>
        /// Contact&#39;s name prefix.
        /// </summary>
        /// <value>Contact&#39;s name prefix.</value>
        [JsonProperty("namePrefix")]
        public string NamePrefix { get; set; }

        /// <summary>
        /// Contact&#39;s full name as it normally appears.
        /// </summary>
        /// <value>Contact&#39;s full name as it normally appears.</value>
        [JsonProperty("formattedName")]
        [Required(ErrorMessage = "FormattedName is required")]
        public string FormattedName { get; set; }
    }
}