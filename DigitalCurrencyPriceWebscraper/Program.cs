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
                Print("Unknown command.");
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
