using Flurl.Http;
using ServiceStack.Text;

namespace API.UserApi
{
    public class UserApi : IUserApi
    {
        public UserInfoResponseModel GetUserInfo(string slackApiToken, string userSlackId)
        {
            var responseString = "https://slack.com/api/users.info"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        user = userSlackId
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<UserInfoResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }
    }
}
