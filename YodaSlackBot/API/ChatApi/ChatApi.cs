using Flurl.Http;
using ServiceStack.Text;

namespace API.ChatApi
{
    public class ChatApi : IChatApi
    {
        public ChatUpdateResponseModel UpdateMessage(string slackApiToken, double messageTimeStamp, string channel, string text)
        {
            var responseString = "https://slack.com/api/chat.update"
                .PostUrlEncodedAsync(
                    new
                    {
                        token = slackApiToken,
                        ts = messageTimeStamp,
                        channel,
                        text
                    })
                .ReceiveString()
                .Result;

            var serializer = new JsonSerializer<ChatUpdateResponseModel>();
            var response = serializer.DeserializeFromString(responseString);
            return response;
        }
    }
}
