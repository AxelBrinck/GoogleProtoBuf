using System;
using System.IO;

namespace FileArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamArray = new StreamArray(new FileStream("in.data", FileMode.Open));

            var startTime = DateTime.Now;

            var totalBytesRead = 0L;
            var readBytes = 0L;
            
            do
            {
                readBytes = streamArray.Read();
                totalBytesRead += readBytes;
            }
            while (readBytes > 0);


            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;

            var megaBytes = totalBytesRead / 1024 / 1024;

            Console.WriteLine($"Speed: {megaBytes / elapsedTime.TotalSeconds:0.00}Mb/s.");
        }
    }
}
