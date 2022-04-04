using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class SendSmsMessageOverQueryParametersOverQueryParametersTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public SendSmsMessageOverQueryParametersOverQueryParametersTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<SendSmsMessageResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_UsernameInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestUsernameInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_PasswordInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestPasswordInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_FromInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestFromInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_ToInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestToInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task SendSmsMessageOverQueryParameters_TextInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/SendSmsMessageOverQueryParametersSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestTextInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.SendSmsMessageOverQueryParameters(request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequest()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "user",
                Password = "pass",
                From = "447860099299",
                To = "447860099300",
                Text = "message"
            };
            return request;
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequestUsernameInvalid()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "",
                Password = "pass",
                From = "447860099299",
                To = "447860099300",
                Text = "message"
            };
            return request;
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequestPasswordInvalid()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "user",
                Password = "",
                From = "447860099299",
                To = "447860099300",
                Text = "message"
            };
            return request;
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequestFromInvalid()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "user",
                Password = "pass",
                From = "",
                To = "447860099300",
                Text = "message"
            };
            return request;
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequestToInvalid()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "user",
                Password = "pass",
                From = "447860099299",
                To = "",
                Text = "message"
            };
            return request;
        }

        private static SendSmsMessageOverQueryParametersRequest GetRequestTextInvalid()
        {
            var request = new SendSmsMessageOverQueryParametersRequest
            {
                Username = "user",
                Password = "pass",
                From = "447860099299",
                To = "447860099300",
                Text = ""
            };
            return request;
        }
    }
}
