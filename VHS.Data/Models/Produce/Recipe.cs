using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Batches;

namespace VHS.Data.Models.Produce
{
    public class Recipe
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int GerminationDays { get; set; }
        [Required]
        public int PropagationDays { get; set; }
        [Required]
        public int GrowDays { get; set; }

        public virtual ICollection<RecipeLightSchedule> RecipeLightSchedules { get; set; } = new List<RecipeLightSchedule>();
        public virtual ICollection<RecipeWaterSchedule> RecipeWaterSchedules { get; set; } = new List<RecipeWaterSchedule>();
        public virtual ICollection<BatchConfiguration> BatchConfigurations { get; set; } = new List<BatchConfiguration>();

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Recipe()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
