using System;
using System.Text;
using System.Security.Cryptography;

namespace Quartzified
{
    public class Cryptography
    {
        /// <summary>
        /// Hashes the Input with use of a salt
        /// </summary>
        /// <param name="input">Input to Encrypt</param>
        /// <param name="salt">Encryption Salt</param>
        /// <returns></returns>
        public static string PBKDF2Hash(string input, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
        /// <summary>
        /// Hashes the Input with use of a salt
        /// </summary>
        /// <param name="input">Input to Encrypt</param>
        /// <param name="salt">Encryption Salt</param>
        /// <returns></returns>
        public static string PBKDF2Hash(string input, int salt)
        {
            byte[] saltBytes = BitConverter.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
