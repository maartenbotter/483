using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            // Get the public keyy   
            var publicKey = rsa.ExportRSAPublicKey();
            var privateKey = rsa.ExportRSAPrivateKey();
            string input = string.Empty;
            while (string.IsNullOrWhiteSpace(input))
                input = Console.ReadLine();
            EncryptText(publicKey, input, "AESencrypted.dat");
            Console.WriteLine(PrintEncryptedData("AESencrypted.dat"));
            Console.WriteLine(DecryptData(privateKey, "AESencrypted.dat"));
        }

        static void EncryptText(byte[] publicKey, string text, string fileName)
        {
            byte[] dataToEncrypt = new UnicodeEncoding().GetBytes(text);
            byte[] encryptedData;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPublicKey(publicKey, out int bytesRead);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            File.WriteAllBytes(fileName, encryptedData);
            Console.WriteLine("Data encrypted");
        }

        static string DecryptData(byte[] privateKey, string fileName)
        {
            byte[] dataToDecrypt = File.ReadAllBytes(fileName);
            byte[] decryptedData;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPrivateKey(privateKey, out int bytesRead);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            return new UnicodeEncoding().GetString(decryptedData);
        }

        static string PrintEncryptedData(string fileName)
        {
            byte[] encrypted = File.ReadAllBytes(fileName);
            using MemoryStream ms = new MemoryStream(encrypted);
            using StreamReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }
    }
}
