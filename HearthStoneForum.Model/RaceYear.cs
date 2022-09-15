using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class RaceYear : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string? Name { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(16)")]
        public string? Year { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(16)")]
        public string? Mode { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(2083)")]
        public string? ImagePath { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToMany, nameof(Expansion.RaceYearId))]
        public List<Expansion>? Expansions { get; set; }
    }
}
