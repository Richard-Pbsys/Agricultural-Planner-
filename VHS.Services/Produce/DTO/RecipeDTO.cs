﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Services.Produce.DTO
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ProductDTO Product { get; set; } = new ProductDTO();

        public int GerminationDays { get; set; }
        public int PropagationDays { get; set; }
        public int GrowDays { get; set; }
        
        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
