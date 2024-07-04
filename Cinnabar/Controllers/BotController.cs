using static System.Console;
namespace Cinnabar.Controllers {
  public class BotController : IController {
    public void Init() {
      WriteLine("Iniciando clase BotController");
    }
    public void Dispose() {
      WriteLine("Desechando clase BotController");
    }
  }
}
