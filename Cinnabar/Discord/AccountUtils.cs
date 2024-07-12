using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
public class AccountUtils
{
    public async Task<string> CheckUsername(HttpClient client)
    {
        var r = await client.GetAsync("https://discord.com/api/v9/users/@me");
        var content = await r.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        string x = JsonObject.Parse<string>("txt")[""];
        //return "blablabla";
    }
}
public struct Data{
    public string username {get;set;}
}