using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Infobip.Api.Client.RCS.Models;
using Xunit;

namespace Infobip.Api.Client.Tests
{
    public class RcsTests : IClassFixture<MockedHttpClientFixture>

    {
        private readonly MockedHttpClientFixture _clientFixture;

        public RcsTests(MockedHttpClientFixture clientFixture)
        {
            _clientFixture = clientFixture;
        }

        [Fact]
        public async Task SendRcsMessage_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/Rcs/SendRcsMessageSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<RcsMessageResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeContent(MessageTypeContent.TypeEnum.TEXT);
            var request = new SendRcsMessageRequest("447860099299", "447860099300", content: content);

            // Act
            var response = await apiClient.Rcs.SendRcsMessage(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task SendBulkRcsMessages_Call_ExpectsSuccess()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var responsePayloadFileName = "Data/Rcs/SendBulkRcsMessagesSuccess.json";
            var apiClient = new InfobipApiClient(_clientFixture.GetClient<RcsMessageResponse>(responsePayloadFileName));
            var mockedResponse = _clientFixture.GetMockedResponse<RcsMessageResponse>(responsePayloadFileName);

            var content = new MessageTypeContent(MessageTypeContent.TypeEnum.TEXT);
            var messages = new List<SendRcsMessageRequest>
            {
                new("447860099299", "447860099300", content: content)
            };
            var request = new SendRscBulkMessagesRequest(messages);

            // Act
            var response = await apiClient.Rcs.SendBulkRcsMessages(request, cts.Token);

            // Assert
            mockedResponse.Should().BeEquivalentTo(response);
        }
    }
}
