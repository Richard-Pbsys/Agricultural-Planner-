using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Farming
{
    public partial class Farm
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public Guid FarmTypeId { get; set; }
        public virtual FarmType FarmType { get; set; }

        public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();

        public DateTime AddedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Farm()
        {
            AddedDateTime = DateTime.UtcNow;
        }
    }
}
