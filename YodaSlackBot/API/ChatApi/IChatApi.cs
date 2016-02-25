namespace API.ChatApi
{
    public interface IChatApi
    {
        ChatUpdateResponseModel UpdateMessage(string slackApiToken, double messageTimeStamp, string channel, string text);
        PostMessageResponseModel PostMessage(string slackApiToken, string channel, string text);
    }
}
