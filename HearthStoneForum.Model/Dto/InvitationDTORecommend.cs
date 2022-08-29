using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.Dto
{
    public class InvitationDTORecommend:BaseId
    {
        public string? Title { get; set; }
        public int LikesCount { get; set; }
        public int CommentCount { get; set; }
        public int CollectionCount { get; set; }
        public int Recommend { get; set; }
    }
}
