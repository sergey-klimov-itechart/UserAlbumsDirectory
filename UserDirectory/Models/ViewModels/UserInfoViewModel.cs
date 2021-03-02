using System.Collections.Generic;

namespace UserDirectory.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public User UserInfo { get; set; }
        public string ReturnUrl { get; set; }
    }
}
