using DigitalCurrencyPriceWebscraper.Utilities;
using System;
using System.Collections.Generic;

namespace DigitalCurrencyPriceWebscraper
{
    internal class Program
    {

        static Dictionary<string,Action> Commands = new Dictionary<string,Action>();

        static void Main(string[] args)
        {

            Commands.Add("dollar", () => Print(Inquiry.DollarPriceInRials()));
            Commands.Add("dolar", () => Print(Inquiry.DollarPriceInRials()));

            Commands.Add("btc", () => Print(Inquiry.BTCprice() + "$"));
            Commands.Add("bitcoin", () => Print(Inquiry.BTCprice() + "$"));

            Commands.Add("ethereum", () => Print(Inquiry.ETHprice() + "$"));
            Commands.Add("eth", () => Print(Inquiry.ETHprice() + "$"));

            Commands.Add("solana", () => Print(Inquiry.SOLprice() + "$"));
            Commands.Add("sol", () => Print(Inquiry.SOLprice() + "$"));

            Commands.Add("dogecoin", () => Print(Inquiry.DOGEprice() + "$"));
            Commands.Add("doge", () => Print(Inquiry.DOGEprice() + "$"));

            Commands.Add("fantom", () => Print(Inquiry.FTMprice() + "$"));
            Commands.Add("ftm", () => Print(Inquiry.FTMprice() + "$"));

            Commands.Add("brett", () => Print(Inquiry.BRETTprice() + "$"));


            Commands.Add("ton", () => Print(Inquiry.TONcprice() + "$"));
            Commands.Add("toncoin", () => Print(Inquiry.TONcprice() + "$"));

            Commands.Add("tron", () => Print(Inquiry.TRONprice() + "$"));
            Commands.Add("trx", () => Print(Inquiry.TRONprice() + "$"));

            Commands.Add("xrp", () => Print(Inquiry.XRPprice() + "$"));

            Commands.Add("near", () => Print(Inquiry.NEARprice() + "$"));

            Commands.Add("aave", () => Print(Inquiry.AAVEprice() + "$"));

            Commands.Add("hedera", () => Print(Inquiry.HBARprice() + "$"));
            Commands.Add("hbar", () => Print(Inquiry.HBARprice() + "$"));

            Commands.Add("bnb", () => Print(Inquiry.BNBprice() + "$"));

            Commands.Add("commadns", () => {foreach (string name in Commands.Keys) Print(name); });

            try
            {
                if (args == null || args.Length == 0)
                    return;

                Execute(args[0]);
            }
            catch (Exception e)
            {
                Print(e.Message);
            }
        }

        static void Execute(string command)
        {
            command = Melt(command);

            if(command.Contains(command))
                Commands[command]();
            else
            {
                float x = 0.000f;
                string foundedcommand = string.Empty;

                foreach (string name in Commands.Keys)
                {
                    int len = name.Length;

                    float w = (len - StringDistance.LevenshteinDistance(command,name)) / len;

                    if (x < w)
                    {
                        x = w;
                        foundedcommand = name;
                    }
                }

                if(x > 0.8f)
                    Commands[foundedcommand]();
                else
                {
                    if (x > 0.5f)
                        Print($"Unknown command. Do you mean {foundedcommand}");
                    else
                        Print($"Unknown command.");

                }
            }
        }

        static void Print(object message)
        {
            Console.WriteLine(message);
        }
        static string Melt(string str)
        {
            return str.Replace(" ", "").ToLower();
        }
    }
}
