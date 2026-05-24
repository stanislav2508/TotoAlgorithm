using TotoAnalyzer.Helper;
using TotoAnalyzer.Models;

namespace TotoAnalyzer
{
    public class Loader
    {
        public async Task<IEnumerable<Structure>>
            LoadYear(int year)
        {
            List<Structure> allDraws =
                new List<Structure>();

            List<string> links =
                GetLinks();

            string? selectedLink = null;

            foreach (string link in links)
            {
                // 1958-1999
                if (year < 2000)
                {
                    string shortYear =
                        year.ToString()
                        .Substring(2);

                    if (link.Contains(
                        "_" + shortYear + ".txt"))
                    {
                        selectedLink = link;
                        break;
                    }
                }

                // 2000-2004
                else if (year >= 2000 &&
                         year <= 2004)
                {
                    string shortYear =
                        year.ToString()
                        .Substring(2);

                    if (link.Contains(
                        "_" + shortYear + ".txt"))
                    {
                        selectedLink = link;
                        break;
                    }
                }

                // 2005-2016
                else if (year >= 2005 &&
                         year <= 2016)
                {
                    if (link.Contains(
                        "_" + year + ".txt"))
                    {
                        selectedLink = link;
                        break;
                    }
                }

                // 2017+
                else
                {
                    if (link.Contains(
                        "/" + (year + 1) + "/"))
                    {
                        selectedLink = link;
                        break;
                    }
                }
            }

            if (selectedLink == null)
            {
                Console.WriteLine(
                    "Year not found!");

                return allDraws;
            }

            Console.WriteLine();
            Console.WriteLine(
                $"Loading: {selectedLink}");

            try
            {
                string text = "";

                NotepadReader txtReader =
                    new NotepadReader();

                DocumentReader docReader =
                    new DocumentReader();

                StructureParser parser =
                    new StructureParser();

                if (selectedLink.EndsWith(".txt"))
                {
                    text =
                        await txtReader
                        .ReadTxtFromUrl(
                            selectedLink);
                }
                else if (selectedLink.EndsWith(".docx"))
                {
                    text =
                        await docReader
                        .ReadDocxFromUrl(
                            selectedLink);
                }

                if (!string.IsNullOrWhiteSpace(text))
                {
                    IEnumerable<Structure> draws =
                        parser.Parse(text);

                    allDraws.AddRange(draws);

                    Console.WriteLine(
                        $"Loaded draws: {draws.Count()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    ex.Message);
            }

            return allDraws;
        }

        private List<string> GetLinks()
        {
            return new List<string>()
    {
        "https://info.toto.bg/content/files/stats-tiraji/649_58.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_59.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_60.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_61.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_62.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_63.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_64.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_65.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_66.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_67.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_68.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_69.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_70.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_71.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_72.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_73.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_74.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_75.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_76.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_77.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_78.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_79.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_80.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_81.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_82.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_83.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_84.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_85.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_86.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_87.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_88.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_89.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_90.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_91.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_92.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_93.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_94.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_95.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_96.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_97.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_98.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_99.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_00.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_01.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_02.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_03.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_04.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_2005.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2006.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2007.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2008.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2009.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2010.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2011.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2012.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2013.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2014.txt",

        "https://info.toto.bg/content/files/stats-tiraji/649_2015.txt",
        "https://info.toto.bg/content/files/stats-tiraji/649_2016.txt",

        "https://info.toto.bg/content/files/2018/01/26/2a0952991d371ca5575a4d79e5c5e5d5.txt",
        "https://info.toto.bg/content/files/2019/02/16/be9d1b15257f53cd749db1e501b01180.txt",
        "https://info.toto.bg/content/files/2020/01/04/149bdb98aa8426faf31b8b57fde4c5eb.txt",
        "https://info.toto.bg/content/files/2021/01/09/8241c0de420163c1fcfd616689d1fa33.txt",

        "https://info.toto.bg/content/files/2022/01/02/b72d0cbe449bcc17ec8ecb19ee82233a.docx",
        "https://info.toto.bg/content/files/2023/01/11/5f8be78ee5e2ceb7839cefe22b7d2f1b.docx",
        "https://info.toto.bg/content/files/2024/01/08/c6283cfbdeb917bb3ba894cc38b24728.docx",
        "https://info.toto.bg/content/files/2025/01/06/ea7643fc1635991fe4548cf57b3cf994.docx",
        "https://info.toto.bg/content/files/2026/01/07/5026e066d4883844db5c8ab602e38858.docx"
    };
        }
    }
}