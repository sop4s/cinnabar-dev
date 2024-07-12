using System.Net.Http;
using System.Threading.Tasks;
using Cinnabar.TUI;
using static System.Console;

namespace Cinnabar.Controllers {
  public class ClientController : IController {
    private HttpClient Client;
    private string CurrentToken;

    public void Init() => InitAsync().GetAwaiter().GetResult();

    public async Task InitAsync() {
      Client = new HttpClient();
      OptionSelector selector = new OptionSelector(new string[]{
        "Connect", 
        "Config", 
        "Back"
      });
      switch (selector.Select()){
        case "Connect":
          WriteLine("Escribe el token");
          Write(">> ");
          CurrentToken = ReadLine();
          string username = await AccountUtils.CheckUserData(Client, "username");
          break;
        case "Config":
          break;
        case "Back":
          break;
      }
    }
    
    public void Dispose() {
      Client.Dispose();
    }
  }
}
