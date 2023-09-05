using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;
using System.Web.Helpers;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using binance; // BinanceWebSocket sınıfını içeren using
using Binance.Net.Interfaces.Clients;
using Binance.Net.Clients;
using Binance.Net.Enums;
using CryptoExchange.Net.Interfaces;

namespace binance.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBinanceSocketClient _socketClient;

        public HomeController()
        {
            _socketClient = new BinanceSocketClient();
            var binanceApiClient = new binanceData();
            // var symbols =  binanceApiClient.GetData();
            // var symbols = new Dictionary<string, List<decimal>>();
            List<bncData> symbols = new List<bncData>();
            // var symbols =  binanceApiClient.GetData();

            //var symbols = binanceApiClient.GetData();

            //foreach (var symbol in symbols)
            //{

            //    var subscription = _socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(symbol.Symbol.Replace(" ", ""), data =>
            //    {

            //        var symbolPrice = data.Data.LastPrice;
            //        ViewBag.symbolPrice = symbolPrice;
            //        // Görüntüyü güncelleme mekanizması eklenebilir
            //    });
            //}

        }
        public async Task<ActionResult> Index(bool? showFavorites)
        {

            var binanceApiClient = new binanceData();
            // var sqlConnection = new sqlConnection();
            // sqlConnection.AddExample();


            var itemList = await binanceApiClient.GetData();
            // var symbolData = new Dictionary<string, List<decimal>>();

            List<Favorite> favorites = new List<Favorite>();

            using (var context = new binanceEntities4())
            {
                favorites = context.Favorite.ToList();
            }
            foreach (var item in favorites)
            {
                var f = itemList.FirstOrDefault(x => x.Symbol == item.bncSymbol.Trim());
                if (f != null)
                    f.IsFavorite = true;
                //context.favorites.Add(f);

            }


            if (showFavorites == true)
            {
                var favoriteItems = itemList.Where(item => item.IsFavorite == true).ToList();
                return View(favoriteItems);
            }

            //ViewBag.SymbolData = symbolData;

            return View(itemList);

        }

        public async Task<ActionResult> Graph(string symbol)
        {
            var binanceApiClient = new binanceData();
            var itemList = await binanceApiClient.GetData();

            var symbolData = itemList.FirstOrDefault(x => x.Symbol == symbol.Trim());

            if (symbolData == null)
            {
                // Eğer sembol verisi bulunamazsa uygun bir hata sayfasına yönlendirme yapabilirsiniz
                return View("Error");
            }

            ViewBag.SymbolHeader = symbolData.Symbol;

            return View(symbolData);
        }


        [HttpPost]
        public ActionResult AddorRemoveFavorites(int id, string symbol, bool isCheck)
        {
            using (var context = new binanceEntities4())
            {
                var favoriteList = context.Favorite.ToList();

                Favorite favorite = new Favorite();
                //favorite.Id= id;
                favorite.bncSymbol = symbol;

                if (isCheck && !context.Favorite.Any(p => p.bncSymbol == symbol))
                    context.Favorite.Add(favorite);
                else if (!isCheck && context.Favorite.Any(p => p.bncSymbol == symbol))
                    context.Favorite.Remove(context.Favorite.FirstOrDefault(x => x.bncSymbol == symbol));
                var updates = context.SaveChanges();

                //var insertId = context.SaveChanges();
            }

            return Json(true);
        }

    }


}