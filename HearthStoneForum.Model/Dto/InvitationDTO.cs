using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.Dto
{
    public class InvitationDTO : BaseId
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        public string? AreaName { get; set; }
        public string[]? ImagePaths { get; set; }
        public int Views { get; set; }
        public DateTime CreatedTime { get; set; }


        public List<Likes>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Collection>? Collections { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int CollectionCount { get; set; }
        public int Recommend { get; set; }
    }
}
