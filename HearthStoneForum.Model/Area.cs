using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Area:BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Name { get; set; }
        [SugarColumn(ColumnDataType = "text")]
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? ImagePath { get; set; }
    }
}
