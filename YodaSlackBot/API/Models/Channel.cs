using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Extensions;
using API.GroupsApi;

namespace API.Models
{
    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
        public double created { get; set; }
        public bool is_channel { get; set; }
        public string creator { get; set; }
        public bool is_archived { get; set; }
        public bool is_member { get; set; }
        public bool is_general { get; set; }
        public string[] members { get; set; }
        public int num_members { get; set; }
        public Topic topic { get; set; }
        public Purpose purpose { get; set; }
        public double last_read { get; set; }
        public int unread_count { get; set; }
        public int unread_count_display { get; set; }
        public Message latest { get; set; }

        public DateTime CreatedDateTime
        {
            get { return created.ToLocalDateTime(); }
        }

        public DateTime LastReadTimeStamp
        {
            get { return last_read.ToLocalDateTime(); }
        }
    }
}
