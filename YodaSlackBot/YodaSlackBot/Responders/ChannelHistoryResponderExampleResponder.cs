using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using API.ChannelApi;
using API.Extensions;
using API.GroupsApi;
using Castle.Core.Internal;
using MargieBot.Models;
using MargieBot.Responders;

namespace YodaSlackBot.Responders
{
    public class ChannelHistoryResponderExampleResponder : IResponder
    {
        private readonly IChannelApi channelApi;

        public ChannelHistoryResponderExampleResponder(IChannelApi channelApi)
        {
            this.channelApi = channelApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return !context.BotHasResponded
                   && context.Message.MentionsBot
                   && context.Message.Text.Contains("channel history");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();

            var channelList = channelApi.ListChannels(ConfigurationManager.AppSettings["SlackBotApiToken"]).channels;

            foreach (var channel in channelList)
            {
                var count = 0;
                var history = new GroupsHistoryResponseModel();
                var hasMore = true;

                while (hasMore)
                {
                    history = channelApi.GetChannelHistory(
                        ConfigurationManager.AppSettings["SlackBotApiToken"],
                        channel.id,
                        DateTime.Now.AddYears(-1),
                        history.messages.Any() ? history.messages.Last().ts.ToLocalDateTime() : DateTime.Now,
                        100
                    );

                    count = count + history.messages.Count();

                    hasMore = history.has_more;
                }

                builder.Append("Messages in ").Append(channel.name).Append(": ").Append(count).Append("\n");
            }

            return new BotMessage { Text = builder.ToString() };
        }
    }
}
