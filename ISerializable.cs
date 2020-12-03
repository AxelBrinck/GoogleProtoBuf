namespace FileArray
{
    public interface ISerializable
    {
        int SerialLength { get; }

        byte Serialize();

        void Deserialize(byte[] serial);
    }
}