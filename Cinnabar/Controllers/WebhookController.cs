using System;
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
      foreach (string name in userNames) {
        Selector.Add(name.Split('/').Last().Replace(".json", string.Empty));
      }
      Selector.Add("Exit");
      Selector.OnChange+= ((string opt) => {
        string fill = new String('-', 15);
        
        WriteLine(fill);
        WriteLine("Name: {0}{1}", opt, new String(' ', 15));
        WriteLine("Avatar url: idk");
        WriteLine("Etc: ...");
        WriteLine(fill);
      });
      string selection = Selector.Select();
      switch (selection) {
        case "Exit":
          Environment.Exit(0);
          break;
        default:
          WriteLine("Abriendo usuario");
          
          break;
      }
    }
    public void Dispose() {
      Client.Dispose();
    }
  }
}
