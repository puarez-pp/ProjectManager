using System.Security.Cryptography;

namespace ProjectManager.Infrastructure.Encryption;

public class KeyInfo
{
    public byte[] Key { get; }
    public byte[] Iv { get; }

    public string KeyString => Convert.ToBase64String(Key);
    public string IVString => Convert.ToBase64String(Iv);

    public KeyInfo()
    {
        using (Aes myAes = Aes.Create())
        {
            Key = myAes.Key;
            Iv = myAes.IV;
        }
    }

    public KeyInfo(string key, string iv)
    {
        Key = Convert.FromBase64String(key);
        Iv = Convert.FromBase64String(iv);
    }
}
