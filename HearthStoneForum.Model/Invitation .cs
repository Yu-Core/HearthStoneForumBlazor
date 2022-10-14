using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Invitation : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Title { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(MAX)")]
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        public int Views { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
