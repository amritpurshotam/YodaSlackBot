using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace API.ChannelApi
{
    public class ChannelInfoResponseModel
    {
        public bool ok { get; set; }
        public Channel channel { get; set; }
        public string error { get; set; }
    }
}
