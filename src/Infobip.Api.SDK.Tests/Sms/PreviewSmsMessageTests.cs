using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class PreviewSmsMessageTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public PreviewSmsMessageTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task PreviewSmsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/PreviewSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<PreviewSmsMessageResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.PreviewSmsMessage(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task PreviewSmsMessage_TextInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/PreviewSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestTextInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.PreviewSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }


        [Fact]
        public async Task PreviewSmsMessage_LanguageCodeInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/PreviewSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestLanguageCodeInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.PreviewSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task PreviewSmsMessage_TransliterationInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/PreviewSmsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestTransliterationInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.PreviewSmsMessage(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static PreviewSmsMessageRequest GetRequest()
        {
            var request = new PreviewSmsMessageRequest("message")
            {
                LanguageCode = "TR",
                Transliteration = "TURKISH"
            };
            return request;
        }

        private static PreviewSmsMessageRequest GetRequestTextInvalid()
        {
            var request = new PreviewSmsMessageRequest("")
            {
                LanguageCode = "TR",
                Transliteration = "TURKISH"
            };
            return request;
        }

        private static PreviewSmsMessageRequest GetRequestLanguageCodeInvalid()
        {
            var request = new PreviewSmsMessageRequest("message")
            {
                LanguageCode = "",
                Transliteration = "TURKISH"
            };
            return request;
        }

        private static PreviewSmsMessageRequest GetRequestTransliterationInvalid()
        {
            var request = new PreviewSmsMessageRequest("message")
            {
                LanguageCode = "TR",
                Transliteration = ""
            };
            return request;
        }

    }
}
