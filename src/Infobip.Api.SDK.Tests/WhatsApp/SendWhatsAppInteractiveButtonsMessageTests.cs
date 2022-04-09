using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.WhatsApp.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.WhatsApp
{
    public class SendWhatsAppInteractiveButtonsMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendWhatsAppInteractiveButtonsMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveButtonsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var request = GetRequest();

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveButtonsMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_FromInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.From)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ToInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.To)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_MessageIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                new string('x', 51),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.MessageId)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_CallbackDataInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                new string('x', 4001));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.CallbackData)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_NotifyUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                notifyUrl: new string('x', 2049));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.NotifyUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(WhatsAppFailoverMessage.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveButtonsContent.Action)}.{nameof(WhatsAppInteractiveButtonsActionContent.Buttons)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentBodyInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(WhatsAppFailoverMessage.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveButtonsContent.Body)}.{nameof(WhatsAppInteractiveBodyContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentActionButtonsInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(WhatsAppFailoverMessage.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveButtonsContent.Action)}.{nameof(WhatsAppInteractiveButtonsActionContent.Buttons)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentActionButtonsReplyButtonInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("", "")
                }));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentActionButtonsPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Action)}.{nameof(WhatsAppInteractiveButtonsActionContent.Buttons)}";
            errors.Should().Contain($"{contentActionButtonsPath}.{nameof(WhatsAppInteractiveReplyButtonContent.Title)}");
            errors.Should().Contain($"{contentActionButtonsPath}.{nameof(WhatsAppInteractiveReplyButtonContent.Id)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentHeaderTextInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("id", "title")

                }),
                new WhatsAppInteractiveButtonsTextHeaderContent(""));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveButtonsTextHeaderContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentHeaderVideoInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("id", "title")

                }),
                new WhatsAppInteractiveButtonsVideoHeaderContent(""));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveButtonsVideoHeaderContent.MediaUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentHeaderImageInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("id", "title")

                }),
                new WhatsAppInteractiveButtonsImageHeaderContent(""));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveButtonsImageHeaderContent.MediaUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentHeaderDocumentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("id", "title")

                }),
                new WhatsAppInteractiveButtonsDocumentHeaderContent("", new string('x', 241)));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveButtonsDocumentHeaderContent.MediaUrl)}");
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveButtonsDocumentHeaderContent.Filename)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveButtonsMessage_Call_With_ContentFooterInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveButtonsActionContent(new List<WhatsAppInteractiveButtonContent>()
                {
                    new WhatsAppInteractiveReplyButtonContent("id", "title")

                }),
                new WhatsAppInteractiveButtonsTextHeaderContent("text"),
                new WhatsAppInteractiveFooterContent(new string('x', 61)));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveButtonsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentFooterPath = $"{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppInteractiveButtonsContent.Footer)}";
            errors.Should().Contain($"{contentFooterPath}.{nameof(WhatsAppInteractiveFooterContent.Text)}");
        }
        
        private WhatsAppInteractiveButtonsMessageRequest GetRequest()
        {
            var buttons = new List<WhatsAppInteractiveButtonContent>
            {
                new(WhatsAppInteractiveButtonContent.InteractiveButtonEnum.Reply)
            };
            var content = new WhatsAppInteractiveButtonsContent(new WhatsAppInteractiveBodyContent("text"), new WhatsAppInteractiveButtonsActionContent(buttons));
            var request = new WhatsAppInteractiveButtonsMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);
            return request;
        }

        private static HttpResponseMessage GetResponseMessage()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}