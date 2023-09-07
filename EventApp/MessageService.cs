using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
     class MessageService
    {
        public MessageService() { }

        public void OnVideoEncoded(object source, VideoEventArgs e) {
            Console.WriteLine("video encoded - sending message");
            Console.WriteLine($"video - {e.Video.Title}");
        }
    }
}
