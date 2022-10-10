using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model
{
    public class Download : BaseId
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? UrlPath { get; set; }
    }
}
