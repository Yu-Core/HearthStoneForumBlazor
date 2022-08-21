using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Sign : BaseId
    {
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
