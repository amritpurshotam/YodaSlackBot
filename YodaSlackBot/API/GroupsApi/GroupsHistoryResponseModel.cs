using System;
using API.Extensions;

namespace API.GroupsApi
{
    public class GroupsHistoryResponseModel
    {
        public bool ok { get; set; }
        public double latest { get; set; }
        public Message [] messages { get; set; }
        public bool has_more { get; set; }

        public DateTime LatestTimeStamp
        {
            get { return latest.ToLocalDateTime(); }
        }
    }
}
