using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scozzard.Model;

namespace Scozzard.Web.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int XboxUserID { get; set; }
        public XboxUser XboxUser { get; set; }
    }
}