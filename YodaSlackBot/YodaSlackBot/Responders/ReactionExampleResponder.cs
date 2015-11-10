using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.ReactionApi;
using MargieBot.Models;
using MargieBot.Responders;
using YodaSlackBot.Extensions;

namespace YodaSlackBot.Responders
{
    public class ReactionExampleResponder : IResponder
    {
        private readonly IReactionApi reactionApi;
 
        public ReactionExampleResponder(IReactionApi reactionApi)
        {
            this.reactionApi = reactionApi;
        }

        public bool CanRespond(ResponseContext context)
        {
            return !context.BotHasResponded
                   && context.Message.Text.ToLower().Contains("it works on my machine");
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            var success = reactionApi.AddReaction("itworksonmymachine", context.Message.GetChannelId(), context.Message.GetTimeStamp());
            var message = success ? "Reaction successfully added." : "Reaction failed.";
            return new BotMessage {Text = message };
        }
    }
}
