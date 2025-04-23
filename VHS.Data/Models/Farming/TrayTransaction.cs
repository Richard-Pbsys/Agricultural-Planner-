using System;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Batches;

namespace VHS.Data.Models.Farming
{
    public class TrayTransaction
    {
        public Guid Id { get; set; }

        public Guid TrayId { get; set; }
        public virtual Tray Tray { get; set; }

        public Guid FromPhaseId { get; set; }
        public Guid ToPhaseId { get; set; }

        public DateTime AddedDateTime { get; set; }

        public TrayTransaction()
        {
            AddedDateTime = DateTime.UtcNow;
        }
    }
}
