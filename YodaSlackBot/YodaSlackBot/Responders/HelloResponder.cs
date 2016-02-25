using System.Configuration;
using System.Text;
using API.ChatApi;
using MargieBot.Models;
using MargieBot.Responders;

namespace YodaSlackBot.Responders
{
    public class HelloResponder : IResponder
    {
        private readonly IChatApi chatApi;

        public HelloResponder(IChatApi chatApi)
        {
            this.chatApi = chatApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return context.Message.MentionsBot
                && !context.BotHasResponded
                   && context.Message.Text.ToLower().Contains("hello");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var builder = new StringBuilder();
            builder.Append("Hello ");
            builder.Append(context.Message.User.FormattedUserID);

            chatApi.PostMessage(ConfigurationManager.AppSettings["SlackBotApiToken"], context.Message.User.ID, "hello dm");

            return new BotMessage { Text = builder.ToString() };
        }
    }
}
