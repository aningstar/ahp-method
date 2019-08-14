﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models.Dto
{
    public class AlternativeRankDto
    {
        public int Alternative1 { get; set; }
        public int Alternative2 { get; set; }
        public float Preference { get; set; }
        public Guid CriteriaId { get; set; }
    }
}