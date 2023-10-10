using System.IO;
using System.Text;
using System.Net;
using System.Windows;
using StarRail_Launcher.Core.Extension;
using System.Threading.Tasks;
using System.Net.Http;
using StarRail_Launcher.Crypt;

namespace StarRail_Launcher.Core
{
    public class HtmlHelper
    {

        private const string Url = "https://gitee.com/sinyat/pkg-version/raw/master/Star Rail/content";

        public static async Task<string> ReadHTMLAsTextAsync(string url)
        {
            try
            {
                using (Stream stream = await new HttpClient().GetStreamAsync(url))
                {
                    using (StreamReader sr = new(stream, Encoding.UTF8))
                    {
                        var r = await sr.ReadToEndAsync();
                        return AESCrypt.DecryptString(CryptConstant.AES_Key, r);
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string Mid(string str, string preStr, string nextStr)
        {
            try
            {
                string trimFront = str[(str.IndexOf(preStr) + preStr.Length)..];
                return trimFront[..trimFront.IndexOf(nextStr)];
            }
            catch
            {
                return string.Empty;
            }
        }

        public static async Task<string> GetInfoFromHtmlAsync(string tag)
        {
            return Mid(await ReadHTMLAsTextAsync(Url), $"【{tag}++】", $"【{tag}--】");
        }
    }
}
