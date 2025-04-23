using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Farming;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Batches
{
    public class Batch
    {
        public Guid Id { get; set; }
        [Required]
        public string BatchId { get; set; } = string.Empty;

        [Required]
        public Guid FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        [Required]
        public Guid BatchConfigurationId { get; set; }
        public virtual BatchConfiguration BatchConfiguration { get; set; }

        [Required]
        public DateTime? SeedDate { get; set; }
        public DateTime? HarvestDate { get; set; }
        public Guid StatusId { get; set; } = Guid.Empty;

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Batch()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
