using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Farming
{
    public class Rack
    {
        public Guid Id { get; set; }

        [Required]
        public Guid FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Guid TypeId { get; set; }        //grow/germination/progagation

        [Required]
        public int LayerCount { get; set; }

        [Required]
        public int TrayCountPerLayer { get; set; }

        public virtual ICollection<Layer> Layers{ get; set; } = new List<Layer>();

        public bool Enabled { get; set; } = true;

        public DateTime AddedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public Rack()
        {
            AddedDateTime = DateTime.UtcNow;
        }
    }
   

}
