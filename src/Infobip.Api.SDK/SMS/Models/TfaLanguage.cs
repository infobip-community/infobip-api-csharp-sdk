﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Defines TfaLanguage
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TfaLanguage
    {
        /// <summary>
        /// Enum En for value: en
        /// </summary>
        [EnumMember(Value = "en")]
        En = 1,

        /// <summary>
        /// Enum Es for value: es
        /// </summary>
        [EnumMember(Value = "es")]
        Es = 2,

        /// <summary>
        /// Enum Ca for value: ca
        /// </summary>
        [EnumMember(Value = "ca")]
        Ca = 3,

        /// <summary>
        /// Enum Da for value: da
        /// </summary>
        [EnumMember(Value = "da")]
        Da = 4,

        /// <summary>
        /// Enum Nl for value: nl
        /// </summary>
        [EnumMember(Value = "nl")]
        Nl = 5,

        /// <summary>
        /// Enum Fr for value: fr
        /// </summary>
        [EnumMember(Value = "fr")]
        Fr = 6,

        /// <summary>
        /// Enum De for value: de
        /// </summary>
        [EnumMember(Value = "de")]
        De = 7,

        /// <summary>
        /// Enum It for value: it
        /// </summary>
        [EnumMember(Value = "it")]
        It = 8,

        /// <summary>
        /// Enum Ja for value: ja
        /// </summary>
        [EnumMember(Value = "ja")]
        Ja = 9,

        /// <summary>
        /// Enum Ko for value: ko
        /// </summary>
        [EnumMember(Value = "ko")]
        Ko = 10,

        /// <summary>
        /// Enum No for value: no
        /// </summary>
        [EnumMember(Value = "no")]
        No = 11,

        /// <summary>
        /// Enum Pl for value: pl
        /// </summary>
        [EnumMember(Value = "pl")]
        Pl = 12,

        /// <summary>
        /// Enum Ru for value: ru
        /// </summary>
        [EnumMember(Value = "ru")]
        Ru = 13,

        /// <summary>
        /// Enum Sv for value: sv
        /// </summary>
        [EnumMember(Value = "sv")]
        Sv = 14,

        /// <summary>
        /// Enum Fi for value: fi
        /// </summary>
        [EnumMember(Value = "fi")]
        Fi = 15,

        /// <summary>
        /// Enum Hr for value: hr
        /// </summary>
        [EnumMember(Value = "hr")]
        Hr = 16,

        /// <summary>
        /// Enum Sl for value: sl
        /// </summary>
        [EnumMember(Value = "sl")]
        Sl = 17,

        /// <summary>
        /// Enum PtPt for value: pt-pt
        /// </summary>
        [EnumMember(Value = "pt-pt")]
        PtPt = 18,

        /// <summary>
        /// Enum PtBr for value: pt-br
        /// </summary>
        [EnumMember(Value = "pt-br")]
        PtBr = 19,

        /// <summary>
        /// Enum ZhCn for value: zh-cn
        /// </summary>
        [EnumMember(Value = "zh-cn")]
        ZhCn = 20,

        /// <summary>
        /// Enum ZhTw for value: zh-tw
        /// </summary>
        [EnumMember(Value = "zh-tw")]
        ZhTw = 21
    }
}