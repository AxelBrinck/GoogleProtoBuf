using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace FileArray
{
    class Program
    {
        private static readonly string FileName = "data.bin";
        private static readonly int TotalUpdatesInPack = 1;
        private static readonly int TotalPacks = 1;

        private static readonly Chronometer Chrono = new Chronometer();

        static void Main(string[] args)
        {
            File.Delete(FileName);
            
            // Serialize
            Chrono.Start();
            using(var stream = File.OpenWrite(FileName))
            {

                for (var packId = 0; packId < TotalPacks; packId++)
                {
                    var pack = new PricePack();
                    for (var i = 0; i < TotalUpdatesInPack; i++)
                    {
                        var update = new PriceUpdate();

                        update.Open = 13232324.43434344m;
                        update.Close = 32325.92121211m;
                        update.High = 76439.385994m;
                        update.Low = 69m;
                        update.CloseTime = DateTime.Now;
                        update.OpenTime = DateTime.Now;
                        update.BaseVolume = 23873924.8327398m;
                        update.QuoteVolume = 2329329.589594M;
                        update.TakerBuyBaseVolume = 2337328.43894493m;
                        update.TakerBuyQuoteVolume = 73283723.483934893m;
                        update.TradeCount = 7328;

                        pack.Updates.Add(update);
                    }

                    Serializer.Serialize<PricePack>(stream, pack);
                }
                
            }
            Chrono.End();

            var totalBytesWritten = new FileInfo(FileName).Length;
            var elapsedTime = Chrono.GetDuration();
            var megaBytes = (float) totalBytesWritten / 1024 / 1024;
            Console.WriteLine($"Speed: {megaBytes / elapsedTime.TotalSeconds:0.000}Mb/s. Bytes read: {totalBytesWritten} bytes.");

            // Deserialize
            using(var stream = File.OpenRead(FileName))
            {
                PricePack pack = null;

                do
                {
                    Console.Write("-");
                    pack = Serializer.Deserialize<PricePack>(stream);
                    Console.Write(".");
                }
                while (pack != null);
            }
        }
    }
}