using System.IO;
using System.Threading.Tasks;
using Infobip.Api.Client.WhatsApp.Models;

namespace Infobip.Api.Client.WhatsApp
{
    public interface IWhatsApp
    {
        // Send WhatsApp Message
        Task<WhatsAppBulkMessageInfoResponse> SendWhatsappTemplateMessage(WhatsAppBulkMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage(WhatsAppTextMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppDocumentMessage(WhatsAppDocumentMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppImageMessage(WhatsAppImageMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppAudioMessage(WhatsAppAudioMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppVideoMessage(WhatsAppVideoMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppStickerMessage(WhatsAppStickerMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppLocationMessage(WhatsAppLocationMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppContactMessage(WhatsAppContactsMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveButtonsMessage(WhatsAppInteractiveButtonsMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveListMessage(WhatsAppInteractiveListMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveProductMessage(WhatsAppInteractiveProductMessageRequest requestPayload);
        Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveMultiProductMessage(WhatsAppInteractiveMultiProductMessageRequest requestPayload);


        // Receive WhatsApp Message
        Task<Stream> DownloadWhatsAppInboundMedia(string sender, string mediaId);
        Task<string> GetWhatsAppMediaMetadata(string sender, string mediaId);
        Task MarkWhatsAppMessageAsRead(string sender, string messageId);


        // Manage WhatsApp
        /// <summary>
        /// Get WhatsApp Templates
        /// </summary>
        /// <remarks>
        /// Get all the templates and their statuses for a given sender.
        /// </remarks>
        /// <param name="sender">Registered WhatsApp sender number. Must be in international format.</param>
        Task<WhatsAppTemplateManagementTemplatesResponse> GetWhatsappTemplates(string sender);

        /// <summary>
        /// Create WhatsApp Template
        /// </summary>
        /// <remarks>
        /// Create WhatsApp template. Created template will be submitted for WhatsApp&#39;s review and approval. Once approved, template can be sent to end-users. Refer to [template guidelines](https://www.infobip.com/docs/whatsapp/message-types#guidelines-amp-best-practices) for additional info.
        /// </remarks>
        Task<WhatsAppTemplateManagementTemplateResponse> CreateWhatsAppTemplate(string sender, WhatsAppTemplateManagementTemplateRequest requestPayload);

        /// <summary>
        /// Delete media
        /// </summary>
        /// <remarks>
        /// Delete WhatsApp media. May be outbound or inbound media.
        /// </remarks>
        /// <param name="sender">Registered WhatsApp sender number. Must be in international format.</param>
        /// <param name="requestPayload"></param>
        Task<string> DeleteWhatsAppMedia(string sender, DeleteWhatsAppMediaRequest requestPayload);

        
    }
}