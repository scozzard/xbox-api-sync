using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scozzard.Model;

namespace Scozzard.Web.ViewModels
{
    public class ActivityViewModel
    {
        public int ActivityID { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int XboxUserID { get; set; }
        public XboxUser XboxUser { get; set; }
    }
}