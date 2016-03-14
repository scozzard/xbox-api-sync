using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.Model
{
    public class Screenshot
    {
        public int ScreenshotID { get; set; }
        public string XblID { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DatePublished { get; set; }
        public List<ScreenshotUri> ScreenshotUris { get; set; }
        public List<ScreenshotThumbnail> Thumbnails { get; set; }
        public long XboxUserID { get; set; }
        public XboxUser XboxUser { get; set; }
        public string TitleName { get; set; }
        public string DeviceType { get; set; }
        public string State { get; set; }
    }

    public class ScreenshotThumbnail
    {
        public int ScreenshotThumbnailID { get; set; }
        public int ScreenshotID { get; set; }
        public string Uri { get; set; }
        public long FileSize { get; set; }
        public string ThumbnailType { get; set; }
    }

    public class ScreenshotUri
    {
        public int ScreenshotUriID { get; set; }
        public int ScreenshotsID { get; set; }
        public string Uri { get; set; }
        public long FileSize { get; set; }
        public string UriType { get; set; }
        public DateTime Expiration { get; set; }
    }
}
