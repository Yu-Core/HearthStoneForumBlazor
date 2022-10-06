using HearthStoneForum.Client.Utility;
using HearthStoneForum.Model;

namespace HearthStoneForum.Client.Shared
{
    
    public class DeleteState
    {
        public bool Success { get; set; }
        public int Id { get; set; }
    }

    public class GetInvitationsState
    {
        public bool Success { get; set; }
        public ApiResult<List<Invitation>>? Data { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
