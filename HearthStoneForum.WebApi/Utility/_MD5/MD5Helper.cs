using System.Security.Cryptography;
using System.Text;

namespace HearthStoneForum.WebApi.Utility._MD5
{
    public class MD5Helper
    {
        public static string MD5Encrytp32(string password)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < s.Length; i++)
            {
                pwd += s[i].ToString("X");
            }
            return pwd;
        }
    }
}
