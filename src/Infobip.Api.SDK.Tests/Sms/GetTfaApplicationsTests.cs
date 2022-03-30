using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.SDK.SMS.Models;
using Xunit;

namespace Infobip.Api.SDK.Tests.Sms
{
    public class GetTfaApplicationsTests : IClassFixture<MockedHttpClientFixture>
    {
        private readonly MockedHttpClientFixture _clientFixture;

        public GetTfaApplicationsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task GetTfaApplications_Call_ExpectsSuccess()
        {
            // Arrange
            var responsePayloadFileName = "Data/Sms/GetTfaApplicationsSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<List<TfaApplicationResponse>>(responsePayloadFileName);

            // Act
            var response = await apiClient.Sms.GetTfaApplications();

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
