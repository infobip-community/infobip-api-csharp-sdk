using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// TfaApplicationResponse
    /// </summary>
    public class TfaApplicationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationResponse" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaApplicationResponse() { }

        /// <summary>
        /// 2FA application ID.
        /// </summary>
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Created 2FA application configuration.
        /// </summary>
        [JsonProperty("configuration")]
        public TfaApplicationConfiguration Configuration { get; set; }

        /// <summary>
        /// Indicates if the created application is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 2FA application name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// TfaApplicationConfiguration
    /// </summary>
    public class TfaApplicationConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationConfiguration" /> class.
        /// </summary>
        [JsonConstructor]
        protected TfaApplicationConfiguration() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TfaApplicationConfiguration" /> class.
        /// </summary>
        /// <param name="allowMultiplePinVerifications"></param>
        /// <param name="pinAttempts"></param>
        /// <param name="pinTimeToLive"></param>
        /// <param name="sendPinPerApplicationLimit"></param>
        /// <param name="sendPinPerPhoneNumberLimit"></param>
        /// <param name="verifyPinLimit"></param>
        public TfaApplicationConfiguration(bool allowMultiplePinVerifications = true, int pinAttempts = 10,
            string pinTimeToLive = "15m", string sendPinPerApplicationLimit = "10000/1d",
            string sendPinPerPhoneNumberLimit = "3/1d", string verifyPinLimit = "1/3s")
        {
            AllowMultiplePinVerifications = allowMultiplePinVerifications;
            PinAttempts = pinAttempts;
            PinTimeToLive = pinTimeToLive ?? "15m";
            SendPinPerApplicationLimit = sendPinPerApplicationLimit ?? "10000/1d";
            SendPinPerPhoneNumberLimit = sendPinPerPhoneNumberLimit ?? "3/1d";
            VerifyPinLimit = verifyPinLimit ?? "1/3s";
        }

        /// <summary>
        /// Tells if multiple PIN verifications are allowed.
        /// </summary>
        [JsonProperty("allowMultiplePinVerifications")]
        public bool AllowMultiplePinVerifications { get; set; }

        /// <summary>
        /// Number of possible PIN attempts.
        /// </summary>
        [JsonProperty("pinAttempts")]
        public int PinAttempts { get; set; }

        /// <summary>
        /// PIN time to live. Should be in format of &#x60;{timeLength}{timeUnit}&#x60;. Here &#x60;timeLength&#x60; is an
        /// optional positive integer with a default value of 1 and &#x60;timeUnit&#x60; is one of: &#x60;ms&#x60;, &#x60;s
        /// &#x60;, &#x60;m&#x60;, &#x60;h&#x60; or &#x60;d&#x60; representing milliseconds, seconds, minutes, hours and days
        /// respectively. Must not be larger that one year, although much lower values are recommended.
        /// </summary>
        [JsonProperty("pinTimeToLive")]
        public string PinTimeToLive { get; set; }

        /// <summary>
        /// Overall number of requests in time interval for generating a PIN and sending an SMS using single application.
        /// Should be in format of &#x60;{attempts}/{timeLength}{timeUnit}&#x60;. Here &#x60;attempts&#x60; is a mandatory
        /// positive integer and &#x60;timeLength&#x60; is an optional positive integer with a default value of 1. &#x60;
        /// timeUnit&#x60; is one of: &#x60;ms&#x60;, &#x60;s&#x60;, &#x60;m&#x60;, &#x60;h&#x60; or &#x60;d&#x60; representing
        /// milliseconds, seconds, minutes, hours and days respectively. Time component must not be larger that one year,
        /// although much lower values are recommended.
        /// </summary>
        [JsonProperty("sendPinPerApplicationLimit")]
        public string SendPinPerApplicationLimit { get; set; }

        /// <summary>
        /// Number of requests in time interval for generating a PIN and sending an SMS to one phone number (MSISDN). Should be
        /// in format of &#x60;{attempts}/{timeLength}{timeUnit}&#x60;. Here &#x60;attempts&#x60; is a mandatory positive
        /// integer and &#x60;timeLength&#x60; is an optional positive integer with a default value of 1. &#x60;timeUnit&#x60;
        /// is one of: &#x60;ms&#x60;, &#x60;s&#x60;, &#x60;m&#x60;, &#x60;h&#x60; or &#x60;d&#x60; representing milliseconds,
        /// seconds, minutes, hours and days respectively. Time component must not be larger that one year, although much lower
        /// values are recommended.
        /// </summary>
        [JsonProperty("sendPinPerPhoneNumberLimit")]
        public string SendPinPerPhoneNumberLimit { get; set; }

        /// <summary>
        /// Number of PIN verification requests in time interval from one phone number (MSISDN). Should be in format of &#x60;
        /// {attempts}/{timeLength}{timeUnit}&#x60;. Here &#x60;attempts&#x60; is a mandatory positive integer and &#x60;
        /// timeLength&#x60; is an optional positive integer with a default value of 1. &#x60;timeUnit&#x60; is one of: &#x60;
        /// ms&#x60;, &#x60;s&#x60;, &#x60;m&#x60;, &#x60;h&#x60; or &#x60;d&#x60; representing milliseconds, seconds, minutes,
        /// hours and days respectively. Time component must not be larger that one day, although much lower values are
        /// recommended.
        /// </summary>
        [JsonProperty("verifyPinLimit")]
        public string VerifyPinLimit { get; set; }
    }
}
