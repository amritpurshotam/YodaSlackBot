using System;
using Flurl.Http;
using ServiceStack.Text;

namespace API.GroupsApi
{
    public class GroupsApi : IGroupsApi
    {
        public GroupsListResponseModel ListGroups(string slackApiToken)
        {
            var responseString = "https://slack.com/api/groups.list"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        exclude_archived = 0
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<GroupsListResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }

        public GroupsHistoryResponseModel GetGroupHistory(string slackApiToken, string channel, DateTime startTime, DateTime endTime, int count)
        {
            var responseString = "https://slack.com/api/groups.history"
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

        public GroupsInfoResponseModel GetGroupInfo(string slackApiToken, string channel)
        {
            var responseString = "https://slack.com/api/groups.info"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        channel
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<GroupsInfoResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }
    }
}
