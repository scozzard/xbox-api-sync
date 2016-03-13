using System;

namespace Scozzard.XboxApiClient.Model
{
    public class game_clip_uri
    {
        public string uri { get; set; }
		public long fileSize { get; set; }
		public string uriType { get; set; }
		public DateTime expiration { get; set; }
    }
}