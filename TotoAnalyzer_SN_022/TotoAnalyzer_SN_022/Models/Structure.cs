namespace TotoAnalyzer.Models
{
    public class Structure
    {
        public int Year { get; set; }

        public int DrawNumber { get; set; }

        public List<int> Numbers { get; set; } = new();
    }
}