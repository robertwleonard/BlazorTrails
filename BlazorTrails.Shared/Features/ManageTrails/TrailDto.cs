﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTrails.Shared.Features.ManageTrails
{
    public class TrailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public int TimeInMinutes { get; set; }
        public int Length { get; set; }
        public List<RouteInstruction> Route { get; set; } = new List<RouteInstruction>();

        public class RouteInstruction
        {
            public int Stage { get; set; }
            public string Description { get; set; } = "";
        }
    }
}
