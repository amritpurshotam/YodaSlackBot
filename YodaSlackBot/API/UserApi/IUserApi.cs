namespace API.UserApi
{
    public interface IUserApi
    {
        UserInfoResponseModel GetUserInfo(string slackApiToken, string userSlackId);
    }
}
