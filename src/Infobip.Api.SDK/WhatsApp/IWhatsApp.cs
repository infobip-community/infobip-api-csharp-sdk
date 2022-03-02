using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Infobip.Api.SDK.WhatsApp.Models;

namespace Infobip.Api.SDK.WhatsApp
{
    public interface IWhatsApp
    {
        // Send WhatsApp Message
        Task<WhatsAppBulkMessageInfoResponse> SendWhatsAppTemplateMessage(WhatsAppBulkMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage(WhatsAppTextMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppDocumentMessage(WhatsAppDocumentMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppImageMessage(WhatsAppImageMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppAudioMessage(WhatsAppAudioMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppVideoMessage(WhatsAppVideoMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppStickerMessage(WhatsAppStickerMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppLocationMessage(WhatsAppLocationMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppContactMessage(WhatsAppContactsMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveButtonsMessage(WhatsAppInteractiveButtonsMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveListMessage(WhatsAppInteractiveListMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveProductMessage(WhatsAppInteractiveProductMessageRequest requestPayload, CancellationToken cancellationToken);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveMultiProductMessage(WhatsAppInteractiveMultiProductMessageRequest requestPayload, CancellationToken cancellationToken);


        // Receive WhatsApp Message

        Task<Stream> DownloadWhatsAppInboundMedia(string sender, string mediaId, CancellationToken cancellationToken);
        Task<string> GetWhatsAppMediaMetadata(string sender, string mediaId, CancellationToken cancellationToken);
        Task MarkWhatsAppMessageAsRead(string sender, string messageId, CancellationToken cancellationToken);


        // Manage WhatsApp
        /// <summary>
        /// Get WhatsApp Templates
        /// </summary>
        /// <remarks>
        /// Get all the templates and their statuses for a given sender.
        /// </remarks>
        /// <param name="sender">Registered WhatsApp sender number. Must be in international format.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. See <seealso cref="CancellationToken"/></param>
        Task<WhatsAppTemplateManagementTemplatesResponse> GetWhatsAppTemplates(string sender, CancellationToken cancellationToken);

        /// <summary>
        /// Create WhatsApp Template
        /// </summary>
        /// <remarks>
        /// Create WhatsApp template. Created template will be submitted for WhatsApp&#39;s review and approval. Once approved, template can be sent to end-users. Refer to [template guidelines](https://www.infobip.com/docs/whatsapp/message-types#guidelines-amp-best-practices) for additional info.
        /// </remarks>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. See <seealso cref="CancellationToken"/></param>
        Task<WhatsAppTemplateManagementTemplateResponse> CreateWhatsAppTemplate(string sender, WhatsAppTemplateManagementTemplateRequest requestPayload, CancellationToken cancellationToken);

        /// <summary>
        /// Delete media
        /// </summary>
        /// <remarks>
        /// Delete WhatsApp media. May be outbound or inbound media.
        /// </remarks>
        /// <param name="sender">Registered WhatsApp sender number. Must be in international format.</param>
        /// <param name="requestPayload"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. See <seealso cref="CancellationToken"/></param>
        Task<string> DeleteWhatsAppMedia(string sender, DeleteWhatsAppMediaRequest requestPayload, CancellationToken cancellationToken);

        
    }
}