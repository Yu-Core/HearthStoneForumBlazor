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

    public class CommentDTOAddPlus : CommentDTOAdd, IMEditorModel
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
            set
            {
                ContentValidation = value;
            }
        }

    }
}
