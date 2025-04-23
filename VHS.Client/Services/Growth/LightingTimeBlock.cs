using MudBlazor;

namespace VHS.Client.Services.Growth
{
    public class LightingTimeBlock
    {
        public Guid Id { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public decimal? Intensity { get; set; } = 50;
        public double? CalculatedDLI { get; set; }

        public List<ChartSeries> ChartSeries { get; set; } = new();
        public List<string> ChartXAxisLabels { get; set; } = new();
    }
}
