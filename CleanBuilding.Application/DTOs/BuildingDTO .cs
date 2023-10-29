﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Application.DTOs
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Location { get; set; }

    }
}
