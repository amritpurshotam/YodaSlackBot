using System;
using API.Extensions;

namespace API.ChatApi
{
    public class ChatUpdateResponseModel
    {
        public bool ok { get; set; }
        public string channel { get; set; }
        public double ts { get; set; }
        public string error { get; set; }

        public DateTime TimeStamp
        {
            get { return ts.ToLocalDateTime(); }
        }
    }
}