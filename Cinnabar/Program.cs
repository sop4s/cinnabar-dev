using System;
using Cinnabar.TUI;
using Cinnabar.Controllers;
using static System.Console;
using static Cinnabar.Logs;

namespace Cinnabar {
  public class Program {
    static void SIGINT(object sender, ConsoleCancelEventArgs args) {
      WriteLine("Program canceled by user");
    }
    static void Main() {
      CancelKeyPress += SIGINT;
      OptionSelector selector = new OptionSelector();
      IController controller = null;
      string selection;

      WriteLine(Embedded.Banner);

      ConfigManager.MKConfigDir();

      selection = selector.Select( new string[] {
        "Webhook Manager",
        "Client Controller",
        "Bot Controller"
      });
      WriteLine(selection);
      switch (selection)
      {
        case "Webhook Manager":
          controller = new WebhookController();
          break;
          case "Client Controller":
          controller = new ClientController();
        break;
          case "Bot Controller":
          controller = new BotController();
          break;
        default:  
          LogError("Unknown option");
          Environment.Exit(1);
          break;
      }
      if (controller != null) {
        controller.Init();
        controller.Dispose();
      }
    }
  }
}
