using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long XboxUserID { get; set; }
        public string Test { get; set; }
        public XboxUser XboxUser { get; set; }
    }
}
