using Cinnabar.TUI;
using System.Net.Http;
using static System.Console;
using System.Linq;
namespace Cinnabar.Controllers {
  public class WebhookController : IController {
    private OptionSelector Selector;
    private HttpClient Client;
    public void Init() {
      Selector = new OptionSelector();
      Client = new HttpClient();
      WriteLine("Select a profile:");
      string[] userNames = ConfigManager.GetUserFiles();
      for (int i = 0; i < userNames.Length; i++) {
        userNames[i] = userNames[i].Split('/').Last().Replace(".json", string.Empty);
      }
      string selection = Selector.Select(userNames);      
    }
    public void Dispose() {
      Client.Dispose();
    }
  }
}
