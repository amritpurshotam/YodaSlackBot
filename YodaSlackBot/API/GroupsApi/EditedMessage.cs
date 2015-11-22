using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Extensions;

namespace API.GroupsApi
{
    public class EditedMessage
    {
        public string user { get; set; }
        public double ts { get; set; }

        public DateTime TimeStamp
        {
            get { return ts.ToLocalDateTime(); }
        }
    }
}
