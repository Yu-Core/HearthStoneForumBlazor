﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneForum.Model.Dto
{
    public class AreaDTO:BaseId
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
