using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Comment : Likes
    {
        [SugarColumn(ColumnDataType = "ntext")]
        public string? Content { get; set; }
    }
}
