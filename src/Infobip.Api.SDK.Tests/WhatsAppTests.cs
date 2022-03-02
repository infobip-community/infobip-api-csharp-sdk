using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class WhatsAppTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public WhatsAppTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsappTemplateMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsappTemplateMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppBulkMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppBulkMessageInfoResponse>(responsePayloadFileName);

            var messages = new List<WhatsAppFailoverMessage>
            {
                new(from: "447860099299", "447860099300", content: new WhatsAppTemplateContent("template",
                    new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string> { "placeholder" })), "en"))
            };
            var request = new WhatsAppBulkMessageRequest(messages, Guid.NewGuid().ToString());
            
            // Act
            var response = await apiClient.WhatsApp.SendWhatsappTemplateMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);

        }


        [Fact]
        public async Task SendWhatsAppTextMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTextMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppTextMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppDocumentMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppDocumentMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppDocumentContent("http://example.com/media");
            var request = new WhatsAppDocumentMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppDocumentMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppImageMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppImageMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppImageContent("http://example.com/media");
            var request = new WhatsAppImageMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppImageMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppAudioMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppAudioMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppAudioContent("http://example.com/media");
            var request = new WhatsAppAudioMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppAudioMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppVideoMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppVideoMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppVideoContent("http://example.com/media");
            var request = new WhatsAppVideoMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppVideoMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppStickerMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppStickerMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppStickerContent("http://example.com/media");
            var request = new WhatsAppStickerMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppStickerMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppLocationMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppLocationMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppLocationContent();
            var request = new WhatsAppLocationMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppLocationMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppContactMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppContactMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var nameContent = new WhatsAppNameContent(firstName: "First name", formattedName: "FirstName LastName");
            var contacts = new List<WhatsAppContactContent>
            {
                new WhatsAppContactContent(name: nameContent)
            };
            var content = new WhatsAppContactsContent(contacts);
            var request = new WhatsAppContactsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppContactMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveButtonsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var buttons = new List<WhatsAppInteractiveButtonContent>
            {
                new WhatsAppInteractiveButtonContent("REPLY")
            };
            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"), new WhatsAppInteractiveButtonsActionContent(buttons));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveListMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var buttons = new List<WhatsAppInteractiveListSectionContent>
            {
                new WhatsAppInteractiveListSectionContent("title", new List<WhatsAppInteractiveRowContent>())
            };
            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("text"), new WhatsAppInteractiveListActionContent("title", buttons));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveProductMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveProductMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var content = new WhatsAppInteractiveProductContent(
                new WhatsAppInteractiveProductActionContent("catalogId", "productRetailerId"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveFooterContent("text"));
            var request = new WhatsAppInteractiveProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveProductMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveMultiProductMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

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

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
