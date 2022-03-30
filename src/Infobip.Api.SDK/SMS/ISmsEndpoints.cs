using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.SMS.Models;

namespace Infobip.Api.SDK.SMS
{
    /// <summary>
    /// Represents a collection of functions to interact with the SMS API endpoints.
    /// </summary>
    public interface ISmsEndpoints
    {
        // Send SMS
        /// <summary>
        /// Send SMS message.
        /// 99% of all use cases can be achieved by using this API method. Everything from sending a simple single message to a single destination, up to batch sending of personalized messages to the thousands of recipients with a single API request. Language, transliteration, scheduling and every advanced feature you can think of is supported.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="SendSmsMessageResponse"/>.</returns>
        Task<SendSmsMessageResponse> SendSmsMessage(SendSmsMessageRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SMS message over query parameters.
        /// All message parameters of the message can be defined in the query string. Use this method only if [Send SMS message](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) is not an option for your use case!
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="SendSmsMessageResponse"/>.</returns>
        Task<SendSmsMessageResponse> SendSmsMessageOverQueryParameters(SendSmsMessageOverQueryParametersRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send binary SMS message.
        /// Send single or multiple binary messages to one or more destination address.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="SendSmsMessageResponse"/>.</returns>
        Task<SendSmsMessageResponse> SendBinarySmsMessage(SendSmsBinaryMessageRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Preview SMS message.
        /// Avoid unpleasant surprises and check how different message configurations will affect your message text, number of characters and message parts.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="PreviewSmsMessageResponse"/>.</returns>
        Task<PreviewSmsMessageResponse> PreviewSmsMessage(PreviewSmsMessageRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get outbound SMS message delivery reports.
        /// If you are for any reason unable to receive real-time delivery reports on your endpoint, you can use this API method to learn if and when the message has been delivered to the recipient. Each request will return a batch of delivery reports - only once. The following API request will return only new reports that arrived since the last API request in the last 48 hours.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetSmsDeliveryReportResponse"/>.</returns>
        Task<GetSmsDeliveryReportResponse> GetOutboundSmsMessageDeliveryReports(GetSmsDeliveryReportRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get outbound SMS message logs.
        /// Use this method for displaying logs for example in the user interface. Available are the logs for the last 48 hours and you can only retrieve maximum of 1000 logs per call. See [message delivery reports](https://www.infobip.com/docs/api#channels/sms/get-outbound-sms-message-delivery-reports) if your use case is to verify message delivery.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases.](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetSmsLogsResponse"/>.</returns>
        Task<GetSmsLogsResponse> GetOutboundSmsMessageLogs(GetSmsLogsRequest requestPayload, CancellationToken cancellationToken = default);

        // Receive SMS
        /// <summary>
        /// Get inbound SMS messages
        /// If for some reason you are unable to receive incoming SMS to the endpoint of your choice in real time, you can use this API call to fetch messages. Each request will return a batch of received messages - only once. The API request will only return new messages that arrived since the last API request.
        /// </summary>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="GetInboundSmsMessagesResponse"/>.</returns>
        Task<GetInboundSmsMessagesResponse> GetInboundSmsMessages(GetInboundSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default);

        // Scheduled SMS
        /// <summary>
        /// Get scheduled SMS messages
        /// See the status and the scheduled time of your SMS messages.
        /// </summary>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="ScheduledSmsMessagesResponse"/>.</returns>
        Task<ScheduledSmsMessagesResponse> GetScheduledSmsMessages(GetScheduledSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reschedule SMS messages
        /// Change the date and time for sending scheduled messages.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="ScheduledSmsMessagesResponse"/>.</returns>
        Task<ScheduledSmsMessagesResponse> RescheduleSmsMessages(RescheduleSmsMessagesRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get scheduled SMS messages status
        /// See the status of scheduled messages.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="ScheduledSmsMessagesStatusResponse"/>.</returns>
        Task<ScheduledSmsMessagesStatusResponse> GetScheduledSmsMessagesStatus(GetScheduledSmsMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update scheduled SMS messages status
        /// Change status or completely cancel sending of scheduled messages.
        /// </summary>
        /// <remarks>
        /// [Learn more about SMS channel and use cases](https://www.infobip.com/docs/sms)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="ScheduledSmsMessagesStatusResponse"/>.</returns>
        Task<ScheduledSmsMessagesStatusResponse> UpdateScheduledSmsMessagesStatus(UpdateScheduledSmsMessagesStatusRequest requestPayload, CancellationToken cancellationToken = default);

        // 2FA Over SMS And Voice (Tfa - Two-Factor Authentication)
        /// <summary>
        /// Get 2FA applications
        /// An application is a container for 2FA message templates. Use this method to list your applications.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of List&lt;<see cref="TfaApplicationResponse"/>&gt;.</returns>
        Task<List<TfaApplicationResponse>> GetTfaApplications(CancellationToken cancellationToken = default);

        /// <summary>
        /// Create 2FA application
        /// Create and configure a new 2FA application.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaApplicationResponse"/>.</returns>
        Task<TfaApplicationResponse> CreateTfaApplication(TfaApplicationRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get 2FA application
        /// Get a single 2FA application to see its configuration details.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which configuration view was requested.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaApplicationResponse"/>.</returns>
        Task<TfaApplicationResponse> GetTfaApplication(string appId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update 2FA application
        /// Change configuration options for your existing 2FA application.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which configuration view was requested.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaApplicationResponse"/>.</returns>
        Task<TfaApplicationResponse> UpdateTfaApplication(string appId, TfaApplicationRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get 2FA message templates
        /// List all message templates in a 2FA application.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which requested message was created.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of List&lt;<see cref="TfaMessageTemplateResponse"/>&gt;.</returns>
        Task<List<TfaMessageTemplateResponse>> GetTfaMessageTemplates(string appId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create 2FA message template
        /// Once you have your 2FA application, create one or more message templates where your PIN will be dynamically included when you send the PIN message.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which requested message was created.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaMessageTemplateResponse"/>.</returns>
        Task<TfaMessageTemplateResponse> CreateTfaMessageTemplate(string appId, TfaMessageTemplateRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get 2FA message template
        /// Get a single 2FA message template from an application to see its configuration details.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which requested message was created.</param>
        /// <param name="msgId">Requested message ID.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaMessageTemplateResponse"/>.</returns>
        Task<TfaMessageTemplateResponse> GetTfaMessageTemplate(string appId, string msgId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update 2FA message template
        /// Change configuration options for your existing 2FA application message template.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of application for which requested message was created.</param>
        /// <param name="msgId">Requested message ID.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaMessageTemplateResponse"/>.</returns>
        Task<TfaMessageTemplateResponse> UpdateTfaMessageTemplate(string appId, string msgId, TfaMessageTemplateRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send 2FA PIN code over SMS
        /// Send a PIN code over SMS using a previously created [message template](https://www.infobip.com/docs/api#channels/sms/create-2fa-message-template).
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaPinCodeResponse"/>.</returns>
        Task<TfaPinCodeResponse> SendTfaPinCodeOverSms(SendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Resend 2FA PIN code over SMS
        /// If needed, you can resend the same (previously sent) PIN code over SMS.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="pinId">ID of the pin code that has to be verified.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaPinCodeResponse"/>.</returns>
        Task<TfaPinCodeResponse> ResendTfaPinCodeOverSms(string pinId, ResendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Send 2FA PIN code over Voice
        /// Send a PIN code over Voice using previously created [message template](https://www.infobip.com/docs/api#channels/sms/create-2fa-message-template).
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaPinCodeResponse"/>.</returns>
        Task<TfaPinCodeResponse> SendTfaPinCodeOverVoice(SendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Resend 2FA PIN code over Voice
        /// If needed, you can resend the same (previously sent) PIN code over Voice.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="pinId">ID of the pin code that has to be verified.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaPinCodeResponse"/>.</returns>
        Task<TfaPinCodeResponse> ResendTfaPinCodeOverVoice(string pinId, ResendTfaPinCodeRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verify phone number
        /// Verify a phone number to confirm successful 2FA authentication.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="pinId">ID of the pin code that has to be verified.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="VerifyPhoneNumberResponse"/>.</returns>
        Task<VerifyPhoneNumberResponse> VerifyPhoneNumber(string pinId, VerifyPhoneNumberRequest requestPayload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get 2FA verification status
        /// Check if a phone number is already verified for a specific 2FA application.
        /// </summary>
        /// <remarks>
        /// [Read me first: Introduction and use cases](https://www.infobip.com/docs/use-cases/two-factor-authentication-over-api)
        /// </remarks>
        /// <param name="appId">ID of 2-FA application for which phone number verification status is requested.</param>
        /// <param name="requestPayload">Request payload</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.See <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="TfaVerificationStatusResponse"/>.</returns>
        Task<TfaVerificationStatusResponse> GetTfaVerificationStatus(string appId, TfaVerificationStatusRequest requestPayload, CancellationToken cancellationToken = default);
    }
}
