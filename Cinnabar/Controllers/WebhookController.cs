using static System.Console;
namespace Cinnabar.Controllers {
  public class WebhookController : IController {
    public void Init() {
      WriteLine("Iniciando clase WebhookController");
    }
    public void Dispose() {
      WriteLine("Desechando clase WebhookController");
    }
  }
}
