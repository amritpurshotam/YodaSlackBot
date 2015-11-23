using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace API.UserApi
{
    public class UserInfoResponseModel
    {
        public bool ok { get; set; }
        public User user { get; set; }
        public string error { get; set; }
    }
}
