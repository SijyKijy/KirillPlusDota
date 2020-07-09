using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using KirillPlusDota.Properties;

namespace KirillPlusDota.Data
{
    public class DotaService
    {
        public async Task<string> GetGame()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={Resources.Token}&steamids=76561198034591874");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    int state = (int)JObject.Parse(json)["response"]["players"][0]["personastate"];

                    if (state == 0) return "Скорее всего спит";
                    if (json.Contains("gameextrainfo")) return JObject.Parse(json)["response"]["players"][0]["gameextrainfo"].ToString();
                }

                return string.Empty;
            }
        }
    }
}
