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
    public class SendRcsMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendRcsMessageTests(MockedHttpClientFixture clientFixture)
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
        public async Task SendRcsMessage_Call_With_BadRequestResponse_Throws_InfobipBadRequestException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Rcs/BadRequest.json";
            var apiClient =
                new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName, HttpStatusCode.BadRequest));

            var content = new MessageTypeTextContent("Text");
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipBadRequestException>(act);
        }

        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidToInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeContent(MessageTypeContentTypeEnum.Text);
            var request = new SendRcsMessageRequest("from", "", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.To)}");
        }

        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidTextContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeTextContent("");
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Content)}.{nameof(MessageTypeTextContent.Text)}");
        }

        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidFileContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeFileContent(new MessageResource(""), new MessageResource(""));
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            errors.Should().Contain($"{nameof(request.Content)}.{nameof(MessageTypeFileContent.File)}.{nameof(MessageResource.Url)}");
            errors.Should().Contain($"{nameof(request.Content)}.{nameof(MessageTypeFileContent.Thumbnail)}.{nameof(MessageResource.Url)}");
        }

        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidCardContentInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("", "",
                    new CardMedia(new MessageResource(""), CardMediaHeightEnum.Medium, new MessageResource(""))),
                new List<Suggestion> { new Suggestion("", "", CardContentSuggestionTypeEnum.DialPhone) });
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{contentPath}.{nameof(CardContent.Title)}");
            errors.Should().Contain($"{contentPath}.{contentPath}.{nameof(CardContent.Description)}");
            errors.Should().Contain($"{contentPath}.{contentPath}.{nameof(CardContent.Media)}.{nameof(CardMedia.File)}.{nameof(MessageResource.Url)}");
            errors.Should().Contain($"{contentPath}.{contentPath}.{nameof(CardContent.Media)}.{nameof(CardMedia.Thumbnail)}.{nameof(MessageResource.Url)}");
        }

        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsInRequest_Throws_InfobipRequestNotValidException()
        {
            // Arrange
            var responseMessage = GetResponseMessage();
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responseMessage));

            var content = new MessageTypeCardContent(MessageTypeCardContentOrientationEnum.Horizontal,
                MessageTypeCardContentAlignmentEnum.Left,
                new CardContent("card_title", "description",
                    new CardMedia(new MessageResource("url"), CardMediaHeightEnum.Medium, new MessageResource("url"))),
                new List<Suggestion>
                {
                    new Suggestion("","", CardContentSuggestionTypeEnum.ShowLocation)
                }
                );
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(Suggestion.PostbackData)}");
        }
        
        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsRequestLocationSuggestionInRequest_Throws_InfobipRequestNotValidException()
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
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.PostbackData)}");
        }
        
        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsReplySuggestionInRequest_Throws_InfobipRequestNotValidException()
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
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(RequestLocationSuggestion.PostbackData)}");
        }
        
        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsOpenUrlSuggestionInRequest_Throws_InfobipRequestNotValidException()
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
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.PostbackData)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(OpenUrlSuggestion.Url)}");
        }
        
        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsDialPhoneSuggestionInRequest_Throws_InfobipRequestNotValidException()
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
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.Text)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.PostbackData)}");
            errors.Should().Contain($"{contentPath}.{nameof(CardContent.Suggestions)}.{nameof(DialPhoneSuggestion.PhoneNumber)}");
        }
        
        [Fact]
        public async Task SendRcsMessage_Call_With_InvalidContentSuggestionsShowLocationSuggestionInRequest_Throws_InfobipRequestNotValidException()
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
            var request = new SendRcsMessageRequest("from", "to", content);

            // Act
            Func<Task> act = () => apiClient.Rcs.SendRcsMessage(request);

            // Assert
            var exception = await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
            exception.ValidationResults.Should().HaveCountGreaterThan(0);
            var errors = exception.ValidationResults.SelectMany(result => result.MemberNames.Select(s => s)).ToArray();
            var contentPath = $"{nameof(SendRcsMessageRequest.Content)}";
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
