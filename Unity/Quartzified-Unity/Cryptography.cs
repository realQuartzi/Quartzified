using System;
using System.Text;
using System.Security.Cryptography;

namespace Quartzified
{
    class Cryptography
    {
        public static string PBKDF2Hash(string input, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
        public static string PBKDF2Hash(string input, int salt)
        {
            byte[] saltBytes = BitConverter.GetBytes(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
