using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using KirillPlusDota.Properties;

namespace KirillPlusDota.Data
{
    internal class DotaService
    {
        public async Task<SteamData> GetData(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={Resources.Token}&steamids={id}");

                if (response.IsSuccessStatusCode && response.Content.Headers.ContentLength > 47) // 47 byte - empty result
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(json)["response"]["players"][0].ToObject<SteamData>();
                }

                return null;
            }
        }
    }
}
