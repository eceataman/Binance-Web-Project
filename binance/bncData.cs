using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace binance
{
    public class bncData
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }

        public bool IsFavorite { get; set; }

        public int depth { get; set; }
    }
}