using Cinnabar.TUI;
using System.Net.Http;
using static System.Console;

namespace Cinnabar.Controllers {
  public class WebhookController : IController {
    private OptionSelector Selector;
    private HttpClient Client;
    public void Init() {
      Selector = new OptionSelector();
      Client = new HttpClient();
      WriteLine("Select a profile:");
      string selection = Selector.Select(new string[] {
        "test profile 1",
        "test profile 2",
        "test profile 3",
        "test profile 4"
      });      
    }
    public void Dispose() {
      Client.Dispose();
    }
  }
}
