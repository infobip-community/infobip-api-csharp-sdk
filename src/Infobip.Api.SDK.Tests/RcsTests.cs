using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.RCS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests
{
    public class RcsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public RcsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendRcsMessage_TextContent_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeTextContent("Text");
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            var response = await apiClient.Rcs.SendRcsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendRcsMessage_TextContentInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var content = new MessageTypeTextContent("");
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendRcsMessage_FileContent_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeFileContent(new MessageResource("url"), new MessageResource("url"));
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            var response = await apiClient.Rcs.SendRcsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendRcsMessage_CardContent_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal, MessageTypeCardContentAlignmentEnum.Left, new CardContent("Title", "Description"));
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            var response = await apiClient.Rcs.SendRcsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendRcsMessage_CarouselContent_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var contents = new List<CardContent>();
            var content = new MessageTypeCarouselContent(MessageTypeCarouselContentCardWidthEnum.Small, contents);
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            var response = await apiClient.Rcs.SendRcsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendBulkRcsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeContent(MessageTypeContentTypeEnum.Text);
            var messages = new List<SendRcsMessageRequest>
            {
                new("447860099299", "447860099300", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            var response = await apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        // Throws InfobipBadRequestException
        [Fact]
        public async Task SendRcsMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var content = new MessageTypeTextContent("Text");
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var content = new MessageTypeContent(MessageTypeContentTypeEnum.Text);
            var messages = new List<SendRcsMessageRequest>
            {
                new("447860099299", "447860099300", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }
    }
}
