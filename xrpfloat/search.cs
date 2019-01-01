using System.Text.RegularExpressions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace xrpfloat
{
    
    public class TickerSearch
    {
        public static async void UpdateTicker(System.Windows.Forms.Label t)
        {
            String result = await GetTicker();
            MatchCollection matches = Regex.Matches(result, @"ask"":""(\d*.\d*)"",""last_price"":""(\d*.\d*)""");
            float output = float.Parse(matches[0].Groups[1].Value);
            float output2 = float.Parse(matches[0].Groups[2].Value);
            System.Diagnostics.Debug.WriteLine(output2);

            if (result != null)
            {
                t.Text = "XRP: " + output;
                
                if (output2-output < 0)
                {
                    t.BackColor = System.Drawing.Color.ForestGreen;
                } else
                {
                    t.BackColor = System.Drawing.Color.Firebrick;
                }
                
            }
        } 

        public static async Task<String> GetTicker()
        {
            string apiUrl = "https://api.bitfinex.com/v1/pubticker/xrpusd";

            using (var client = new HttpClient())
            {
                string repUrl = apiUrl;
                HttpResponseMessage response = await client.GetAsync(repUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
