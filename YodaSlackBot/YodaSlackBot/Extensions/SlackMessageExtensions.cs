using MargieBot.Models;
using ServiceStack.Text;
using YodaSlackBot.Models;

namespace YodaSlackBot.Extensions
{
    public static class SlackMessageExtensions
    {
        public static string GetTimeStamp(this SlackMessage message)
        {
            var serializer = new JsonSerializer<SlackRawDataModel>();
            var rawData = serializer.DeserializeFromString(message.RawData);
            return rawData.ts;
        }

        public static string GetChannelId(this SlackMessage message)
        {
            var serializer = new JsonSerializer<SlackRawDataModel>();
            var rawData = serializer.DeserializeFromString(message.RawData);
            return rawData.channel;
        }
    }
}
