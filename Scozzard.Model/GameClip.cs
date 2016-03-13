using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Model
{
    public class GameClip
    {
        public int GameClipID { get; set; }
        public string XblID { get; set; }
        public DateTime DateRecorded { get; set; }
        public DateTime DatePublished { get; set; }
        public List<GameClipUri> ClipUris { get; set; }
        public List<GameClipThumbnail> Thumbnails { get; set; }
        public long XboxUserID { get; set; }
        public XboxUser XboxUser { get; set; }
        public string TitleName { get; set; }
        public string DeviceType { get; set; }
        public string State { get; set; }
    }

    public class GameClipThumbnail
    {
        public int GameClipThumbnailID { get; set; }
        public int GameClipID { get; set; }
        public string Uri { get; set; }
        public long FileSize { get; set; }
        public string ThumbnailType { get; set; }
    }

    public class GameClipUri
    {
        public int GameClipUriID { get; set; }
        public int GameClipID { get; set; }
        public string Uri { get; set; }
        public long FileSize { get; set; }
        public string UriType { get; set; }
        public DateTime Expiration { get; set; }
    }
}
