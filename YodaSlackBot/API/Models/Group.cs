using System;
using API.Extensions;
using API.Models;

namespace API.GroupsApi
{
    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public double created { get; set; }
        public bool is_group { get; set; }
        public string creator { get; set; }
        public bool is_archived { get; set; }
        public bool is_mpim { get; set; }
        public string [] members { get; set; }
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

        public DateTime LastReadDateTime
        {
            get { return last_read.ToLocalDateTime(); }
        }
    }
}
