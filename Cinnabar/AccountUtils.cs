using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Cinnabar {
  
  public class AccountUtils {

    public static async Task<string> CheckUserData(HttpClient client, string key) {  
      var response = await client.GetAsync("https://discord.com/api/v9/users/@me");
      string content = await response.Content.ReadAsStringAsync();
      JsonNode node = JsonObject.Parse(content);
      return node[key].ToString();
    }

  }

}
