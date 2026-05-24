using DocumentFormat.OpenXml.Packaging;

namespace TotoAnalyzer.Helper
{
    public class DocumentReader
    {
        private HttpClient client = new HttpClient();

        public DocumentReader()
        {
            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0");
        }

        public async Task<string> ReadDocxFromUrl(
            string url)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    byte[] data =
                        await client
                        .GetByteArrayAsync(url);

                    string tempFile =
                        Path.GetTempFileName()
                        + ".docx";

                    await File.WriteAllBytesAsync(
                        tempFile,
                        data);

                    using (WordprocessingDocument doc =
                           WordprocessingDocument.Open(
                               tempFile,
                               false))
                    {
                        return doc
                            .MainDocumentPart
                            .Document
                            .Body
                            .InnerText;
                    }
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }

            return "";
        }
    }
}