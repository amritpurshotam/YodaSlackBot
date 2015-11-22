using System;
using System.Configuration;
using System.Linq;
using System.Text;
using API.Extensions;
using API.GroupsApi;
using Castle.Core.Internal;
using MargieBot.Models;
using MargieBot.Responders;

namespace YodaSlackBot.Responders
{
    public class GroupsHistoryExampleResponder : IResponder
    {
        private readonly IGroupsApi groupsApi;

        public GroupsHistoryExampleResponder(IGroupsApi groupsApi)
        {
            this.groupsApi = groupsApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return !context.BotHasResponded
                   && context.Message.MentionsBot
                   && context.Message.Text.Contains("all reactions");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();

            var groupList = groupsApi.ListGroups(ConfigurationManager.AppSettings["SlackBotApiToken"]).groups.Select(x => x.id);

            foreach (var groupId in groupList)
            {
                var history = new GroupsHistoryResponseModel();
                var hasMore = true;

                while (hasMore)
                {
                    history = groupsApi.GetGroupHistory(
                        ConfigurationManager.AppSettings["SlackBotApiToken"],
                        groupId,
                        DateTime.Now.AddHours(-1),
                        history.messages.Any() ? history.messages.Last().ts.ToLocalDateTime() : DateTime.Now,
                        100
                    );

                    foreach (var reactionList in history.messages.Select(x => x.reactions).Where(y => !y.IsNullOrEmpty()))
                    {
                        foreach (var reaction in reactionList)
                        {
                            builder.AppendLine(reaction.name);
                        }
                    }

                    hasMore = history.has_more;
                }
            }

            return new BotMessage {Text = builder.ToString()};
        }
    }
}
