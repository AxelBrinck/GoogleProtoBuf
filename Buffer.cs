namespace FileArray
{
    class Buffer
    {
        private readonly byte[] _buffer;

        public Buffer(int size)
        {
            _buffer = new byte[size];
        }
    }
}