namespace Mayordomo.Transversal.Common.Interfaces
{
    public interface IEncryptService
    {
        string Encrypt(Guid rawData);
        Guid Decrypt(string cipherText);
    }
}
