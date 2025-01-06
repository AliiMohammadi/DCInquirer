using HtmlAgilityPack;
using System.Linq;

namespace DigitalCurrencyPriceWebscraper
{
    internal class Inquiry
    {
        static HtmlWeb web = new HtmlWeb();
        static HtmlDocument documetn;

        public static float DollarPriceInRials()
        {
            return float.Parse(GetData("https://www.tgju.org/profile/price_dollar_rl", "//*[@id=\"main\"]/div[1]/div[1]/div[1]/div/div[2]/div/h3[1]/span[2]/span[1]").Replace(",",""));
        }

        public static float BTCprice()
        {
            return GetPrice("bitcoin");
        }
        public static float ETHprice()
        {
            return GetPrice("etherum");
        }
        public static float DOGEprice()
        {
            return GetPrice("dogecoin");
        }
        public static float SOLprice()
        {
            return GetPrice("solana");
        }
        public static float SHIBAprice()
        {
            return GetPrice("shiba-");
        }

        public static float GetPrice(string currencyname)
        {
            return MeltToFloat(GetData($"https://coinmarketcap.com/currencies/{currencyname}/", "//*[@id=\"section-coin-overview\"]/div[2]/span"));
        }

        static string GetData(string weburl, string datapath)
        {
            documetn = web.Load(weburl);

            return documetn.DocumentNode.SelectNodes(datapath).First().InnerText;
        }

        static float MeltToFloat(string data)
        {
            return float.Parse(data.Replace("$", "").Replace(",", "").Replace(".", "/").Replace(" ",""));
        }
    }
}
