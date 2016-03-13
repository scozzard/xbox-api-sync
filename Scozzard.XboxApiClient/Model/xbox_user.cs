using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.XboxApiClient.Model
{
    // The API object profile relates to an XboxUser
    public class xbox_user
    {
        	public long id { get; set; }
	        public int hostId { get; set; }
	        public string Gamertag { get; set; }
	        public string GameDisplayName { get; set; }
	        public string AppDisplayName { get; set; }
	        public int Gamerscore { get; set; }
	        public string GameDisplayPicRaw { get; set; }
	        public string AppDisplayPicRaw { get; set; }
	        public string AccountTier { get; set; }
	        public string XboxOneRep { get; set; }
	        public string PreferredColor { get; set; }
	        public int TenureLevel { get; set; }
	        public bool isSponsoredUser { get; set; }
    }
}
