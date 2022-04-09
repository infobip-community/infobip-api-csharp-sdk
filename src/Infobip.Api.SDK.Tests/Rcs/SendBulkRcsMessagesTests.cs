using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.RCS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Rcs
{
    public class SendBulkRcsMessagesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendBulkRcsMessagesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
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

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/BadRequest.json";
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

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidMessagesInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var request = new SendRscBulkMessagesRequest();

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain(nameof(request.Messages));
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidToInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeContent(MessageTypeContentTypeEnum.Text);
            var messages = new List<SendRcsMessageRequest>
            {
                new("", "", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.To)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidSmsFailoverInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeContent(MessageTypeContentTypeEnum.Text);
            var messages = new List<SendRcsMessageRequest>
            {
                new("", "", content)
                {
                    SmsFailover = new SmsFailover("", "", ValidityPeriodTimeUnitEnum.Minutes)
                }
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.To)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.SmsFailover)}.{nameof(SmsFailover.From)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.SmsFailover)}.{nameof(SmsFailover.Text)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidTextContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeTextContent("");
            var messages = new List<SendRcsMessageRequest>
            {
                new("", "", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.To)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.Content)}.{nameof(MessageTypeTextContent.Text)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidFileContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeFileContent(new MessageResource(""), new MessageResource(""));
            var messages = new List<SendRcsMessageRequest>
            {
                new("", "", content)
                {
                    SmsFailover = new SmsFailover("","", ValidityPeriodTimeUnitEnum.Minutes)
                }
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.To)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.Content)}.{nameof(MessageTypeFileContent.File)}.{nameof(MessageTypeFileContent.File.Url)}");
            errors.Should().Contain($"{nameof(request.Messages)}.{nameof(SendRcsMessageRequest.Content)}.{nameof(MessageTypeFileContent.Thumbnail)}.{nameof(MessageTypeFileContent.Thumbnail.Url)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidCardContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("", "",
                    new CardMedia(new MessageResource(""), CardMediaHeightEnum.Medium, new MessageResource(""))),
                new List<Suggestion> { new Suggestion("", "", CardContentSuggestionTypeEnum.DialPhone) });
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(MessageTypeCardContent.Content)}.{nameof(CardContent.Title)}");
            errors.Should().Contain($"{contentPath}.{nameof(MessageTypeCardContent.Content)}.{nameof(CardContent.Description)}");
            errors.Should().Contain($"{contentPath}.{nameof(MessageTypeCardContent.Content)}.{nameof(CardContent.Media)}.{nameof(CardMedia.File)}.{nameof(CardMedia.File.Url)}");
            errors.Should().Contain($"{contentPath}.{nameof(MessageTypeCardContent.Content)}.{nameof(CardContent.Media)}.{nameof(CardMedia.Thumbnail)}.{nameof(CardMedia.Thumbnail.Url)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.PostbackData)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion>()
                {
                    new Suggestion("","", CardContentSuggestionTypeEnum.ShowLocation)
                }
                );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.PostbackData)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsSuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new Suggestion("", "", CardContentSuggestionTypeEnum.Reply) }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.PostbackData)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsRequestLocationSuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new RequestLocationSuggestion("", "") }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.PostbackData)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsReplySuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new ReplySuggestion("", "") }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ReplySuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ReplySuggestion.PostbackData)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsOpenUrlSuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new OpenUrlSuggestion("", "", "") }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.PostbackData)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.Url)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsDialPhoneSuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new DialPhoneSuggestion("", "", "") }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.PostbackData)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.PhoneNumber)}");
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_With_InvalidContentSuggestionsShowLocationSuggestionInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion> { new ShowLocationSuggestion(-100, 200, "", "", "") }
            );
            var messages = new List<SendRcsMessageRequest>
            {
                new("from", "to", content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendBulkRcsMessages(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var messagesPath = $"{nameof(request.Messages)}";
            var contentPath = $"{messagesPath}.{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ShowLocationSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ShowLocationSuggestion.Label)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ShowLocationSuggestion.PostbackData)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ShowLocationSuggestion.Latitude)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(ShowLocationSuggestion.Longitude)}");
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
