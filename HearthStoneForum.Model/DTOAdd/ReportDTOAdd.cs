using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOAdd
{
    public class ReportDTOAdd
    {
        public int InvitationId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
    }
}
