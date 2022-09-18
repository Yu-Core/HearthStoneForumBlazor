using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOView
{
    public class CommentDTOView:BaseId
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int InvitationId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? Content { get; set; }
    }
}
