using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace xrpfloat
{
    public class TickerSearch
    {
        public static async void UpdateTicker(System.Windows.Forms.Label t)
        {
            RootObject result = await GetTicker();
            if (result != null)
            {
                t.Text = "XRP: " + result.ask;
                if (float.Parse(result.last_price)-float.Parse(result.ask) < 0)
                {
                    t.BackColor = System.Drawing.Color.ForestGreen;
                } else
                {
                    t.BackColor = System.Drawing.Color.Firebrick;
                }
            }
        } 

        public static async Task<RootObject> GetTicker()
        {
            string apiUrl = "https://api.bitfinex.com/v1/pubticker/xrpusd";

            using (var client = new HttpClient())
            {
                string repUrl = apiUrl;
                HttpResponseMessage response = await client.GetAsync(repUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootResult = JsonConvert.DeserializeObject <RootObject>(result);
                    return rootResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
