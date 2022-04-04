using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class SendTfaPinCodeOverSmsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendTfaPinCodeOverSmsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendTfaPinCodeOverSms_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendTfaPinCodeOverSmsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaPinCodeResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.SendTfaPinCodeOverSms(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendTfaPinCodeOverSms_AppIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendTfaPinCodeOverSmsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestAppIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendTfaPinCodeOverSms(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendTfaPinCodeOverSms_MessageIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendTfaPinCodeOverSmsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageIdInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendTfaPinCodeOverSms(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendTfaPinCodeOverSms_ToInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendTfaPinCodeOverSmsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestToInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendTfaPinCodeOverSms(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static SendTfaPinCodeRequest GetRequest()
        {
            var request = new SendTfaPinCodeRequest("appId", "messageId","447860099299");
            return request;
        }

        private static SendTfaPinCodeRequest GetRequestAppIdInvalid()
        {
            var request = new SendTfaPinCodeRequest("", "messageId", "447860099299");
            return request;
        }

        private static SendTfaPinCodeRequest GetRequestMessageIdInvalid()
        {
            var request = new SendTfaPinCodeRequest("appId", "", "447860099299");
            return request;
        }

        private static SendTfaPinCodeRequest GetRequestToInvalid()
        {
            var request = new SendTfaPinCodeRequest("appId", "messageId", "");
            return request;
        }
    }
}
