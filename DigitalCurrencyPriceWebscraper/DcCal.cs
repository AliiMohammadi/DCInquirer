using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyPriceWebscraper
{
    internal class DcCal
    {
        public float ActualPrice(float totalprice,float dollarliveprice,float totalcurrencyincome)
        {
            return (totalprice/dollarliveprice/totalcurrencyincome);
        }
        public float CurrentProfit(float currencyliveprice,float purchesprice,float dollarliveprice,float purchesdollarprice,float tax = 1)
        {
            return ((currencyliveprice*dollarliveprice)/(purchesprice*purchesdollarprice)) * tax;
        }
    }
}
