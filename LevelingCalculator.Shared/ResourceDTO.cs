﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelingCalculator.Shared
{
    public class ResourceDTO
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public int Craftable { get; set; } = 0;
        public int Own { get; set; } = 0;
    }
}
