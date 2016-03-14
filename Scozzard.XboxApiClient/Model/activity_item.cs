using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.XboxApiClient.Model
{
    public class activity_item
    {
        public DateTime? startTime { get; set; }
	    public DateTime? endTime { get; set; }
	    public int sessionDurationInMinutes { get; set; }
	    public string contentImageUri { get; set; }
	    public string bingId { get; set; }
	    public string contentTitle { get; set; }
	    public string vuiDisplayName { get; set; }
	    public string platform { get; set; } // TODO: enum
	    public int titleId { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
	    public string activityItemType { get; set; } //TODO: enum
	    public string contentType { get; set; } //TODO: enum
	    public string shortDescription { get; set; }
	    public string itemText { get; set; }
	    public string itemImage { get; set; }
	    public string shareRoot { get; set; }
	    public string feedItemId { get; set; }
	    public string itemRoot { get; set; }
	    public string gamertag { get; set; }
	    public string displayName { get; set; }
	    public string userImageUri { get; set; }
	    public long userXuid { get; set; }
    }
}
