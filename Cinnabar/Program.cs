using System;
using Cinnabar.TUI;
using Cinnabar.Controllers;
using static System.Console;
using static Cinnabar.Logs;

namespace Cinnabar;

public class Program {
  static IController Controller = null;
  
  static void SIGINT(object sender, ConsoleCancelEventArgs args) {
    WriteLine("Program canceled by user");
  }
  static void Main() {
    CancelKeyPress += SIGINT;
    OptionSelector selector = new OptionSelector();
    string selection;

    selection = selector.Select( new string[] {
      "Webhook Manager",
      "Client Controller",
      "Bot Controller"
    });

    switch (selection)
    {
      case "Webhook Manager":
        Controller = new WebhookController();
        Controller.Init();
        break;
      case "Client Controller":
        
        break;
      case "Bot Controller":
        
        break;
      default:  
        LogError("Unknown option");
        Environment.Exit(1);
        break;
    }
    if (Controller != null) Controller.Dispose();
  }
}
