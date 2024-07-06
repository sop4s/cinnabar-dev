using System;
using Cinnabar.TUI;
using Cinnabar.Data;
using System.Net.Http;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace Cinnabar.Controllers {
  public class WebhookController : IController {
    private OptionSelector Selector;
    private HttpClient Client;
    private List<WebhookUser> Users;
    public void Init() {
      Selector = new OptionSelector();
      Client = new HttpClient();
      Users = ConfigManager.GetWebhookUsers();
      WriteLine("Select a profile:");
      foreach (WebhookUser usr in Users) {
        Selector.Add(usr.username);
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
