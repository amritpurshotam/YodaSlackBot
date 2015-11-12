using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.GroupsApi
{
    public class Purpose
    {
        public string value { get; set; }
        public string creator { get; set; }
        public double last_set { get; set; }

        public DateTime LastSetDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(last_set)
                    .ToLocalTime();
            }
        }
    }
}
