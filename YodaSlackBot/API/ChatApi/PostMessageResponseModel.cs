using API.Models;

namespace API.ChatApi
{
    public class PostMessageResponseModel
    {
        public bool ok { get; set; }
        public string error { get; set; }
        public double ts { get; set; }
        public string channel { get; set; }
        public Message message { get; set; }
    }
}
