using VHS.Services.Common;

namespace VHS.Services.Farming.DTO
{
    public class TrayDTO
    {
        public Guid Id { get; set; }
        public Guid FarmId { get; set; }
        public string RFIDTag { get; set; } = string.Empty;
        public Guid StatusId { get; set; }
        public virtual TrayCurrentStateDTO TrayCurrentState { get; set; }
        public Guid CurrentPhaseId { get; set; } = GlobalConstants.TRAYPHASE_EMPTY;

        public string Status
        {
            get
            {
                switch (CurrentPhaseId)
                {
                    case var id when id == GlobalConstants.TRAYPHASE_EMPTY:
                        return "Empty";
                    case var id when id == GlobalConstants.TRAYPHASE_SEEDED:
                        return "Seeded";
                    case var id when id == GlobalConstants.TRAYPHASE_GERMINATING:
                        return "Germinating";
                    case var id when id == GlobalConstants.TRAYPHASE_PROPAGATING:
                        return "Propagating";
                    case var id when id == GlobalConstants.TRAYPHASE_REPLANTED:
                        return "Replanted";
                    case var id when id == GlobalConstants.TRAYPHASE_GROWING:
                        return "Growing";
                    case var id when id == GlobalConstants.TRAYPHASE_FULLYGROWN:
                        return "Fully Grown";
                    case var id when id == GlobalConstants.TRAYPHASE_TOHARVESTING:
                        return "To Harvesting";
                    case var id when id == GlobalConstants.TRAYPHASE_HARVESTED:
                        return "Harvested";
                    case var id when id == GlobalConstants.TRAYPHASE_TOWASHING:
                        return "To Washing";
                    case var id when id == GlobalConstants.TRAYPHASE_WASHED:
                        return "Washed";
                    case var id when id == GlobalConstants.TRAYPHASE_INFEEDER:
                        return "In Feeder";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
