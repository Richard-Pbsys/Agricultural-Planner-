using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Common;
using VHS.Services.Farming.DTO;

namespace VHS.Services.Batches.DTO
{
    public class BatchDTO
    {
        public Guid Id { get; set; }
        public string BatchId { get; set; } = string.Empty;
        public Guid FarmId { get; set; }

        public BatchConfigurationDTO BatchConfiguration { get; set; } = new BatchConfigurationDTO();

        public DateTime? SeedDate { get; set; }
        public DateTime? HarvestDate { get; set; }
        public Guid StatusId { get; set; } = GlobalConstants.BATCHSTATUS_PENDING;
        public string ProduceType { get; set; } = string.Empty;
        public List<TrayCurrentStateDTO> Trays { get; set; } = new List<TrayCurrentStateDTO>();
    }
}
