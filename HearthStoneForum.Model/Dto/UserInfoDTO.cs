using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.Dto
{
    public class UserInfoDTO : BaseId
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public int HeadId { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public Sex Sex { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
