using MudBlazor;

namespace VHS.Client.Services.Growth
{
    public class WateringTimeBlock
    {
        public Guid Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public decimal? Volume { get; set; } = 50;
        public double? CalculatedDWR { get; set; }

        public List<ChartSeries> ChartSeries { get; set; } = new();
        public List<string> ChartXAxisLabels { get; set; } = new();
    }
}
