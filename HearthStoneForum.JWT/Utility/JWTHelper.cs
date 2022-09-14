using HearthStoneForum.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HearthStoneForum.JWT.Utility
{
    public static class JWTHelper
    {
        public static string CreateToken(UserInfo userInfo)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();
            // 1. 定义需要使用到的Claims
            var claims = new[]
            {
                new Claim("UserId", userInfo.Id.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName??"用户")
            };

            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;

            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);

            // 5. 从 appsettings.json 中读取Expires
            var expires = Convert.ToDouble(configuration["JWT:Expires"]);

            // 6. 根据以上，生成token
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],//颁布者
                audience: configuration["JWT:Audience"],//接收者
                claims: claims,//token存储的信息
                notBefore: DateTime.Now,//发布时间
                expires: DateTime.Now.AddHours(expires),//失效时间
                signingCredentials: signingCredentials//加密后的密钥
            );

            // 7. 将token变为string
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
