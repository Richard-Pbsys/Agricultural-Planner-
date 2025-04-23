using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VHS.Data.Models.Farming
{
    public class Layer
    {
        public Guid Id { get; set; }

        [Required]
        public Guid RackId { get; set; }
        public virtual Rack Rack { get; set; }

        [Required]
        public int LayerNumber { get; set; }        //0=top, 1=next, 2=next, etc.

        public DateTime AddedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public bool Enabled { get; set; } = true;

        public virtual ICollection<TrayCurrentState> Trays { get; set; } = new List<TrayCurrentState>();

        public Layer()
        {
            AddedDateTime = DateTime.UtcNow;
        }
    }
}
