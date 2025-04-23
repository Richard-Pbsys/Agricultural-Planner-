using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Farming;

namespace VHS.Data.Models.Produce
{
    public class Product
    {
        public Guid Id { get; set; }

        public Guid FarmId { get; set; }
        public virtual Farm Farm { get; set; }


        [Required]
        public Guid ProductCategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageData { get; set; }
        [Required]
        public int SeedNumber { get; set; }
        public string SeedSupplier { get; set; }

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Product()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
