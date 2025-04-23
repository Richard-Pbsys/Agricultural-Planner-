using VHS.Services.Common;
using VHS.Services.Farming.Constants;

namespace VHS.Services.Farming.DTO
{
    public class RackDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }
        public int LayerCount { get; set; }
        public int TrayCountPerLayer { get; set; }
        public FloorDTO Floor { get; set; }
        public List<LayerDTO> Layers { get; set; } = new List<LayerDTO>();

        public bool Enabled { get; set; }

        public string ProductType { get; set; }
        public int OccupiedLayers => Layers.Count(layer => layer.HasRoom == false);
        public int TrayDepth { get; set; }

        public RackDTO(Guid id, int layerCount)
        {
            this.Id = id;
            this.LayerCount = layerCount;

            for (int i = 1; i <= this.LayerCount; i++)
            {
                this.Layers.Add(new LayerDTO() { Id = Guid.NewGuid(), RackId=this.Id, TrayCountPerLayer = this.TrayCountPerLayer, LayerNumber = i, Trays = new List<TrayCurrentStateDTO>(), Enabled = true });
            }
        }

        public bool HasRoom
        {
            get
            {
                return Layers.Any(x => x.HasRoom);
            }
        }

        public void AddOccupiedDays(DateTime currentDateTime)
        {
            foreach (var layer in Layers)
            {
                foreach (var tray in layer.Trays)
                {
                    tray.AddOccupiedDay(currentDateTime);
                }
            }
        }

        public string TypeName
        {
            get
            {
                if (TypeId == GlobalConstants.RACKTYPE_GROWING)
                    return "Growing";
                else if (TypeId == GlobalConstants.RACKTYPE_GERMINATION)
                    return "Germination";
                else if (TypeId == GlobalConstants.RACKTYPE_PROPAGATION)
                    return "Propagation";
                else
                    return string.Empty;
            }
        }

        public int AmountOfRacks
        {
            get
            {
                switch (Name)
                {
                    case RackConstant.SK1aName:
                        return RackConstant.SK1aCount;
                    case RackConstant.SK2aName:
                        return RackConstant.SK2aCount;
                    case RackConstant.SK2bName:
                        return RackConstant.SK2bCount;
                    case RackConstant.SK2cName:
                        return RackConstant.SK2cCount;
                    case RackConstant.SK2dName:
                        return RackConstant.SK2dCount;
                    case RackConstant.SK3aName:
                        return RackConstant.SK3aCount;
                    case RackConstant.SK3bName:
                        return RackConstant.SK3bCount;
                    case RackConstant.SK3cName:
                        return RackConstant.SK3cCount;
                    default:
                        return 0;
                }
            }
        }

        public string[] Crops
        {
            get
            {
                switch (Name)
                {
                    case RackConstant.SK1aName:
                        return RackConstant.SK1aCrops;
                    case RackConstant.SK2aName:
                        return RackConstant.SK2aCrops;
                    case RackConstant.SK2bName:
                        return RackConstant.SK2bCrops;
                    case RackConstant.SK2cName:
                        return RackConstant.SK2cCrops;
                    case RackConstant.SK2dName:
                        return RackConstant.SK2dCrops;
                    case RackConstant.SK3aName:
                        return RackConstant.SK3aCrops;
                    case RackConstant.SK3bName:
                        return RackConstant.SK3bCrops;
                    case RackConstant.SK3cName:
                        return RackConstant.SK3cCrops;
                    default:
                        return Array.Empty<string>();
                }
            }
        }
    }
}
