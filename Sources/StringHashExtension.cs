using System.Text;
using System.Security.Cryptography;

namespace Darkit
{
    public static class StringHashExtension
    {
        public static string Hash<T>(this string text, T crypto) where T : HashAlgorithm
        {
            byte[] source = Encoding.UTF8.GetBytes(text);
            byte[] target = crypto.ComputeHash(source);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < target.Length; ++i)
            {
                builder.Append(target[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string ToSHA256(this string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return text.Hash(sha256);
            }
        }

        public static string ToMD5(this string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                return text.Hash(md5);
            }
        }
    }
}
