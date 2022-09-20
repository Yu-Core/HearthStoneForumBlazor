using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Portrait : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? UrlPath { get; set; }
    }
}
