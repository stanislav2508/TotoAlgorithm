using TotoAnalyzer.Models;

namespace TotoAnalyzer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title =
                "Toto Analyzer";

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "==================================");

                Console.WriteLine(
                    "         TOTO ANALYZER");

                Console.WriteLine(
                    "==================================");

                Console.WriteLine(
                    "[1] Load year");

                Console.WriteLine(
                    "[0] Exit");

                Console.WriteLine(
                    "==================================");

                Console.Write(
                    "Choice: ");

                string startChoice =
                    Console.ReadLine();

                if (startChoice == "0")
                {
                    break;
                }

                if (startChoice != "1")
                {
                    continue;
                }

                Console.Write(
                    "Enter year (1958-2025): ");

                if (!int.TryParse(
                    Console.ReadLine(),
                    out int year))
                {
                    Console.WriteLine(
                        "Invalid year!");

                    Console.ReadKey();

                    continue;
                }

                Loader loader =
                    new Loader();

                Console.WriteLine();
                Console.WriteLine(
                    "Loading data...");
                Console.WriteLine();

                IEnumerable<Structure> draws =
                    await loader.LoadYear(
                        year);

                Console.WriteLine();
                Console.WriteLine("Data loaded successfully! Press any key to continue!");

                Console.ReadKey();

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine(
                        "==================================");

                    Console.WriteLine(
                        $"         YEAR {year}");

                    Console.WriteLine(
                        "==================================");

                    Console.WriteLine(
                        "[1] Top N numbers");

                    Console.WriteLine(
                        "[2] Hot pairs");

                    Console.WriteLine(
                        "[3] Distribution");

                    Console.WriteLine(
                        "[4] Heat map");

                    Console.WriteLine(
                        "[5] Change year");

                    Console.WriteLine(
                        "[0] Exit");

                    Console.WriteLine(
                        "==================================");

                    Console.Write(
                        "Choice: ");

                    string choice =
                        Console.ReadLine();

                    if (choice == "0")
                    {
                        return;
                    }

                    if (choice == "5")
                    {
                        break;
                    }

                    Stats stats =
                        new Stats(draws);

                    View view =
                        new View();

                    // TOP NUMBERS
                    if (choice == "1")
                    {
                        Console.Write(
                            "Top N: ");

                        int n =
                            int.Parse(
                                Console.ReadLine());

                        var data =
                            stats.GetTopNumbers(n);

                        view.ShowBarChart(data);

                        Console.ReadKey();
                    }

                    // HOT PAIRS
                    else if (choice == "2")
                    {
                        Console.Write(
                            "Top pairs: ");

                        int n =
                            int.Parse(
                                Console.ReadLine());

                        var pairs =
                            stats.GetHotPairs(n);

                        foreach (var pair in pairs)
                        {
                            Console.WriteLine(
                                $"{pair.Item1} - " +
                                $"{pair.Item2} -> " +
                                $"{pair.Item3}");
                        }

                        Console.ReadKey();
                    }

                    // DISTRIBUTION
                    else if (choice == "3")
                    {
                        var dist =
                            stats.GetDistribution();

                        foreach (var item in dist)
                        {
                            Console.WriteLine(
                                $"{item.Key} -> " +
                                $"{item.Value}");
                        }

                        Console.ReadKey();
                    }

                    // HEAT MAP
                    else if (choice == "4")
                    {
                        var data =
                            stats.GetTopNumbers(49);

                        view.ShowHeatMap(data);

                        Console.ReadKey();
                    }
                }
            }
        }
    }
}