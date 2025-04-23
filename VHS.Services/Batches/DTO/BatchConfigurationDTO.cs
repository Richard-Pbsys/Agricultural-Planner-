using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.Produce.DTO;

namespace VHS.Services.Batches.DTO
{
    public class BatchConfigurationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid FarmId { get; set; }
        public RecipeDTO Recipe { get; set; } = new RecipeDTO();
        public int TotalTrays { get; set; } = 0;
        public int TraysPerDay { get; set; } = 0;
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}
