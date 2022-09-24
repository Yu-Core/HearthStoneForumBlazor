using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTORest
{
    public class UserInfoDTOLogin
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [MaxLength(16, ErrorMessage = "账号长度必须在3到20之间")]
        [MinLength(4, ErrorMessage = "账号长度必须在3到20之间")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [MaxLength(16, ErrorMessage = "密码长度必须在5到20之间")]
        [MinLength(4, ErrorMessage = "密码长度必须在5到20之间")]
        public string? Password { get; set; }
    }
}
