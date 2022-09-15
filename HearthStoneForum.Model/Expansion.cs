using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Expansion : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Name { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Mode { get; set; }
        public int RaceYearId { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? ImagePath { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? LogoPath { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? Href { get; set; }
        public DateTime DateTime { get; set; }
    }
}
