using static System.Console;
namespace Cinnabar.Controllers {
  public class ClientController : IController {
    public void Init() {
      WriteLine("Iniciando clase ClientController");
    }
    public void Dispose() {
      WriteLine("Desechando clase ClientController");
    }
  }
}
