using System;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class CreateTfaMessageTemplateTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public CreateTfaMessageTemplateTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task CreateTfaMessageTemplate_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/CreateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<TfaMessageTemplateResponse>(responsePayloadFileName);

            var request = GetRequest();

            // Act
            var response = await apiClient.Sms.CreateTfaMessageTemplate("app_id", request);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task CreateTfaMessageTemplate_MessageTextInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/CreateTfaMessageTemplateSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            var request = GetRequestMessageTextInvalid();

            // Act
            Func<Task> act = () => apiClient.Sms.CreateTfaMessageTemplate("app_id", request);

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }

        private static TfaMessageTemplateRequest GetRequest()
        {
            var request = new TfaMessageTemplateRequest("Your pin is {{pin}}", TfaPinType.Numeric);
            return request;
        }

        private static TfaMessageTemplateRequest GetRequestMessageTextInvalid()
        {
            var request = new TfaMessageTemplateRequest("pin placeholder is missing...", TfaPinType.Numeric);
            return request;
        }
    }
}
