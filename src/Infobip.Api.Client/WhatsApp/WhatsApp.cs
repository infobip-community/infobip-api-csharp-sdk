using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Infobip.Api.Client.WhatsApp.Models;
using RestSharp;

namespace Infobip.Api.Client.WhatsApp
{
    internal class WhatsApp : IWhatsApp
    {
        private readonly IRestClient _client;

        public WhatsApp(IRestClient client)
        {
            _client = client;
        }

        // Send WhatsApp Message
        public async Task<WhatsAppBulkMessageInfoResponse> SendWhatsappTemplateMessage(WhatsAppBulkMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/template", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppBulkMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage(WhatsAppTextMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/text", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppDocumentMessage(WhatsAppDocumentMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/document", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppImageMessage(WhatsAppImageMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/image", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppAudioMessage(WhatsAppAudioMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/audio", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppVideoMessage(WhatsAppVideoMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/video", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppStickerMessage(WhatsAppStickerMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/sticker", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppLocationMessage(WhatsAppLocationMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/location", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppContactMessage(WhatsAppContactsMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/contact", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveButtonsMessage(WhatsAppInteractiveButtonsMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/interactive/buttons", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveListMessage(WhatsAppInteractiveListMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/interactive/list", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveProductMessage(WhatsAppInteractiveProductMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/interactive/product", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppInteractiveMultiProductMessage(WhatsAppInteractiveMultiProductMessageRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/message/interactive/multi-product", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppSingleMessageInfoResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }


        // Receive WhatsApp Message
        public async Task<Stream> DownloadWhatsAppInboundMedia(string sender, string mediaId)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/media/{mediaId}", Method.GET);
            request.AddOrUpdateParameter("sender", sender);
            request.AddOrUpdateParameter("mediaId", mediaId);

            var result = await _client.ExecuteAsync<Stream>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<string> GetWhatsAppMediaMetadata(string sender, string mediaId)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/media/{mediaId}", Method.HEAD);
            request.AddOrUpdateParameter("sender", sender);
            request.AddOrUpdateParameter("mediaId", mediaId);

            var result = await _client.ExecuteAsync<string>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Content;
        }

        public async Task MarkWhatsAppMessageAsRead(string sender, string messageId)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/message/{messageId}/read", Method.POST);
            request.AddOrUpdateParameter("sender", sender);
            request.AddOrUpdateParameter("messageId", messageId);

            var result = await _client.ExecuteAsync<string>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }
        }

        // Manage WhatsApp
        public async Task<WhatsAppTemplateManagementTemplatesResponse> GetWhatsappTemplates(string sender)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/templates", Method.GET);
            request.AddOrUpdateParameter("sender", sender);

            var result = await _client.ExecuteAsync<WhatsAppTemplateManagementTemplatesResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<WhatsAppTemplateManagementTemplateResponse> CreateWhatsAppTemplate(string sender, WhatsAppTemplateManagementTemplateRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/templates", Method.POST);
            request.AddOrUpdateParameter("sender", sender);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<WhatsAppTemplateManagementTemplateResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<string> DeleteWhatsAppMedia(string sender, DeleteWhatsAppMediaRequest requestPayload)
        {
            var request = new RestRequest("whatsapp/1/senders/{sender}/media", Method.DELETE);
            request.AddOrUpdateParameter("sender", sender);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<string>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }
    }
}