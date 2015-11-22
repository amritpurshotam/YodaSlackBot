using System;

namespace API.GroupsApi
{
    public interface IGroupsApi
    {
        GroupsListResponseModel ListGroups(string slackApiToken);

        GroupsHistoryResponseModel GetGroupHistory(string slackApiToken, string channel, DateTime startTime, DateTime endTime, int count);
    }
}
