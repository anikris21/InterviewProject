using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
     class VideoEncoder
    {
        public VideoEncoder() { }
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video) { 
            Console.WriteLine($"Encoding video {video.Title}");
            OnVideoEncoded();
        }

        protected void OnVideoEncoded() {
            if (VideoEncoded != null) {
                VideoEncoded(this, EventArgs.Empty);
            }
        }
    }
}
