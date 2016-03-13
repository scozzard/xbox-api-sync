using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scozzard.XboxApiClient.Model
{
    public class game_clip
    {
        public string gameClipId { get; set; }
        public string titleName { get; set; }
        public string state { get; set; }
        public DateTime dateRecorded { get; set; }
        public DateTime datePublished { get; set; }
        public string deviceType { get; set; }
        public List<game_clip_thumbnail> thumbnails { get; set; }
        public List<game_clip_uri> gameClipUris { get; set; }
    }
}
