using System;
using ProtoBuf;

namespace StreamArray
{
    [ProtoContract]
    public record PriceUpdate
    {
        [ProtoMember(1)]
        public decimal Open { get; set; }
        [ProtoMember(2)]
        public decimal Close { get; set; }
        [ProtoMember(3)]
        public decimal High { get; set; }
        [ProtoMember(4)]
        public decimal Low { get; set; }
        
        [ProtoMember(5)]
        public DateTime OpenTime { get; set; }
        [ProtoMember(6)]
        public DateTime CloseTime { get; set; }

        [ProtoMember(7)]
        public int TradeCount { get; set; }
        
        [ProtoMember(8)]
        public decimal BaseVolume { get; set; }
        [ProtoMember(9)]
        public decimal QuoteVolume { get; set; }
        [ProtoMember(10)]
        public decimal TakerBuyBaseVolume { get; set; }
        [ProtoMember(11)]
        public decimal TakerBuyQuoteVolume { get; set; }
    }
}