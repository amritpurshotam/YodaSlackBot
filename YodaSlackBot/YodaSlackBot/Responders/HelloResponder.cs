using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MargieBot.Models;
using MargieBot.Responders;

namespace YodaSlackBot.Responders
{
    public class HelloResponder : IResponder
    {
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
            return new BotMessage { Text = builder.ToString() };
        }
    }
}
