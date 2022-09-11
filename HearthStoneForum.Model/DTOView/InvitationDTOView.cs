using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOView
{
    public class InvitationDTOView : BaseId
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int AreaId { get; set; }
        public string? AreaName { get; set; }
        public string[]? ImagePaths { get; set; }
        public int Views { get; set; }
        public DateTime CreatedTime { get; set; }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int CollectionCount { get; set; }
    }
}
