using System.Text.RegularExpressions;
using TotoAnalyzer.Models;

namespace TotoAnalyzer.Helper
{
    public class StructureParser
    {
        public IEnumerable<Structure> Parse(
            string text)
        {
            List<Structure> draws =
                new List<Structure>();

            text =
                text.Replace(
                    "Тираж",
                    "\nТираж");

            string[] lines =
                text.Split(
                    new[] { '\n', '\r' },
                    StringSplitOptions
                    .RemoveEmptyEntries);

            foreach (string line in lines)
            {
                try
                {
                    MatchCollection matches =
                        Regex.Matches(
                            line,
                            @"\d+");

                    List<int> nums =
                        new List<int>();

                    foreach (Match match in matches)
                    {
                        nums.Add(
                            int.Parse(
                                match.Value));
                    }

                    // OLD TXT FORMAT
                    // draw + 6 nums
                    if (nums.Count == 7)
                    {
                        Structure draw =
                            new Structure();

                        draw.DrawNumber =
                            nums[0];

                        draw.Year = 0;

                        draw.Numbers =
                            new List<int>()
                        {
                            nums[1],
                            nums[2],
                            nums[3],
                            nums[4],
                            nums[5],
                            nums[6]
                        };

                        draws.Add(draw);
                    }

                    // NEW FORMAT
                    // draw + year + 6 nums
                    else if (nums.Count >= 8)
                    {
                        Structure draw =
                            new Structure();

                        draw.DrawNumber =
                            nums[0];

                        draw.Year =
                            nums[1];

                        draw.Numbers =
                            new List<int>()
                        {
                            nums[2],
                            nums[3],
                            nums[4],
                            nums[5],
                            nums[6],
                            nums[7]
                        };

                        draws.Add(draw);
                    }
                }
                catch
                {
                }
            }

            return draws;
        }
    }
}