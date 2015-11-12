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
    }
}
