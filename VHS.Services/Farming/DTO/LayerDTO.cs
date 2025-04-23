using VHS.Data.Models.Farming;
using VHS.Services.Batches.DTO;
using VHS.Services.Common;

namespace VHS.Services.Farming.DTO
{
    public class LayerDTO
    {
        public Guid Id { get; set; }
        public int LayerNumber { get; set; }
        public virtual List<TrayCurrentStateDTO> Trays { get; set; } = new List<TrayCurrentStateDTO>();
        public Guid RackId { get; set; }
        public int TrayCountPerLayer { get; set; }
        public bool IsTransportLayer { get; set; }

        public virtual BatchDTO Batch { get; set; }
        public Guid CurrentPhaseId { get; set; }
        public DateTime? SeededDateTimeUTC { get; set; }

        public bool Enabled { get; set; }

        public bool FinishedGrowing
        {
            get
            {
                return Trays.Any(x => x.IsFinishedGrowing);
            }
        }

        public bool HasRoom
        {
            get
            {
                if (IsTransportLayer || !Enabled)
                    return false;

                int occupiedCount = Trays.Count(t =>
                    t.CurrentPhaseId != GlobalConstants.TRAYPHASE_EMPTY &&
                    t.CurrentPhaseId != GlobalConstants.TRAYPHASE_FULLYGROWN
                );

                return occupiedCount < TrayCountPerLayer;
            }
        }

        public int AvailableSlots
        {
            get
            {
                return TrayCountPerLayer - Trays.Count(t =>
                    t.CurrentPhaseId != GlobalConstants.TRAYPHASE_EMPTY &&
                    t.CurrentPhaseId != GlobalConstants.TRAYPHASE_FULLYGROWN
                );
            }
        }

        public void ReorderTrays()
        {
            var lowest = Trays.Min(x => x.OrderOnLayer);
            int order = 1;
            foreach (var tray in Trays.OrderBy(x => x.OrderOnLayer))
            {
                tray.OrderOnLayer = order;
                order++;
            }
        }

    }
}
