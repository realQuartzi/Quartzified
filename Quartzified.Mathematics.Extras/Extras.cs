using System;

namespace Quartzified.Mathematics.Extras
{
    public class Extras
    {
        /// <summary>
        /// Make things look nice
        /// </summary>
        public class Pretty
        {
            public static string Seconds(float seconds)
            {
                TimeSpan t = TimeSpan.FromSeconds(seconds);
                string res = "";
                if (t.Days > 0) res += t.Days + "d";
                if (t.Hours > 0) res += " " + t.Hours + "h";
                if (t.Minutes > 0) res += " " + t.Minutes + "m";

                if (t.Milliseconds > 0) res += " " + t.Seconds + "." + (t.Milliseconds / 100) + "s";
                else if (t.Seconds > 0) res += " " + t.Seconds + "s";

                return res != "" ? res : "0s";
            }

            public static string Time(float seconds)
            {
                TimeSpan t = TimeSpan.FromSeconds(seconds);
                string res = "";

                res += t.Hours > 0 ? ":" + t.Hours.ToString("00") : "00";
                res += t.Minutes > 0 ? ":" + t.Minutes.ToString("00") : "00";
                res += t.Seconds > 0 ? ":" + t.Seconds.ToString("00") : "00";

                return res;
            }
        }

        public class Endian
        {
            /// <summary>
            /// Converts a Integer into an array of bytes
            /// </summary>
            /// <param name="x">Integer to Convert</param>
            /// <returns></returns>
            public static byte[] IntToBytes(int x)
            {
                return new byte[]
                {
                    (byte) (x >> 24),
                    (byte) (x >> 16),
                    (byte) (x >> 8),
                    (byte) x
                };
            }
            /// <summary>
            /// Converts a Interger into an already existing array of bytes. \n 
            /// <para>Does not allocate a new set of bytes</para>
            /// </summary>
            /// <param name="x">Integer to Convert</param>
            /// <param name="bytes">Byte Array to Fill</param>
            public static void IntToBytes(int x, byte[] bytes)
            {
                bytes[0] = (byte)(x >> 24);
                bytes[1] = (byte)(x >> 16);
                bytes[2] = (byte)(x >> 8);
                bytes[3] = (byte)x;
            }

            /// <summary>
            /// Converts Bytes back into an Integer
            /// </summary>
            /// <param name="bytes">Byte Array to Convert</param>
            /// <returns></returns>
            public static int BytesToInt(byte[] bytes)
            {
                return (bytes[0] << 24) | (bytes[1] << 16) | bytes[2] << 8 | bytes[3];
            }

        }


    }
}
