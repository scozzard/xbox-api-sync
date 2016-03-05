using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Model
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public long XboxUserID { get; set; }
        public string Platform { get; set; } //TODO: could be enum
        public string ContentType { get; set; } //TODO: couldbe enum
        public XboxUser XboxUser { get; set; }
    }
}
