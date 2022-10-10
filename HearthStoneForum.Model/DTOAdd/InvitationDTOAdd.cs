using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOAdd
{
    public class InvitationDTOAdd
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "标题不能为空")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "内容不能为空")]
        public string? Content { get; set; }
        public int AreaId { get; set; }
    }

    public class InvitationDTOAddPlus : InvitationDTOAdd
    {
        [Required(ErrorMessage = "内容不能为空")]
        public string ContentValidation
        {
            get
            {
                if (string.IsNullOrEmpty(Content))
                {
                    return string.Empty;
                }
                return Content.Replace("<p><br></p>", string.Empty);
            }
        }
    }
}
