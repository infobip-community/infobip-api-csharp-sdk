using System;
using System.Net;
using System.Threading.Tasks;
using Infobip.Api.Client.RCS.Models;
using RestSharp;

namespace Infobip.Api.Client.RCS
{
    internal class Rcs : IRcs
    {
        private readonly IRestClient _client;

        public Rcs(IRestClient client)
        {
            _client = client;
        }

        public async Task<RcsMessageResponse> SendRcsMessage(SendRcsMessageRequest requestPayload)
        {
            var request = new RestRequest("ott/rcs/1/message", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<RcsMessageResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }

        public async Task<RcsMessageResponse> SendBulkRcsMessages(SendRscBulkMessagesRequest requestPayload)
        {
            var request = new RestRequest("ott/rcs/1/message/bulk", Method.POST);
            request.AddJsonBody(requestPayload);

            var result = await _client.ExecuteAsync<RcsMessageResponse>(request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(result.Content);
            }

            return result.Data;
        }
    }
}