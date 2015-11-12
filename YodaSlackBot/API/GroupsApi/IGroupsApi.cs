namespace API.GroupsApi
{
    public interface IGroupsApi
    {
        GroupsListResponseModel ListGroups(string slackApiToken);
    }
}
