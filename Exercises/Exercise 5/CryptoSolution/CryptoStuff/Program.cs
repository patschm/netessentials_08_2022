using System.Security.Cryptography;
using System.Text;

namespace CryptoStuff;

internal class Program
{
    static void Main(string[] args)
    {
        #region Integrity
        //TestHash();
        //TestSymmetric();
        TestAsymmetric();
        #endregion
    }

    private static void TestAsymmetric()
    {
        string msg = "Hello World";
        // Sender
        var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(msg));
        DSA dsa = new DSACryptoServiceProvider();
        string publicKey = dsa.ToXmlString(false);
        byte[] digitalSignature =  dsa.SignData(hash, HashAlgorithmName.SHA1);


        // ED
        //msg += ".";

        // Receiver
        var sha2 = SHA1.Create();
        var hash2 = sha2.ComputeHash(Encoding.UTF8.GetBytes(msg));
        DSA dsa2 = new DSACryptoServiceProvider();
        dsa2.FromXmlString(publicKey);

        bool isOk = dsa2.VerifyData(hash2, digitalSignature, HashAlgorithmName.SHA1);
        Console.WriteLine(isOk);
    }

    private static void TestSymmetric()
    {
        string msg = "Hello World";
        // Senders
        var sha1 = new HMACSHA1();
        byte[] key = sha1.Key;
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(msg));
        Console.WriteLine(Convert.ToBase64String(hash));

        // Receiver
        var sha2 = new HMACSHA1();
        sha2.Key = key;
        var hash2 = sha2.ComputeHash(Encoding.UTF8.GetBytes(msg));
        Console.WriteLine(Convert.ToBase64String(hash2));
    }

    private static void TestHash()
    {
        string msg = "Hello World";
        // Senders
        var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(msg));
        Console.WriteLine(Convert.ToBase64String(hash));

        msg += ".";

        // Receiver
        sha1 = SHA1.Create();
        var hash2 = sha1.ComputeHash(Encoding.UTF8.GetBytes(msg));
        Console.WriteLine(Convert.ToBase64String(hash2));
    }
}