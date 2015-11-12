using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.GroupsApi
{
    public class Message
    {
        public string type { get; set; }
        public string channel { get; set; }
        public string user { get; set; }
        public string text { get; set; }
        public double ts { get; set; }
        public string team { get; set; }
        public bool is_starred { get; set; }
        public bool wibblr { get; set; }
        public string [] pinned_to { get; set; }
        public EditedMessage edited { get; set; }
        public Reaction [] reactions { get; set; }
    }
}
