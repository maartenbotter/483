using System;
using System.IO;
using System.Security.Cryptography;

namespace SymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricAlgorithm aes = new AesManaged();
            string input = string.Empty;
            while (string.IsNullOrWhiteSpace(input))
                input = Console.ReadLine();
            EncryptText(aes, input, "AESencrypted.dat");
            Console.WriteLine(PrintEncryptedData("AESencrypted.dat"));
            Console.WriteLine(DecryptData(aes, "AESencrypted.dat"));
        }

        static void EncryptText(SymmetricAlgorithm aesAlgorithm, string text, string fileName)
        {
            byte[] encrypted;
            ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (StreamWriter sw = new StreamWriter(cs))
                sw.Write(text);
            encrypted = ms.ToArray();

            File.WriteAllBytes(fileName, encrypted);
            Console.WriteLine("Data encrypted");
        }

        static string DecryptData(SymmetricAlgorithm aesAlgorithm, string fileName)
        {
            ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);
            byte[] encrypted = File.ReadAllBytes(fileName);
            using MemoryStream ms = new MemoryStream(encrypted);
            using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
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
