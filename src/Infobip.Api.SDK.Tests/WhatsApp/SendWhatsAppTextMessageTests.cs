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
    public class SendWhatsAppTextMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendWhatsAppTextMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTextMessageSuccess.json";
            var apiClient =
                new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var request = GetRequest();

            var response = await apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppTextMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_FromInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.From)}");
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_ToInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.To)}");
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_MessageIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                new string('x', 51),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.MessageId)}");
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_CallbackDataInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);
            request.CallbackData = new string('x', 4001);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.CallbackData)}");
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_NotifyUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);
            request.NotifyUrl = new string('x', 2049);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.NotifyUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppTextMessage_Call_With_ContentInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppTextContent("");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppTextMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Content)}.{nameof(WhatsAppTextContent.Text)}");
        }

        private WhatsAppTextMessageRequest GetRequest()
        {
            var content = new WhatsAppTextContent("text");
            var request = new WhatsAppTextMessageRequest("447860099299", "447860099300",
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