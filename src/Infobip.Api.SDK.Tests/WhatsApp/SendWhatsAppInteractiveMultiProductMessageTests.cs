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
    public class SendWhatsAppInteractiveMultiProductMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendWhatsAppInteractiveMultiProductMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveMultiProductMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var request = GetRequest();

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveMultiProductMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_FromInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId", 
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.From)}");
        }
        
        [Fact]
        public async Task  SendWhatsAppInteractiveMultiProductMessage_Call_With_ToInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.To)}");
        }

        [Fact]
        public async Task  SendWhatsAppInteractiveMultiProductMessage_Call_With_MessageIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                new string('x', 51),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.MessageId)}");
        }
        
        [Fact]
        public async Task  SendWhatsAppInteractiveMultiProductMessage_Call_With_CallbackDataInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                new string('x', 4001));

            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.CallbackData)}");
        }
        
        [Fact]
        public async Task  SendWhatsAppInteractiveMultiProductMessage_Call_With_NotifyUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                notifyUrl: new string('x', 2049));

            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.NotifyUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_ContentHeaderTextInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent(""),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveMultiProductContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveMultiProductTextHeaderContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_ContentBodyTextInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveMultiProductContent.Body)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveBodyContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_ContentActionInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveMultiProductContent.Action)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveMultiProductActionContent.CatalogId)}");
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveMultiProductActionContent.Sections)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_ContentActionSectionInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent(new string('x', 25), new List<string>())
                    }));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderActionSectionsPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveMultiProductContent.Action)}.{nameof(WhatsAppInteractiveMultiProductActionContent.Sections)}";
            errors.Should().Contain($"{contentHeaderActionSectionsPath}.{nameof(WhatsAppInteractiveMultiProductSectionContent.Title)}");
            errors.Should().Contain($"{contentHeaderActionSectionsPath}.{nameof(WhatsAppInteractiveMultiProductSectionContent.ProductRetailerIds)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveMultiProductMessage_Call_With_ContentFooterTextInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveMultiProductContent(new WhatsAppInteractiveMultiProductTextHeaderContent("text"),
                new WhatsAppInteractiveBodyContent("text"),
                new WhatsAppInteractiveMultiProductActionContent("catalogId",
                    new List<WhatsAppInteractiveMultiProductSectionContent>()
                    {
                        new WhatsAppInteractiveMultiProductSectionContent("title", new List<string>())
                    }),
                new WhatsAppInteractiveFooterContent(""));
            var request = new WhatsAppInteractiveMultiProductMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp. SendWhatsAppInteractiveMultiProductMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveMultiProductContent.Footer)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveFooterContent.Text)}");
        }
        
        private WhatsAppInteractiveMultiProductMessageRequest GetRequest()
        {
            var content = new WhatsAppInteractiveMultiProductContent(
                new WhatsAppInteractiveMultiProductHeaderContent(WhatsAppInteractiveMultiProductHeaderContent.MultiProductHeaderContentEnum.Text),
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
