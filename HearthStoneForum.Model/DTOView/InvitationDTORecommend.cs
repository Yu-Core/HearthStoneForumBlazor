using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOView
{
    public class InvitationDTOViewRecommend : BaseId
    {
        public string? Title { get; set; }
        public int LikesCount { get; set; }
        public int CommentCount { get; set; }
        public int CollectionCount { get; set; }
        public int Recommend { get; set; }
    }
}
