using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.Exceptions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaMessageTemplatesTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaMessageTemplatesTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaMessageTemplates_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplatesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<List<TfaMessageTemplateResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.Sms.GetTfaMessageTemplates("app_id");

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetTfaMessageTemplates_AppIdInvalid_Call_ThrowsException()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaMessageTemplatesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));

            // Act
            Func<Task> act = () => apiClient.Sms.GetTfaMessageTemplates("");

            // Assert
            await Assert.ThrowsAsync<InfobipRequestNotValidException>(act);
        }
    }
}
