using System.Collections.Generic;
using ProtoBuf;

namespace FileArray
{
    [ProtoContract]
    public class PricePack
    {   
        [ProtoMember(1)]
        public List<PriceUpdate> Updates { get; set; } = new List<PriceUpdate>();
    }
}