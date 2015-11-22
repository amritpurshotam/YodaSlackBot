using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Extensions;

namespace API.GroupsApi
{
    public class Purpose
    {
        public string value { get; set; }
        public string creator { get; set; }
        public double last_set { get; set; }

        public DateTime LastSetDateTime
        {
            get { return last_set.ToLocalDateTime(); }
        }
    }
}
