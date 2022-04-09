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
    public class SendWhatsAppTemplateMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendWhatsAppTemplateMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTemplateMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppBulkMessageInfoResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTemplateMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_MessagesInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var messages = new List<WhatsAppFailoverMessage>();
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_BulkIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages,
                new string('x', 101));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.BulkId)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_FromInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.From)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ToInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.To)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_MessageIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    new string('x', 51),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.MessageId)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_CallbackDataInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content,
                    new string('x', 4001))
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.CallbackData)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_NotifyUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content, 
                    notifyUrl:new string('x', 2049))
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.NotifyUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_SmsFailoverUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content,
                    smsFailover: new WhatsAppSmsFailover("", ""))
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.SmsFailover)}.{nameof(WhatsAppSmsFailover.From)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.SmsFailover)}.{nameof(WhatsAppSmsFailover.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>())),
                "");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}";
            errors.Should().Contain($"{messagesContentPath}.{nameof(WhatsAppTemplateContent.Language)}");
            errors.Should().Contain($"{messagesContentPath}.{nameof(WhatsAppTemplateContent.TemplateName)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataHeaderTextInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    new WhatsAppTemplateTextHeaderContent("")),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateTextHeaderContent.Placeholder)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataHeaderDocumentInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    new WhatsAppTemplateDocumentHeaderContent("", "")),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateDocumentHeaderContent.MediaUrl)}");
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateDocumentHeaderContent.Filename)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataHeaderImageInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    new WhatsAppTemplateImageHeaderContent("")),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateImageHeaderContent.MediaUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataHeaderVideoInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    new WhatsAppTemplateVideoHeaderContent("")),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateVideoHeaderContent.MediaUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataHeaderLocationInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    new WhatsAppTemplateLocationHeaderContent(100, 200)),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateLocationHeaderContent.Latitude)}");
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Header)}.{nameof(WhatsAppTemplateLocationHeaderContent.Longitude)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataButtonsQuickReplyInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    buttons: new List<WhatsAppTemplateButtonContent>()
                    {
                        new WhatsAppTemplateQuickReplyButtonContent("")
                    }),
                    "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Buttons)}.{nameof(WhatsAppTemplateQuickReplyButtonContent.Parameter)}");
        }

        [Fact]
        public async Task SendWhatsAppTemplateMessage_Call_With_ContentTemplateDataButtonsUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTemplateContent("template name",
                new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string>()),
                    buttons: new List<WhatsAppTemplateButtonContent>()
                    {
                        new WhatsAppTemplateUrlButtonContent("")
                    }),
                "en");
            var messages = new List<WhatsAppFailoverMessage>()
            {
                new WhatsAppFailoverMessage("447860099299", "447860099300",
                    Guid.NewGuid().ToString(),
                    content)
            };
            var request = new WhatsAppBulkMessageRequest(messages, "bulkId");

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTemplateMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesContentTemplateDataPath = $"{nameof(request.Messages)}.{nameof(WhatsAppFailoverMessage.Content)}.{nameof(WhatsAppTemplateContent.TemplateData)}";
            errors.Should().Contain($"{messagesContentTemplateDataPath}.{nameof(WhatsAppTemplateDataContent.Buttons)}.{nameof(WhatsAppTemplateUrlButtonContent.Parameter)}");
        }

        private WhatsAppBulkMessageRequest GetRequest()
        {
            var messages = new List<WhatsAppFailoverMessage>
            {
                new(@from: "447860099299", "447860099300", content: new WhatsAppTemplateContent("template",
                    new WhatsAppTemplateDataContent(new WhatsAppTemplateBodyContent(new List<string> { "placeholder" })), "en"))
            };
            var request = new WhatsAppBulkMessageRequest(messages, Guid.NewGuid().ToString());
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