﻿using System;
using System.ComponentModel.DataAnnotations;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplatePhoneNumberButtonApiData
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplatePhoneNumberButtonApiData), "PHONE_NUMBER")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateQuickReplyButtonApiData), "QUICK_REPLY")]
    [JsonSubtypes.KnownSubType(typeof(WhatsAppTemplateUrlButtonApiData), "URL")]
    public class WhatsAppTemplatePhoneNumberButtonApiData : WhatsAppTemplateButtonApiData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplatePhoneNumberButtonApiData" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplatePhoneNumberButtonApiData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplatePhoneNumberButtonApiData" /> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number to which a phone call would be placed by end-user when hitting the button. (required).</param>
        /// <param name="text">Button text. (required).</param>
        public WhatsAppTemplatePhoneNumberButtonApiData(string phoneNumber = default, string text = default) : base(SendTypeEnum.Phonenumber, text)
        {
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        /// <summary>
        /// Phone number to which a phone call would be placed by end-user when hitting the button.
        /// </summary>
        /// <value>Phone number to which a phone call would be placed by end-user when hitting the button.</value>
        [JsonProperty("phoneNumber")]
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}