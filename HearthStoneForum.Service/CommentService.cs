using HearthStoneForum.IRepository;
using HearthStoneForum.IService;
using HearthStoneForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Service
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _iCommentRepository;
        public CommentService(ICommentRepository iCommentRepository)
        {
            base._iBaseRepository = iCommentRepository;
            _iCommentRepository = iCommentRepository;
        }
    }
}
