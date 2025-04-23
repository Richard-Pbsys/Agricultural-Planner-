using System;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Batches;

namespace VHS.Data.Models.Farming
{
    //current state of the tray
    public class TrayCurrentState
    {
        [Key]
        public Guid TrayId { get; set; }
        public virtual Tray Tray { get; set; }
                
        public Guid? DestinationLayerId { get; set; }
        public virtual Layer DestinationLayer { get; set; }

        public int OrderOnLayer { get; set; } = 0;

        public Guid? BatchId { get; set; }
        public virtual Batch Batch { get; set; }

        public Guid CurrentPhaseId { get; set; }

        public DateTime? SeededDateTimeUTC { get; set; }

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public TrayCurrentState()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
