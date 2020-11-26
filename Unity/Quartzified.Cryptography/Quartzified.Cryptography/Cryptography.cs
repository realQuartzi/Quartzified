using System;
using System.Text;
using System.Security.Cryptography;

namespace Quartzified.Cryptography
{
    public class Cryptography
    {
        public class Base64
        {
            public static string Encode(string input)
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                string output = Convert.ToBase64String(inputBytes);

                return output;
            }

            public static string Decode(string input)
            {
                byte[] inputBytes = Convert.FromBase64String(input);
                string output = Encoding.UTF8.GetString(inputBytes);

                return output;
            }
        }

        public class PBKDF2
        {
            /// <summary>
            /// Hashes the Input with use of a salt
            /// </summary>
            /// <param name="input">Input to Encrypt</param>
            /// <param name="salt">Encryption Salt</param>
            /// <returns></returns>
            public static string Hash(string input, string salt)
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
            public static string Hash(string input, int salt)
            {
                byte[] saltBytes = BitConverter.GetBytes(salt);
                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, saltBytes, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }

        public class Sha256
        {
            public static string Hash(string input)
            {
                SHA256 sha256 = SHA256.Create();

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }

    }
}
