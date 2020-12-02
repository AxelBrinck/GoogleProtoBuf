namespace FileArray
{
    public interface ICustomSerializable
    {
        int SerialLength { get; }

        byte Serialize();

        void Deserialize(byte[] serial);
    }
}