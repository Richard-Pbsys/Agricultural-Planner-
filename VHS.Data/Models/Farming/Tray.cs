using System;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Batches;

namespace VHS.Data.Models.Farming
{
    public class Tray
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        [Required]
        [MaxLength(255)]
        public string RFIDTag { get; set; } = string.Empty;

        public Guid StatusId { get; set; } //in-use, broken, removed

        public DateTime AddedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Tray()
        {
            AddedDateTime = DateTime.UtcNow;
        }
    }
}
