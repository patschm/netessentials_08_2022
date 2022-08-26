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
        //TestAsymmetric();
        #endregion
        #region Confidentiality
        //TestAsymmetricConfid();
        TestSymmetricConfid();
        #endregion
    }

    private static void TestSymmetricConfid()
    {
        string mgs = "Hello World";
        // Sender
        SymmetricAlgorithm alg = Rijndael.Create();
        //alg.Mode = CipherMode.ECB;
        byte[] key = alg.Key;
        byte[] iv = alg.IV;

        byte[] cipher;
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream crypt = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter writer = new StreamWriter(crypt))
                writer.WriteLine(mgs);
            cipher = ms.ToArray();
            
        }
        Console.WriteLine(Convert.ToBase64String(cipher));

        // Receiver
        SymmetricAlgorithm alg2 = Rijndael.Create();
        //alg2.Mode = CipherMode.ECB; 
        alg2.Key = key; 
       alg2.IV = iv;
        using (MemoryStream ms = new MemoryStream(cipher))
        using (CryptoStream crypt = new CryptoStream(ms, alg2.CreateDecryptor(), CryptoStreamMode.Read))
        using (StreamReader reader = new StreamReader(crypt))
        {
            string txt = reader.ReadToEnd();
            Console.WriteLine(txt);
        }   
            

    }

    private static void TestAsymmetricConfid()
    {
       // Receipient generates public and private key and
       // sends the public key to the sender.
        RSA rsaReceipient = new RSACryptoServiceProvider();
        string publicKey = rsaReceipient.ToXmlString(false);
        Console.WriteLine(publicKey);

        // Sender
        string mgs = "Hello World";
        RSA rsaSender= new RSACryptoServiceProvider();
        rsaSender.FromXmlString(publicKey);
        byte[] cipher = rsaSender.Encrypt(Encoding.UTF8.GetBytes(mgs), RSAEncryptionPadding.Pkcs1);
        Console.WriteLine(Convert.ToBase64String(cipher));
    
        // Receiver
        byte[] result = rsaReceipient.Decrypt(cipher, RSAEncryptionPadding.Pkcs1);
        Console.WriteLine(Encoding.UTF8.GetString(result));
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