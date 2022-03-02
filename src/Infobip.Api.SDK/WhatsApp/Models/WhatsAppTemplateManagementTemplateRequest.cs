using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.WhatsApp.Models
{
    /// <summary>
    /// WhatsAppTemplateManagementTemplateRequest
    /// </summary>
    public class WhatsAppTemplateManagementTemplateRequest : IValidatableObject
    {
        /// <summary>
        /// The language code or locale to use. Multiple templates with different language codes can be registered under the same template name.
        /// </summary>
        /// <value>The language code or locale to use. Multiple templates with different language codes can be registered under the same template name.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageEnum
        {
            /// <summary>
            /// Enum Af for value: af
            /// </summary>
            [EnumMember(Value = "af")]
            Af = 1,

            /// <summary>
            /// Enum Sq for value: sq
            /// </summary>
            [EnumMember(Value = "sq")]
            Sq = 2,

            /// <summary>
            /// Enum Ar for value: ar
            /// </summary>
            [EnumMember(Value = "ar")]
            Ar = 3,

            /// <summary>
            /// Enum Az for value: az
            /// </summary>
            [EnumMember(Value = "az")]
            Az = 4,

            /// <summary>
            /// Enum Bn for value: bn
            /// </summary>
            [EnumMember(Value = "bn")]
            Bn = 5,

            /// <summary>
            /// Enum Bg for value: bg
            /// </summary>
            [EnumMember(Value = "bg")]
            Bg = 6,

            /// <summary>
            /// Enum Ca for value: ca
            /// </summary>
            [EnumMember(Value = "ca")]
            Ca = 7,

            /// <summary>
            /// Enum ZhCN for value: zh_CN
            /// </summary>
            [EnumMember(Value = "zh_CN")]
            ZhCN = 8,

            /// <summary>
            /// Enum ZhHK for value: zh_HK
            /// </summary>
            [EnumMember(Value = "zh_HK")]
            ZhHK = 9,

            /// <summary>
            /// Enum ZhTW for value: zh_TW
            /// </summary>
            [EnumMember(Value = "zh_TW")]
            ZhTW = 10,

            /// <summary>
            /// Enum Hr for value: hr
            /// </summary>
            [EnumMember(Value = "hr")]
            Hr = 11,

            /// <summary>
            /// Enum Cs for value: cs
            /// </summary>
            [EnumMember(Value = "cs")]
            Cs = 12,

            /// <summary>
            /// Enum Da for value: da
            /// </summary>
            [EnumMember(Value = "da")]
            Da = 13,

            /// <summary>
            /// Enum Nl for value: nl
            /// </summary>
            [EnumMember(Value = "nl")]
            Nl = 14,

            /// <summary>
            /// Enum En for value: en
            /// </summary>
            [EnumMember(Value = "en")]
            En = 15,

            /// <summary>
            /// Enum EnGB for value: en_GB
            /// </summary>
            [EnumMember(Value = "en_GB")]
            EnGB = 16,

            /// <summary>
            /// Enum EnUS for value: en_US
            /// </summary>
            [EnumMember(Value = "en_US")]
            EnUS = 17,

            /// <summary>
            /// Enum Et for value: et
            /// </summary>
            [EnumMember(Value = "et")]
            Et = 18,

            /// <summary>
            /// Enum Fil for value: fil
            /// </summary>
            [EnumMember(Value = "fil")]
            Fil = 19,

            /// <summary>
            /// Enum Fi for value: fi
            /// </summary>
            [EnumMember(Value = "fi")]
            Fi = 20,

            /// <summary>
            /// Enum Fr for value: fr
            /// </summary>
            [EnumMember(Value = "fr")]
            Fr = 21,

            /// <summary>
            /// Enum De for value: de
            /// </summary>
            [EnumMember(Value = "de")]
            De = 22,

            /// <summary>
            /// Enum El for value: el
            /// </summary>
            [EnumMember(Value = "el")]
            El = 23,

            /// <summary>
            /// Enum Gu for value: gu
            /// </summary>
            [EnumMember(Value = "gu")]
            Gu = 24,

            /// <summary>
            /// Enum Ha for value: ha
            /// </summary>
            [EnumMember(Value = "ha")]
            Ha = 25,

            /// <summary>
            /// Enum He for value: he
            /// </summary>
            [EnumMember(Value = "he")]
            He = 26,

            /// <summary>
            /// Enum Hi for value: hi
            /// </summary>
            [EnumMember(Value = "hi")]
            Hi = 27,

            /// <summary>
            /// Enum Hu for value: hu
            /// </summary>
            [EnumMember(Value = "hu")]
            Hu = 28,

            /// <summary>
            /// Enum Id for value: id
            /// </summary>
            [EnumMember(Value = "id")]
            Id = 29,

            /// <summary>
            /// Enum Ga for value: ga
            /// </summary>
            [EnumMember(Value = "ga")]
            Ga = 30,

            /// <summary>
            /// Enum It for value: it
            /// </summary>
            [EnumMember(Value = "it")]
            It = 31,

            /// <summary>
            /// Enum Ja for value: ja
            /// </summary>
            [EnumMember(Value = "ja")]
            Ja = 32,

            /// <summary>
            /// Enum Kn for value: kn
            /// </summary>
            [EnumMember(Value = "kn")]
            Kn = 33,

            /// <summary>
            /// Enum Kk for value: kk
            /// </summary>
            [EnumMember(Value = "kk")]
            Kk = 34,

            /// <summary>
            /// Enum Ko for value: ko
            /// </summary>
            [EnumMember(Value = "ko")]
            Ko = 35,

            /// <summary>
            /// Enum Lo for value: lo
            /// </summary>
            [EnumMember(Value = "lo")]
            Lo = 36,

            /// <summary>
            /// Enum Lv for value: lv
            /// </summary>
            [EnumMember(Value = "lv")]
            Lv = 37,

            /// <summary>
            /// Enum Lt for value: lt
            /// </summary>
            [EnumMember(Value = "lt")]
            Lt = 38,

            /// <summary>
            /// Enum Mk for value: mk
            /// </summary>
            [EnumMember(Value = "mk")]
            Mk = 39,

            /// <summary>
            /// Enum Ms for value: ms
            /// </summary>
            [EnumMember(Value = "ms")]
            Ms = 40,

            /// <summary>
            /// Enum Ml for value: ml
            /// </summary>
            [EnumMember(Value = "ml")]
            Ml = 41,

            /// <summary>
            /// Enum Mr for value: mr
            /// </summary>
            [EnumMember(Value = "mr")]
            Mr = 42,

            /// <summary>
            /// Enum Nb for value: nb
            /// </summary>
            [EnumMember(Value = "nb")]
            Nb = 43,

            /// <summary>
            /// Enum Fa for value: fa
            /// </summary>
            [EnumMember(Value = "fa")]
            Fa = 44,

            /// <summary>
            /// Enum Pl for value: pl
            /// </summary>
            [EnumMember(Value = "pl")]
            Pl = 45,

            /// <summary>
            /// Enum PtBR for value: pt_BR
            /// </summary>
            [EnumMember(Value = "pt_BR")]
            PtBR = 46,

            /// <summary>
            /// Enum PtPT for value: pt_PT
            /// </summary>
            [EnumMember(Value = "pt_PT")]
            PtPT = 47,

            /// <summary>
            /// Enum Pa for value: pa
            /// </summary>
            [EnumMember(Value = "pa")]
            Pa = 48,

            /// <summary>
            /// Enum Ro for value: ro
            /// </summary>
            [EnumMember(Value = "ro")]
            Ro = 49,

            /// <summary>
            /// Enum Ru for value: ru
            /// </summary>
            [EnumMember(Value = "ru")]
            Ru = 50,

            /// <summary>
            /// Enum Sr for value: sr
            /// </summary>
            [EnumMember(Value = "sr")]
            Sr = 51,

            /// <summary>
            /// Enum Sk for value: sk
            /// </summary>
            [EnumMember(Value = "sk")]
            Sk = 52,

            /// <summary>
            /// Enum Sl for value: sl
            /// </summary>
            [EnumMember(Value = "sl")]
            Sl = 53,

            /// <summary>
            /// Enum Es for value: es
            /// </summary>
            [EnumMember(Value = "es")]
            Es = 54,

            /// <summary>
            /// Enum EsAR for value: es_AR
            /// </summary>
            [EnumMember(Value = "es_AR")]
            EsAR = 55,

            /// <summary>
            /// Enum EsES for value: es_ES
            /// </summary>
            [EnumMember(Value = "es_ES")]
            EsES = 56,

            /// <summary>
            /// Enum EsMX for value: es_MX
            /// </summary>
            [EnumMember(Value = "es_MX")]
            EsMX = 57,

            /// <summary>
            /// Enum Sw for value: sw
            /// </summary>
            [EnumMember(Value = "sw")]
            Sw = 58,

            /// <summary>
            /// Enum Sv for value: sv
            /// </summary>
            [EnumMember(Value = "sv")]
            Sv = 59,

            /// <summary>
            /// Enum Ta for value: ta
            /// </summary>
            [EnumMember(Value = "ta")]
            Ta = 60,

            /// <summary>
            /// Enum Te for value: te
            /// </summary>
            [EnumMember(Value = "te")]
            Te = 61,

            /// <summary>
            /// Enum Th for value: th
            /// </summary>
            [EnumMember(Value = "th")]
            Th = 62,

            /// <summary>
            /// Enum Tr for value: tr
            /// </summary>
            [EnumMember(Value = "tr")]
            Tr = 63,

            /// <summary>
            /// Enum Uk for value: uk
            /// </summary>
            [EnumMember(Value = "uk")]
            Uk = 64,

            /// <summary>
            /// Enum Ur for value: ur
            /// </summary>
            [EnumMember(Value = "ur")]
            Ur = 65,

            /// <summary>
            /// Enum Uz for value: uz
            /// </summary>
            [EnumMember(Value = "uz")]
            Uz = 66,

            /// <summary>
            /// Enum Vi for value: vi
            /// </summary>
            [EnumMember(Value = "vi")]
            Vi = 67,

            /// <summary>
            /// Enum Unknown for value: unknown
            /// </summary>
            [EnumMember(Value = "unknown")]
            Unknown = 68

        }


        /// <summary>
        /// The language code or locale to use. Multiple templates with different language codes can be registered under the same template name.
        /// </summary>
        /// <value>The language code or locale to use. Multiple templates with different language codes can be registered under the same template name.</value>
        [JsonProperty("language")]
        public LanguageEnum Language { get; set; }
        /// <summary>
        /// Category of the template.
        /// </summary>
        /// <value>Category of the template.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryEnum
        {
            /// <summary>
            /// Enum ACCOUNTUPDATE for value: ACCOUNT_UPDATE
            /// </summary>
            [EnumMember(Value = "ACCOUNT_UPDATE")]
            ACCOUNTUPDATE = 1,

            /// <summary>
            /// Enum PAYMENTUPDATE for value: PAYMENT_UPDATE
            /// </summary>
            [EnumMember(Value = "PAYMENT_UPDATE")]
            PAYMENTUPDATE = 2,

            /// <summary>
            /// Enum PERSONALFINANCEUPDATE for value: PERSONAL_FINANCE_UPDATE
            /// </summary>
            [EnumMember(Value = "PERSONAL_FINANCE_UPDATE")]
            PERSONALFINANCEUPDATE = 3,

            /// <summary>
            /// Enum SHIPPINGUPDATE for value: SHIPPING_UPDATE
            /// </summary>
            [EnumMember(Value = "SHIPPING_UPDATE")]
            SHIPPINGUPDATE = 4,

            /// <summary>
            /// Enum RESERVATIONUPDATE for value: RESERVATION_UPDATE
            /// </summary>
            [EnumMember(Value = "RESERVATION_UPDATE")]
            RESERVATIONUPDATE = 5,

            /// <summary>
            /// Enum ISSUERESOLUTION for value: ISSUE_RESOLUTION
            /// </summary>
            [EnumMember(Value = "ISSUE_RESOLUTION")]
            ISSUERESOLUTION = 6,

            /// <summary>
            /// Enum APPOINTMENTUPDATE for value: APPOINTMENT_UPDATE
            /// </summary>
            [EnumMember(Value = "APPOINTMENT_UPDATE")]
            APPOINTMENTUPDATE = 7,

            /// <summary>
            /// Enum TRANSPORTATIONUPDATE for value: TRANSPORTATION_UPDATE
            /// </summary>
            [EnumMember(Value = "TRANSPORTATION_UPDATE")]
            TRANSPORTATIONUPDATE = 8,

            /// <summary>
            /// Enum TICKETUPDATE for value: TICKET_UPDATE
            /// </summary>
            [EnumMember(Value = "TICKET_UPDATE")]
            TICKETUPDATE = 9,

            /// <summary>
            /// Enum ALERTUPDATE for value: ALERT_UPDATE
            /// </summary>
            [EnumMember(Value = "ALERT_UPDATE")]
            ALERTUPDATE = 10,

            /// <summary>
            /// Enum AUTOREPLY for value: AUTO_REPLY
            /// </summary>
            [EnumMember(Value = "AUTO_REPLY")]
            AUTOREPLY = 11

        }


        /// <summary>
        /// Category of the template.
        /// </summary>
        /// <value>Category of the template.</value>
        [JsonProperty("category")]
        public CategoryEnum Category { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateManagementTemplateRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected WhatsAppTemplateManagementTemplateRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WhatsAppTemplateManagementTemplateRequest" /> class.
        /// </summary>
        /// <param name="name">Template name. Must only contain lowercase alphanumeric characters and underscores. (required).</param>
        /// <param name="language">The language code or locale to use. Multiple templates with different language codes can be registered under the same template name. (required).</param>
        /// <param name="category">Category of the template. (required).</param>
        /// <param name="structure">structure (required).</param>
        public WhatsAppTemplateManagementTemplateRequest(string name = default, LanguageEnum language = default, CategoryEnum category = default, WhatsAppTemplateTemplateStructureApiData structure = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Language = language;
            Category = category;
            Structure = structure ?? throw new ArgumentNullException(nameof(structure));
        }

        /// <summary>
        /// Template name. Must only contain lowercase alphanumeric characters and underscores.
        /// </summary>
        /// <value>Template name. Must only contain lowercase alphanumeric characters and underscores.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Structure
        /// </summary>
        [JsonProperty("structure")]
        public WhatsAppTemplateTemplateStructureApiData Structure { get; set; }

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