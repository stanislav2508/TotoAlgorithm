using System.Text;

namespace TotoAnalyzer.Helper
{
    public class NotepadReader
    {
        private HttpClient client =
            new HttpClient();

        public NotepadReader()
        {
            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0");
        }

        public async Task<string>
            ReadTxtFromUrl(string url)
        {
            try
            {
                byte[] data =
                    await client
                    .GetByteArrayAsync(url);

                Encoding.RegisterProvider(
                    CodePagesEncodingProvider.Instance);

                Encoding win1251 =
                    Encoding.GetEncoding(1251);

                string text =
                    win1251.GetString(data);

                return text;
            }
            catch
            {
                return "";
            }
        }
    }
}