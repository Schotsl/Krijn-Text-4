using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SharpUpdate
{
    /// The type of hash to create
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA512
    }

    /// Class used to generate hash sums of files
    internal static class Hasher
    {
        /// Generate a hash sum of a file
        internal static string HashFile(string filePath, HashType algo)
        {
            switch (algo)
            {
                case HashType.MD5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                default:
                    return "";
            }
        }

        /// Converts byte[] to string
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
    }
}