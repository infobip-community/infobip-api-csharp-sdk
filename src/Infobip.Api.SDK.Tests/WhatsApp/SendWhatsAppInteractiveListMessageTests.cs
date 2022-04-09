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
    public class SendWhatsAppInteractiveListMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendWhatsAppInteractiveListMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveListMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<WhatsAppSingleMessageInfoResponse>(responsePayloadFileName);

            var request = GetRequest();

            var response = await apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/SendWhatsAppInteractiveListMessageBadRequest.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_UnauthorizedResponse_Throws_InfobipUnauthorizedException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/Unauthorized.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.Unauthorized));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipUnauthorizedException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_TooManyRequestsResponse_Throws_InfobipTooManyRequestsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/WhatsApp/TooManyRequests.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.TooManyRequests));

            var request = GetRequest();

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipTooManyRequestsException>(act);
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_FromInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("", "447860099300",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.From)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ToInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "",
                Guid.NewGuid().ToString(),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.To)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_MessageIdInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                new string('x', 51),
                content);

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.MessageId)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_CallbackDataInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                new string('x', 4001));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.CallbackData)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_NotifyUrlInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content,
                notifyUrl: new string('x', 2049));

            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(WhatsAppFailoverMessage.NotifyUrl)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentBodyTextInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(request.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveListContent.Body)}.{nameof(WhatsAppInteractiveBodyContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentActionInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent(""),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(request.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveListContent.Action)}.{nameof(WhatsAppInteractiveListActionContent.Title)}");
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveListContent.Action)}.{nameof(WhatsAppInteractiveListActionContent.Sections)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentActionSectionsInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("title"),
                new WhatsAppInteractiveListActionContent("", new List<WhatsAppInteractiveListSectionContent>()));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(request.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(WhatsAppInteractiveListContent.Action)}.{nameof(WhatsAppInteractiveListActionContent.Sections)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentActionSectionsSectionInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("title"),
                new WhatsAppInteractiveListActionContent("title", new List<WhatsAppInteractiveListSectionContent>()
                {
                    new WhatsAppInteractiveListSectionContent("", new List<WhatsAppInteractiveRowContent>())
                }));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentActionSectionsPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveListContent.Action)}.{nameof(WhatsAppInteractiveListActionContent.Sections)}";
            errors.Should().Contain($"{contentActionSectionsPath}.{nameof(WhatsAppInteractiveListSectionContent.Title)}");
            errors.Should().Contain($"{contentActionSectionsPath}.{nameof(WhatsAppInteractiveListSectionContent.Rows)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentActionSectionsSectionRowInvalidInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("title"),
                new WhatsAppInteractiveListActionContent("title", new List<WhatsAppInteractiveListSectionContent>()
                {
                    new WhatsAppInteractiveListSectionContent("title", new List<WhatsAppInteractiveRowContent>()
                    {
                        new WhatsAppInteractiveRowContent("","", new string('x', 73))
                    })
                }));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentActionSectionsPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveListContent.Action)}.{nameof(WhatsAppInteractiveListActionContent.Sections)}";
            errors.Should().Contain($"{contentActionSectionsPath}.{nameof(WhatsAppInteractiveListSectionContent.Rows)}.{nameof(WhatsAppInteractiveRowContent.Id)}");
            errors.Should().Contain($"{contentActionSectionsPath}.{nameof(WhatsAppInteractiveListSectionContent.Rows)}.{nameof(WhatsAppInteractiveRowContent.Title)}");
            errors.Should().Contain($"{contentActionSectionsPath}.{nameof(WhatsAppInteractiveListSectionContent.Rows)}.{nameof(WhatsAppInteractiveRowContent.Description)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentHeaderTextInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("title"),
                new WhatsAppInteractiveListActionContent("title", new List<WhatsAppInteractiveListSectionContent>()),
                new WhatsAppInteractiveListTextHeaderContent(""));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveListContent.Header)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveListTextHeaderContent.Text)}");
        }

        [Fact]
        public async Task SendWhatsAppInteractiveListMessage_Call_With_ContentFooterTextInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("title"),
                new WhatsAppInteractiveListActionContent("title", new List<WhatsAppInteractiveListSectionContent>()),
                new WhatsAppInteractiveListTextHeaderContent("text"),
                new WhatsAppInteractiveFooterContent(""));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
                Guid.NewGuid().ToString(),
                content);


            // Act
            Func<Task> act = () => apiClient.WhatsApp.SendWhatsAppInteractiveListMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentHeaderPath = $"{nameof(request.Content)}.{nameof(WhatsAppInteractiveListContent.Footer)}";
            errors.Should().Contain($"{contentHeaderPath}.{nameof(WhatsAppInteractiveFooterContent.Text)}");
        }
        
        private WhatsAppInteractiveListMessageRequest GetRequest()
        {
            var buttons = new List<WhatsAppInteractiveListSectionContent>
            {
                new WhatsAppInteractiveListSectionContent("title", new List<WhatsAppInteractiveRowContent>()
                {
                    new WhatsAppInteractiveRowContent("id", "title", "")
                })
            };
            var content = new WhatsAppInteractiveListContent(new WhatsAppInteractiveBodyContent("text"), 
                new WhatsAppInteractiveListActionContent("title", buttons));
            var request = new WhatsAppInteractiveListMessageRequest("447860099299", "447860099300",
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