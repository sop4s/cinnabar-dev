using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cinnabar.TUI;
using static System.Console;
namespace Cinnabar.Controllers {
  public class ClientController : IController {
    public void Init() => InitAsync().GetAwaiter().GetResult();
    public async Task InitAsync() {
      var selection = new OptionSelector(new string[]{"Connect", "Config", "Back"});
      switch (selection.Select()){
        case "Connect":
          WriteLine("Escribe el token");
          Write(">>");
          await new AccountUtils().CheckUsername(ReadLine());
        break;
        case "Config":
        break;
        case "Back":
        break;
      }
    }
    public void Dispose() {
      
    }
  }
}
