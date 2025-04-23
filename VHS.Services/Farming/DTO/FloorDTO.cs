namespace VHS.Services.Farming.DTO
{
    public class FloorDTO
    {
        public Guid Id { get; set; }
        public Guid FarmId{ get; set; }
        public string Name { get; set; } = string.Empty;
        public int FloorNumber { get; set; }
        public List<RackDTO> Racks { get; set; } = new List<RackDTO>();

        public bool Enabled { get; set; }

    }
}
