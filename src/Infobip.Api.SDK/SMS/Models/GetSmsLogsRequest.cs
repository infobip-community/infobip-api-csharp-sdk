using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Infobip.Api.SDK.SMS.Models
{
    /// <summary>
    /// GetSmsLogsRequest
    /// </summary>
    public class GetSmsLogsRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsLogsRequest" /> class.
        /// </summary>
        [JsonConstructor]
        protected GetSmsLogsRequest()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSmsLogsRequest" /> class.
        /// </summary>
        /// <param name="from">The sender ID which can be alphanumeric or numeric.</param>
        /// <param name="to">Message destination address.</param>
        /// <param name="bulkId">Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.</param>
        /// <param name="messageId">Unique message ID for which a log is requested.</param>
        /// <param name="generalStatus">Sent message status. Possible values: ACCEPTED, PENDING, UNDELIVERABLE, DELIVERED, REJECTED, EXPIRED.</param>
        /// <param name="sentSince">The logs will only include messages sent after this date. Use it together with sentUntil to return a time range or if you want to fetch more than 1000 logs allowed per call. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        /// <param name="sentUntil">The logs will only include messages sent before this date. Use it together with sentBefore to return a time range or if you want to fetch more than 1000 logs allowed per call. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.</param>
        /// <param name="limit">Maximum number of messages to include in logs. If not set, the latest 50 records are returned. Maximum limit value is 1000 and you can only access logs for the last 48h. If you want to fetch more than 1000 logs allowed per call, use sentBefore and sentUntil to retrieve them in pages.</param>
        /// <param name="mcc">Mobile Country Code.</param>
        /// <param name="mnc">Mobile Network Code.</param>
        public GetSmsLogsRequest(string from = default, string to = default,
            string bulkId = default, string messageId = default, string generalStatus = default, 
            DateTimeOffset? sentSince = default, DateTimeOffset? sentUntil = default, 
            int? limit = default, string mcc = default, string mnc = default)
        {
            From = from;
            To = to;
            BulkId = bulkId;
            MessageId = messageId;
            GeneralStatus = generalStatus;
            SentSince = sentSince;
            SentUntil = sentUntil;
            Limit = limit;
            Mcc = mcc;
            Mnc = mnc;
        }

        /// <summary>
        /// The sender ID which can be alphanumeric or numeric.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Message destination address.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API request.
        /// </summary>
        public string BulkId { get; set; }

        /// <summary>
        /// Unique message ID for which a log is requested.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Sent message status. Possible values: ACCEPTED, PENDING, UNDELIVERABLE, DELIVERED, REJECTED, EXPIRED.
        /// </summary>
        public string GeneralStatus { get; set; }

        /// <summary>
        /// The logs will only include messages sent after this date. Use it together with sentUntil to return a time range or if you want to fetch more than 1000 logs allowed per call. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        public DateTimeOffset? SentSince { get; set; }

        /// <summary>
        /// The logs will only include messages sent before this date. Use it together with sentBefore to return a time range or if you want to fetch more than 1000 logs allowed per call. Has the following format: yyyy-MM-dd'T'HH:mm:ss.SSSZ.
        /// </summary>
        public DateTimeOffset? SentUntil { get; set; }

        /// <summary>
        /// Maximum number of messages to include in logs. If not set, the latest 50 records are returned. Maximum limit value is 1000 and you can only access logs for the last 48h. If you want to fetch more than 1000 logs allowed per call, use sentBefore and sentUntil to retrieve them in pages.
        /// </summary>
        [Range(0, 1000)]
        public int? Limit { get; set; }

        /// <summary>
        /// Mobile Country Code.
        /// </summary>
        public string Mcc { get; set; }

        /// <summary>
        /// Mobile Network Code.
        /// </summary>
        public string Mnc { get; set; }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // GeneralStatus (string) pattern
            var regex = new Regex(@"^(ACCEPTED|PENDING|UNDELIVERABLE|DELIVERED|REJECTED|EXPIRED)$", RegexOptions.CultureInvariant);
            if (!string.IsNullOrEmpty(GeneralStatus) && false == regex.Match(GeneralStatus).Success)
            {
                yield return new ValidationResult(
                    $"Invalid value for GeneralStatus, must match a pattern of {regex}", new[] { nameof(GeneralStatus) });
            }
        }
    }
}
