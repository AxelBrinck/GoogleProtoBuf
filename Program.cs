using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FileArray
{
    class Program
    {
        private static readonly string FileName = "in.data";

        static byte[] structToBytes(object str)
        {
            byte[] arr = new byte[Marshal.SizeOf(str)];
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(str));
            Marshal.StructureToPtr(str, pnt, false);
            Marshal.Copy(pnt, arr, 0, Marshal.SizeOf(str));
            Marshal.FreeHGlobal(pnt);
            return arr;
        }

        static void Main(string[] args)
        {
            File.Delete(FileName);

            // Writing

            var totalBytesRead = 0L;
            var startTime = DateTime.Now;

            var stream = File.OpenWrite(FileName);
            var update = new PriceUpdate();
            update.Open = 1.4m;
            update.Close = 5.9m;
            update.High = 76439.385994m;
            update.Low = 69m;


            for (var i = 0; i < 10 * 1024 * 1024; i++)
            {
                var bytes = structToBytes(update);
                stream.Write(bytes, 0, bytes.Length);
                totalBytesRead += bytes.Length;
            }

            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;
            var megaBytes = totalBytesRead / 1024 / 1024;
            Console.WriteLine($"Speed: {megaBytes / elapsedTime.TotalSeconds:0.00}Mb/s.");

            stream.Flush();

            return;


            // Reading

            var streamArray = new StreamArray(new FileStream(FileName, FileMode.Open));

            startTime = DateTime.Now;

            totalBytesRead = 0L;
            var readBytes = 0L;
            
            do
            {
                readBytes = streamArray.Read();
                totalBytesRead += readBytes;
            }
            while (readBytes > 0);


            endTime = DateTime.Now;
            elapsedTime = endTime - startTime;
            megaBytes = totalBytesRead / 1024 / 1024;
            Console.WriteLine($"Speed: {megaBytes / elapsedTime.TotalSeconds:0.00}Mb/s.");
        }
    }
}