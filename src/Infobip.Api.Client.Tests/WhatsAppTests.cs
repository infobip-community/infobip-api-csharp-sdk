using System;
using System.Collections.Generic;
using FluentAssertions;
using Infobip.Api.Client.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.Client.Tests
{
    public class WhatsAppTests : IClassFixture<MockedRestClientFixture>
    {
        private readonly MockedRestClientFixture _fixture;

        public WhatsAppTests(MockedRestClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void SendWhatsappTemplateMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsappTemplateMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppBulkMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppBulkMessageInfoResponse>(responsePayloadFileName);

            var messages = new List<WhatsAppFailoverMessage>
            {
                new(from: "447860099299", "447860099300", content: new WhatsAppTemplateContent("template",
                    new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string> { "placeholder" })), "en"))
            };
            var request = new WhatsAppBulkMessageRequest(messages, Guid.NewGuid().ToString());

            var response = apiClient.WhatsApp.SendWhatsappTemplateMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);

        }


        [Fact]
        public void SendWhatsAppTextMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTextMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppTextMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppDocumentMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppDocumentMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppDocumentContent("http://example.com/media");
            var request = new WhatsAppDocumentMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppDocumentMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppImageMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppImageMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppImageContent("http://example.com/media");
            var request = new WhatsAppImageMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppImageMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppAudioMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppAudioMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppAudioContent("http://example.com/media");
            var request = new WhatsAppAudioMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppAudioMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppVideoMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppVideoMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppVideoContent("http://example.com/media");
            var request = new WhatsAppVideoMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppVideoMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppStickerMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppStickerMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppStickerContent("http://example.com/media");
            var request = new WhatsAppStickerMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppStickerMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppLocationMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppLocationMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppLocationContent();
            var request = new WhatsAppLocationMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppLocationMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppContactMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppContactMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var nameContent = new WhatsAppNameContent(firstName: "First name", formattedName: "FirstName LastName");
            var contacts = new List<WhatsAppContactContent>
            {
                new WhatsAppContactContent(name: nameContent)
            };
            var content = new WhatsAppContactsContent(contacts);
            var request = new WhatsAppContactsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppContactMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppInteractiveButtonsMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveButtonsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var buttons = new List<WhatsAppInteractiveButtonContent>
            {
                new WhatsAppInteractiveButtonContent("REPLY")
            };
            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"), new WhatsAppInteractiveButtonsActionContent(buttons));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppInteractiveListMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveListMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var buttons = new List<WhatsAppInteractiveListSectionContent>
            {
                new WhatsAppInteractiveListSectionContent("title", new List<WhatsAppInteractiveRowContent>())
            };
            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("text"), new WhatsAppInteractiveListActionContent("title", buttons));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppInteractiveProductMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveProductMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppInteractiveProductContent(
                new WhatsAppInteractiveProductActionContent("catalogId", "productRetailerId"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveFooterContent("text"));
            var request = new WhatsAppInteractiveProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppInteractiveProductMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void SendWhatsAppInteractiveMultiProductMessage_Call_ExpectsSuccess()
        {
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveMultiProductMessageSuccess.json";
            var apiClient = new InfobipApiClient(_fixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _fixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppInteractiveMultiProductContent(
                new WhatsAppInteractiveMultiProductHeaderContent("TEXT"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>(
                        new List<WhatsAppInteractiveMultiProductSectionContent>()
                        {
                            new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>() {"productRetailerId"})
                        }))
                );
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request).Result;

            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
