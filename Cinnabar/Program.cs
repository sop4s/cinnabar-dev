using System;
using Cinnabar.TUI;
using Cinnabar.Controllers;
using static System.Console;
using static Cinnabar.Logs;

namespace Cinnabar {
  public class Program {
    static readonly string VERSION = "0.1";
    static void SIGINT(object sender, ConsoleCancelEventArgs args) {
      LogInfo("Closing program");
    }
    static void Main() {
      CancelKeyPress += SIGINT;
      OptionSelector selector = new OptionSelector();
      IController controller = null;
      string selection;

      ForegroundColor = ConsoleColor.Red;
      WriteLine(Embedded.Banner
          .Replace("{version}", VERSION)
          .Replace("[", "\x1b[0m[\x1b[1;31m")
          .Replace("]", "\x1b[0m]\x1b[0;31m")
      );
      ResetColor();

      ConfigManager.MKConfigDir();
      
      WriteLine("Select a mode:");
      selection = selector.Select( new string[] {
        "Webhook Manager",
        "Client Controller",
        "Bot Controller",
      });
  
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
