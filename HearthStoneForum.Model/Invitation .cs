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
        [SugarColumn(ColumnDataType = "text")]
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(4000)",IsJson = true)]
        public string[]? ImagePaths { get; set; }
        public int Views { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
