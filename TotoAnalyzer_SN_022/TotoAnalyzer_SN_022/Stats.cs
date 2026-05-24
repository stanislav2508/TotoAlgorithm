using TotoAnalyzer.Models;

namespace TotoAnalyzer
{
    public class Stats
    {
        private IEnumerable<Structure> draws;

        public Stats(IEnumerable<Structure> draws)
        {
            this.draws = draws;
        }

        // TOP N NUMBERS
        public Dictionary<int, int> GetTopNumbers(int n)
        {
            return draws
                .SelectMany(x => x.Numbers)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(n)
                .ToDictionary(
                    x => x.Key,
                    x => x.Count()
                );
        }

        // HOT PAIRS
        public List<(int, int, int)> GetHotPairs(int top)
        {
            Dictionary<(int, int), int> pairs =
                new Dictionary<(int, int), int>();

            foreach (var draw in draws)
            {
                List<int> nums =
                    draw.Numbers.OrderBy(x => x).ToList();

                for (int i = 0; i < nums.Count; i++)
                {
                    for (int j = i + 1; j < nums.Count; j++)
                    {
                        var pair = (nums[i], nums[j]);

                        if (pairs.ContainsKey(pair))
                        {
                            pairs[pair]++;
                        }
                        else
                        {
                            pairs[pair] = 1;
                        }
                    }
                }
            }

            return pairs
                .OrderByDescending(x => x.Value)
                .Take(top)
                .Select(x => (
                    x.Key.Item1,
                    x.Key.Item2,
                    x.Value
                ))
                .ToList();
        }

        // DISTRIBUTION
        public Dictionary<string, int> GetDistribution()
        {
            Dictionary<string, int> result =
                new Dictionary<string, int>()
                {
                    { "1-10", 0 },
                    { "11-20", 0 },
                    { "21-30", 0 },
                    { "31-40", 0 },
                    { "41-49", 0 }
                };

            List<int> allNumbers =
                draws.SelectMany(x => x.Numbers).ToList();

            foreach (int num in allNumbers)
            {
                if (num >= 1 && num <= 10)
                {
                    result["1-10"]++;
                }
                else if (num >= 11 && num <= 20)
                {
                    result["11-20"]++;
                }
                else if (num >= 21 && num <= 30)
                {
                    result["21-30"]++;
                }
                else if (num >= 31 && num <= 40)
                {
                    result["31-40"]++;
                }
                else if (num >= 41 && num <= 49)
                {
                    result["41-49"]++;
                }
            }

            return result;
        }

        // FILTER YEARS
        public IEnumerable<Structure> FilterByYears(
            int fromYear,
            int toYear)
        {
            return draws.Where(x =>
                x.Year >= fromYear &&
                x.Year <= toYear);
        }
    }
}