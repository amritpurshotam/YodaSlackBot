using System.Configuration;
using System.Text;
using API.ChannelApi;
using MargieBot.Models;
using MargieBot.Responders;
using YodaSlackBot.Extensions;

namespace YodaSlackBot.Responders
{
    public class UserInfoExampleResponder : IResponder
    {
        private readonly IChannelApi channelApi;

        public UserInfoExampleResponder(IChannelApi channelApi)
        {
            this.channelApi = channelApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return !context.BotHasResponded
                   && context.Message.MentionsBot
                   && context.Message.Text.ToLower().Contains("list users");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();

            var users = channelApi.GetChannelInfo(ConfigurationManager.AppSettings["SlackBotApiToken"],
                context.Message.GetChannelId()).channel.members;

            foreach (var user in users)
            {
                builder.AppendLine(user);
            }

            return new BotMessage { Text = builder.ToString() };
        }
    }
}
