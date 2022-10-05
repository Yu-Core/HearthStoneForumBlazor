using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOAdd
{
    public class CommentDTOAdd
    {
        public int InvitationId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "内容不能为空")]
        public string? Content { get; set; }
    }
}
