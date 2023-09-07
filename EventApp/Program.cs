namespace EventApp {

    class Program {
        public static void Main() {
            Console.WriteLine("hello world!");

            MailService mailService = new MailService();
            VideoEncoder videoEncoder = new VideoEncoder();
            Video video = new Video("Titan");


            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video); 

        }
    }

}