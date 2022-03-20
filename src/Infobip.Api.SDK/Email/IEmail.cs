using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.Email.Models;

namespace Infobip.Api.SDK.Email
{
    /// <summary>
    /// Represents a collection of functions to interact with the Email API endpoints.
    /// </summary>
    public interface IEmail
    {
        // Send Email
        /// <summary>
        /// Email delivery reports.
        /// </summary>
        /// <remarks>
        /// Get one-time delivery reports for all sent emails.
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetEmailDeliveryReportsResponse"/>.</returns>
        Task<GetEmailDeliveryReportsResponse> GetEmailDeliveryReports(GetEmailDeliveryReportsRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get email logs
        /// </summary>
        /// <remarks>
        /// This method allows you to get email logs of sent Email messagesId for request. Email logs are available for the last 48 hours!
        /// [Learn more about Email channel and use cases.](https://www.infobip.com/docs/email)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetEmailLogsResponse"/>.</returns>
        Task<GetEmailLogsResponse> GetEmailLogs(GetEmailLogsRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send fully featured email
        /// </summary>
        /// <remarks>
        /// Send an email or multiple emails to a recipient or multiple recipients with CC/BCC enabled.
        /// [Learn more about Email channel and use cases.](https://www.infobip.com/docs/email)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>A <see cref="Task"/> of <see cref="SendFullyFeaturedEmailResponse"/>.</returns>
        Task<SendFullyFeaturedEmailResponse> SendFullyFeaturedEmail(SendFullyFeaturedEmailRequest requestPayload, CancellationToken cancellationToken = default);

        // Scheduled Email
        /// <summary>
        /// Get sent email bulks.
        /// </summary>
        /// <remarks>
        /// See the scheduled time of your Email messages.
        /// </remarks>
        /// <param name="bulkId">Bulk ID.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetSentEmailBulksResponse"/>.</returns>
        Task<GetSentEmailBulksResponse> GetSentEmailBulks(string bulkId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reschedule Email messages.
        /// </summary>
        /// <remarks>
        /// Change the date and time for sending scheduled messages.
        /// </remarks>
        /// <param name="bulkId">Bulk ID.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetSentEmailBulksResponse"/>.</returns>
        Task<RescheduleEmailMessagesResponse> RescheduleEmailMessages(string bulkId, RescheduleEmailMessagesRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get sent email bulks status
        /// </summary>
        /// <remarks>
        /// See the status of scheduled email messages.
        /// </remarks>
        /// <param name="bulkId">Bulk ID.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetSentEmailBulksStatusResponse"/>.</returns>
        Task<GetSentEmailBulksStatusResponse> GetSentEmailBulksStatus(string bulkId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update scheduled Email messages status
        /// </summary>
        /// <remarks>
        /// Change status or completely cancel sending of scheduled messages.
        /// </remarks>
        /// <param name="bulkId">Bulk ID.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="UpdateScheduledEmailMessagesStatusResponse"/>.</returns>
        Task<UpdateScheduledEmailMessagesStatusResponse> UpdateScheduledEmailMessagesStatus(string bulkId, UpdateScheduledEmailMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default);

        // Email Validation
        /// <summary>
        /// Validate Email Addresses
        /// </summary>
        /// <remarks>
        /// Run validation to identify poor quality emails to clean up your recipient list.
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="ValidateEmailAddressesResponse"/>.</returns>
        Task<ValidateEmailAddressesResponse> ValidateEmailAddresses(ValidateEmailAddressesRequest requestPayload, CancellationToken cancellationToken = default);
    }
}