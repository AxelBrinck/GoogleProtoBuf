using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace  FileArray
{
    public class StreamArray<T> : IEnumerable<T>
    {
        private readonly Stream _stream;

        public StreamArray(Stream stream)
        {
            _stream = stream;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StreamArrayEnumerator<T>(_stream);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StreamArrayEnumerator<T> : IEnumerator<T>
    {
        private static readonly int BufferSize = 1024 * 1024;
        private readonly Stream _stream;
        private byte[] _buffer = new byte[BufferSize];

        public long CurrentPosition { get; private set; } = -1;

        public T Current { get; private set; } = default(T);

        public StreamArrayEnumerator(Stream stream)
        {
            _stream = stream;
            stream.Read(_buffer, 0, BufferSize);
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            _stream.Flush();
            _stream.Close();
            _stream.Dispose();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}