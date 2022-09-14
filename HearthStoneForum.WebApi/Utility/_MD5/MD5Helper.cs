using System.Security.Cryptography;
using System.Text;

namespace HearthStoneForum.WebApi.Utility._MD5
{
    public class MD5Helper
    {
        public static string MD5Encrytp32(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] newBuffer = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
