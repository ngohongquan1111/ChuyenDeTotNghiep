using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace SimpleEcommerceWebsite.Service.Resource
{
    public class ConfigurationInfomation
    {
        public static string ConnectionString() => ConfigurationManager.ConnectionStrings["SimpleEcomereceConnectionString"].ConnectionString;
    }

    public static class StaticFunctionalHelper
    {
        public static string EncriptString<T>(this T obj)
        {
            if (obj == null || obj.GetType() != typeof(string))
            {
                return null;
            }

            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(obj.ToString()));
            StringBuilder s = new StringBuilder();
            foreach (byte _hashedByte in hashedBytes)
            {
                s.Append(_hashedByte.ToString("x2"));
            }
            return s.ToString();
        }
    }
}