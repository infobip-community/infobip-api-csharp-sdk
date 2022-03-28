using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaPinCodeResponse
    /// </summary>
    public class TfaPinCodeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaPinCodeResponse" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaPinCodeResponse() { }

        /// <summary>
        /// Call status.
        /// </summary>
        /// <value>Call status.</value>
        [JsonProperty("callStatus")]
        public string CallStatus { get; set; }

        /// <summary>
        /// Status of sent [Number Lookup](https://www.infobip.com/docs/number-lookup). Number Lookup status can have one of the following values: NC_DESTINATION_UNKNOWN, NC_DESTINATION_REACHABLE, NC_DESTINATION_NOT_REACHABLE, NC_NOT_CONFIGURED. Contact your Account Manager, if you get the NC_NOT_CONFIGURED status. SMS will not be sent only if Number Lookup status is NC_NOT_REACHABLE.
        /// </summary>
        [JsonProperty("ncStatus")]
        public string NcStatus { get; set; }

        /// <summary>
        /// Sent PIN code ID.
        /// </summary>
        [JsonProperty("pinId")]
        public string PinId { get; set; }

        /// <summary>
        /// Sent SMS status. Can have one of the following values: MESSAGE_SENT, MESSAGE_NOT_SENT.
        /// </summary>
        [JsonProperty("smsStatus")]
        public string SmsStatus { get; set; }

        /// <summary>
        /// Phone number to which the 2FA message will be sent. Example: 41793026727.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
    }
}
