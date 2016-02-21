using System.Configuration;
using System.Linq;
using System.Text;
using API.ChannelApi;
using API.UserApi;
using Castle.Core.Internal;
using MargieBot.Models;
using MargieBot.Responders;
using YodaSlackBot.Extensions;

namespace YodaSlackBot.Responders
{
    public class UserInfoExampleResponder : IResponder
    {
        private readonly IChannelApi channelApi;
        private readonly IUserApi userApi;

        public UserInfoExampleResponder(IChannelApi channelApi, IUserApi userApi)
        {
            this.channelApi = channelApi;
            this.userApi = userApi;
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
                var userInfo = userApi.GetUserInfo(ConfigurationManager.AppSettings["SlackBotApiToken"], user);
                builder.AppendLine(userInfo.user.profile.email.IsNullOrEmpty() ? userInfo.user.name : userInfo.user.profile.email);
            }

            return new BotMessage { Text = builder.ToString() };
        }
    }
}
