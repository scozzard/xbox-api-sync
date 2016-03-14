using System;

namespace Scozzard.XboxApiClient.Model
{
    public class screenshot_uri
    {
        public string uri { get; set; }
		public long fileSize { get; set; }
		public string uriType { get; set; }
		public DateTime expiration { get; set; }
    }
}