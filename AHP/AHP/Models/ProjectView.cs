﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHP.Models
{
    public class ProjectView
    {
        public Guid ProjectId { get; set; }
        public string Username { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

    }
}