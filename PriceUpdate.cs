using System.Runtime.InteropServices;

namespace FileArray
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PriceUpdate
    {
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
    }
}