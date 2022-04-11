using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaMessageTemplateTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaMessageTemplateTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaMessageTemplate_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaMessageTemplateResponse>(responsePayloadFileName);

            // Act
            var response = await apiClient.Sms.GetTfaMessageTemplate("appId", "messageId");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetTfaMessageTemplate_AppIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.Sms.GetTfaMessageTemplate("", "messageId");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        [Fact]
        public async Task GetTfaMessageTemplate_MessageIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.Sms.GetTfaMessageTemplate("app_id", "");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}
