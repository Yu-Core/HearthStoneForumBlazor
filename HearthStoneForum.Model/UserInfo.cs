using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace HearthStoneForum.Model
{
    public class UserInfo:BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? UserName { get; set; }
        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string? Password { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Name { get; set; }
        public int HeadId { get; set; }
        public Sex Sex { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(255)")]
        public string? Email { get; set; }
        [SugarColumn(ColumnDataType = "varchar(32)")]
        public string? Phone { get; set; }
        public DateTime LastLogin{ get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public enum Sex
    {
        男,女
    }
}
