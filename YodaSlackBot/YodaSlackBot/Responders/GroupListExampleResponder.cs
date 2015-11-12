using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using API.GroupsApi;
using Castle.Windsor.Installer;
using MargieBot.Models;
using MargieBot.Responders;

namespace YodaSlackBot.Responders
{
    public class GroupListExampleResponder : IResponder
    {
        private readonly IGroupsApi groupsApi;

        public GroupListExampleResponder(IGroupsApi groupsApi)
        {
            this.groupsApi = groupsApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return !context.BotHasResponded
                   && context.Message.MentionsBot
                   && context.Message.Text.ToLower().Contains("list groups");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();

            var groupsResponse = groupsApi.ListGroups(ConfigurationManager.AppSettings["SlackBotApiToken"]);
            if (!groupsResponse.ok) return new BotMessage{ Text = "Request to slack failed. Details: " + groupsResponse.error };
            
            builder.AppendLine("To these groups, I belong. Hmmmmm");
            foreach (var group in groupsResponse.groups)
            {
                builder.AppendLine(group.name);
            }

            return new BotMessage{ Text = builder.ToString() };
        }
    }
}
