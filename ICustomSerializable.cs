namespace FileArray
{
    public interface ICustomSerializable
    {
        byte Serialize();

        void Deserialize(byte[] serial);
    }
}