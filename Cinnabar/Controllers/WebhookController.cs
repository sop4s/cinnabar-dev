using Cinnabar.TUI;
using System.Net.Http;

namespace Cinnabar.Controllers {
  public class WebhookController : IController {
    private OptionSelector Selector;
    private HttpClient Client;
    public void Init() {
      Selector = new OptionSelector();
      Client = new HttpClient();
      string selection = Selector.Select(new string[] {
        "asdasdsadddsadsa",
        "dsadsads"
      });      
    }
    public void Dispose() {
      Client.Dispose();
    }
  }
}
