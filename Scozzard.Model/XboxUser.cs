using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Model
{
    public class XboxUser
    {
        public long XboxUserID { get; set; }
        public string GamerTag { get; set; }
        public string GameDisplayName { get; set; }
        public int Gamerscore { get; set; }
        public string GameDisplayPicRaw { get; set; }
        public string AccountTier { get; set; }
        public string XboxOneRep { get; set; }
        public string PreferredColor { get; set; }
        public int TenureLevel { get; set; }
        public List<XboxUser> Friends { get; set; }
        public List<Activity> Activities { get; set; }
        public DateTime ProfileLastSyncedAt { get; set; }
        public DateTime ActivitiesLastSyncedAtt { get; set; }
    }
}
