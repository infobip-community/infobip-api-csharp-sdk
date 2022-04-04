using System;
using System.Collections.Generic;
using System.Net;
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
    }
}
