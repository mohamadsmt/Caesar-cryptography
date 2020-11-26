using System;
using Caeser_Cipher;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Caesar newCaesar = new Caesar();
            Console.WriteLine("Enter your message: ");
            string plainText = Console.ReadLine();
            string cipherText = newCaesar.Encrypt(plainText);
            Console.WriteLine("Encrypted message is: " + cipherText);
            Console.WriteLine("pres Enter to Decrypt...");
            Console.ReadLine();
            Console.WriteLine("Decrypted message is: " + newCaesar.Decrypt(cipherText));
        }
    }

}
