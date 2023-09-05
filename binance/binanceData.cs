using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Binance.Net;
using Binance.Net.Objects;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Interfaces.Clients;
using Binance.Net.Clients;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace binance
{
    public class binanceData
    {
        public async Task<List<bncData>> GetData()
        {
            var client = new BinanceRestClient();
            var exchangeInfo = await client.SpotApi.ExchangeData.GetExchangeInfoAsync();
            var tickers = await client.SpotApi.ExchangeData.GetPricesAsync();

            var veriler = new List<bncData>();

            foreach (var ticker in tickers.Data)
            {
                var product = new bncData
                {
                    Id = veriler.Count + 1, // ID'leri sırasıyla 1, 2, 3, ... şeklinde atayalım
                    Symbol = ticker.Symbol,
                    Price = ticker.Price
                };

                veriler.Add(product);
            }

            return veriler;
        }



    }

    //public async Task<IEnumerable<IBinanceKline>> GetBarData(string symbol)
    //{
    //    var client = new BinanceRestClient();
    //    var barDatas = await client.SpotApi.ExchangeData.GetKlinesAsync(symbol, KlineInterval.OneDay);
    //    return barDatas.Data;
    //}



}