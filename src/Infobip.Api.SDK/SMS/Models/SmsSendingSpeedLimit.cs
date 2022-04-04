using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// Limits the send speed when sending messages in bulk to deliver messages over a longer period of time. You may wish to use this to allow your systems or agents to handle large amounts of incoming traffic, e.g., if you are expecting recipients to follow through with a call-to-action option from a message you sent. Not setting a send speed limit can overwhelm your resources with incoming traffic.
    /// </summary>
    public class SmsSendingSpeedLimit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsSendingSpeedLimit" /> class.
        /// </summary>
        [JsonConstructor]
        protected SmsSendingSpeedLimit() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsSendingSpeedLimit" /> class.
        /// </summary>
        /// <param name="amount">The number of messages to be sent per timeUnit. By default, the system sends messages as fast as the infrastructure allows. Use this parameter to adapt sending capacity to your needs. The system is only able to work against its maximum capacity for ambitious message batches.</param>
        /// <param name="timeUnit">The time unit to define when setting a messaging speed limit. Defaults to MINUTE.</param>
        public SmsSendingSpeedLimit(int amount = default, SmsSpeedLimitTimeUnit timeUnit = default)
        {
            Amount = amount;
            TimeUnit = timeUnit;
        }

        /// <summary>
        /// The time unit to define when setting a messaging speed limit. Defaults to MINUTE.
        /// </summary>
        [JsonProperty("timeUnit")]
        [Required]
        public SmsSpeedLimitTimeUnit? TimeUnit { get; set; }

        /// <summary>
        /// The number of messages to be sent per timeUnit. By default, the system sends messages as fast as the infrastructure allows. Use this parameter to adapt sending capacity to your needs. The system is only able to work against its maximum capacity for ambitious message batches.
        /// </summary>
        [JsonProperty("amount")]
        [Required]
        public int Amount { get; set; }
    }
}