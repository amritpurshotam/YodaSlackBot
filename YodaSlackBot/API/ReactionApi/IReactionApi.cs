using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ReactionApi
{
    public interface IReactionApi
    {
        bool AddReaction(string reaction, string channel, string timestamp);
    }
}
