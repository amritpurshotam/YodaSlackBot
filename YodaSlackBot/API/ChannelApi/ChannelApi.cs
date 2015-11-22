using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.GroupsApi;
using Flurl.Http;
using ServiceStack.Text;

namespace API.ChannelApi
{
    public class ChannelApi : IChannelApi
    {
        public ChannelListResponseModel ListChannels(string slackApiToken)
        {
            var responseString = "https://slack.com/api/channels.list"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        exclude_archived = 0
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<ChannelListResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }

        public GroupsHistoryResponseModel GetChannelHistory(string slackApiToken, string channel, DateTime startTime, DateTime endTime, int count)
        {
            var responseString = "https://slack.com/api/channels.history"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        channel,
                        latest = endTime.ToUnixTime(),
                        oldest = startTime.ToUnixTime(),
                        count
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<GroupsHistoryResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }

        public ChannelInfoResponseModel GetChannelInfo(string slackApiToken, string channel)
        {
            var responseString = "https://slack.com/api/channels.info"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        channel
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<ChannelInfoResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }
    }
}
