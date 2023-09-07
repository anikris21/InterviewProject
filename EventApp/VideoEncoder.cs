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
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        public event VideoEncodedEventHandler VideoEncoded;

        public event EventHandler<VideoEventArgs> VideoEncoded1;

        public void Encode(Video video) { 
            Console.WriteLine($"Encoding video {video.Title}");
            OnVideoEncoded(video);
        }

        // Video video=null
        protected void OnVideoEncoded(Video video = null) {
            if (VideoEncoded != null) {
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }

            if (VideoEncoded1 != null)
            {
                VideoEncoded1(this, new VideoEventArgs() { Video = video });
            }
        }
    }
}
