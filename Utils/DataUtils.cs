using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaToppingCode
{
    class DataUtils
    {
        private const string pizzaJsonUrl = "http://files.olo.com/pizzas.json";


        #region Private Methods
        private static string GetToppings() {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(pizzaJsonUrl);
                return json;
            }
        }

        private static List<PizzaJson> ConvertJsonToObject(string json) {
            var pizzaJsonList = new List<PizzaJson>();
            try
            {
                pizzaJsonList = JsonConvert.DeserializeObject<List<PizzaJson>>(json);
                return pizzaJsonList;
            }
            catch(Exception ex)
            {
                return pizzaJsonList;
            }
            
        }
        #endregion


        #region Public Methods

        public static List<PizzaToppings> GetTop20Toppings() {
            var toppingStr = GetToppings();
            var toppingsJson = ConvertJsonToObject(toppingStr);

            var top20ToppingsList = toppingsJson.SelectMany(x => x.toppings)
                                        .GroupBy(s => s)
                                        .Select(g => new PizzaToppings() { Name = g.Key, Count = g.Count() }).Take(20).OrderByDescending(u => u.Count).ToList();

            return top20ToppingsList;
        }
        #endregion

    }
}
