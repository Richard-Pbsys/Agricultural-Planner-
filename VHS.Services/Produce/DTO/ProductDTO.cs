﻿using VHS.Services.Common;

namespace VHS.Services.Produce.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid FarmId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageData { get; set; }
        public int SeedNumber { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public string ProductCategoryName
        {
            get
            {
                if (ProductCategoryId == GlobalConstants.PRODUCTCATEGORY_LETTUCE)
                    return "Lettuce Heads";
                else if (ProductCategoryId == GlobalConstants.PRODUCTCATEGORY_PETITEGREENS)
                    return "Petite Greens";
                else if (ProductCategoryId == GlobalConstants.PRODUCTCATEGORY_MICROGREENS)
                    return "Micro Greens";
                else
                    return string.Empty;
            }
        }
    }
}
