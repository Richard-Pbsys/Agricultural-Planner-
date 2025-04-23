using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Farming;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Batches
{
    public class BatchJournal
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BatchId { get; set; }

        // Seed data
        [Required]
        public string SeedSupplier { get; set; } = string.Empty;
        [Required]
        public string SeedLotNumber { get; set; } = string.Empty;

        // Peat data
        public string? PeatSupplier { get; set; }
        public string? PeatPrescription { get; set; }
        public string? PeatLotNumber { get; set; }

        // Remarks data
        public string RemarksGermination { get; set; } = string.Empty;
        public string RemarksYoungPlants { get; set; } = string.Empty;
        public string RemarksIntermediatePlants { get; set; } = string.Empty;
        public string RemarksHarvestPlants { get; set; } = string.Empty;

        // Prognosis data
        [Range(0, 100)]
        public double PrognosisGermination { get; set; } // Germination percentage prognosis (0-100%). A high percentage indicates a better planned yield.
        public int PrognosisDays { get; set; } // The number of days after sowing when the prognosis was recorded (e.g. 7 or 14 days).
        public double PrognosisHeight { get; set; } // // Prognosed plant height (in centimeters) at the prognosis time.
        public double PrognosisWeight { get; set; } // Prognosed plant weight (in grams) at the prognosis time.
        public double PrognosisRootLength { get; set; } // Prognosed root length (in centimeters) at the prognosis time.
        public double PrognosisRootNeckDiameter { get; set; } // Prognosed root neck diameter (in millimeters) at the prognosis time.

        // Yield data for Lettuce Heads
        public int YieldLettuceCount { get; set; } // Count of lettuce heads produced.
        public double YieldLettuceWeight { get; set; } // Total weight of lettuce heads (in grams).
        public double YieldLettuceHeight { get; set; } // Harvest height for lettuce heads (in centimeters).

        // Yield data for Petite Greens
        public int YieldPetiteCount { get; set; } // Count of petite plants produced.
        public double YieldPetiteWeight { get; set; } // Total weight of petite produce (in grams).
        public double YieldPetiteHeight { get; set; } // Harvest height for petite produce (in centimeters).

        // Yield data for Micro Greens
        public int YieldMicroCount { get; set; } // Count of microgreens units produced.
        public double YieldMicroWeight { get; set; } // Total weight of microgreens (in grams).
        public double YieldMicroHeight { get; set; } // Harvest height for microgreens (in centimeters).

        // A descriptive field for comparing yield to previous batches (e.g., '5% below last year yield'). 
        public string YieldComparison { get; set; } = string.Empty;

        // Miscellaneous comments (e.g., from the warehouse, complaints, or other observations).
        public string MiscellaneousComments { get; set; } = string.Empty;

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public BatchJournal()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
