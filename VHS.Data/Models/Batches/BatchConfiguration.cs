using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Farming;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Batches
{
    public class BatchConfiguration
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Guid FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        [Required]
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Required]
        public int TotalTrays { get; set; } = 0;

        [Required]
        public int TraysPerDay { get; set; } = 0;

        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public BatchConfiguration()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
