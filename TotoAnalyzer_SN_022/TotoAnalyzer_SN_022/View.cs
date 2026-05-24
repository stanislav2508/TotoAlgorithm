namespace TotoAnalyzer
{
    public class View
    {
        public void ShowBarChart(
            Dictionary<int, int> data)
        {
            if (data.Count == 0)
            {
                Console.WriteLine("No data!");
                return;
            }

            int max = data.Values.Max();

            foreach (var item in data)
            {
                int barLength =
                    (item.Value * 30) / max;

                Console.Write(
                    $"{item.Key,2} | ");

                Console.WriteLine(
                    new string('#', barLength)
                    + $" {item.Value}");
            }
        }

        public void ShowHeatMap(
            Dictionary<int, int> freq)
        {
            if (freq.Count == 0)
            {
                Console.WriteLine("No data!");
                return;
            }

            int max =
                freq.Values.Max();

            int high =
                (max * 70) / 100;

            int low =
                (max * 30) / 100;

            for (int i = 1; i <= 49; i++)
            {
                int value = 0;

                if (freq.ContainsKey(i))
                {
                    value = freq[i];
                }

                if (value >= high)
                {
                    Console.ForegroundColor =
                        ConsoleColor.Red;
                }
                else if (value >= low)
                {
                    Console.ForegroundColor =
                        ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor =
                        ConsoleColor.Cyan;
                }

                Console.Write($"{i,3}");

                Console.ResetColor();

                if (i % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}