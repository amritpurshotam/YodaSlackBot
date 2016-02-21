namespace API.ChatApi
{
    public interface IChatApi
    {
        ChatUpdateResponseModel UpdateMessage(string slackApiToken, double messageTimeStamp, string channel, string text);
    }
}
