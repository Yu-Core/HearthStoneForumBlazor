using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.DTOEdit
{
    public class UserInfoDTOEdit : BaseId
    {
        public string? Name { get; set; }
        public string? Portrait { get; set; }
        public Sex Sex { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
