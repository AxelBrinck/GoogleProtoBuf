using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace ProtobufExample
{
    class Program
    {
        private static readonly string FileName = "data.bin";
        private static readonly int TotalUpdates = 3500 * 500;

        private static readonly Chronometer Chrono = new Chronometer();

        static void Main(string[] args)
        {
            File.Delete(FileName);
            
            // Serialize
            Chrono.Start();
            using(var stream = File.OpenWrite(FileName))
            {

                for (var packId = 0; packId < TotalUpdates; packId++)
                {
                    var update = new PriceUpdate();

                    update.Open = 13232324.43434344m;
                    update.Close = 32325.92121211m;
                    update.High = 76439.385994m;
                    update.Low = 69m;
                    update.CloseTime = DateTime.Now;
                    update.OpenTime = DateTime.Now;
                    update.BaseVolume = 23873924.8327398m;
                    update.QuoteVolume = 2329.329589594M;
                    update.TakerBuyBaseVolume = 2337328.43894493m;
                    update.TakerBuyQuoteVolume = 73283723.483934893m;
                    update.TradeCount = 7328;

                    Serializer.SerializeWithLengthPrefix<PriceUpdate>(stream, update, PrefixStyle.Base128, 1);
                }
                
            }
            Chrono.End();

            var totalBytes = new FileInfo(FileName).Length;
            var elapsedTime = Chrono.GetDuration();
            var megaBytes = (float) totalBytes / 1024 / 1024;
            Console.WriteLine($"Write Speed: {megaBytes / elapsedTime.TotalSeconds:0.000}Mb/s. Total: {totalBytes} bytes.");

            // Deserialize
            Chrono.Start();
            using(var stream = File.OpenRead(FileName))
            {
                PriceUpdate pack = null;

                do
                {
                    pack = (PriceUpdate) Serializer.DeserializeWithLengthPrefix<PriceUpdate>(stream, PrefixStyle.Base128, 1);
                }
                while (stream.Position < stream.Length);
            }
            Chrono.End();

            totalBytes = new FileInfo(FileName).Length;
            elapsedTime = Chrono.GetDuration();
            megaBytes = (float) totalBytes / 1024 / 1024;
            Console.WriteLine($"Read Speed: {megaBytes / elapsedTime.TotalSeconds:0.000}Mb/s. Total: {totalBytes} bytes.");
        }
    }
}