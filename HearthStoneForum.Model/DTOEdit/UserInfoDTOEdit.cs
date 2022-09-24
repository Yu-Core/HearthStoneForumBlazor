using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOEdit
{
    public class UserInfoDTOEdit : BaseId
    {
        [Required(ErrorMessage = "名字不能为空")]
        [MaxLength(16, ErrorMessage = "名字长度必须在3到20之间")]
        [MinLength(4, ErrorMessage = "名字长度必须在3到20之间")]
        public string? Name { get; set; }
        public string? Portrait { get; set; }
        public Sex Sex { get; set; }
        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress(ErrorMessage = "邮箱地址无效")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "手机号码不能为空")]
        [Phone(ErrorMessage = "手机号码无效")]
        public string? Phone { get; set; }
    }
}
