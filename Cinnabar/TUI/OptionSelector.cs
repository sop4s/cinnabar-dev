using System;
using static System.Console;

namespace Cinnabar.TUI {
  public class OptionSelector {
    public OptionSelector() {
      
    }
    public string Select(string[] opts) {
      WriteLine("Select a option:");
      for (int i = 0; i < opts.Length; i++) {
        Write("[");
        ForegroundColor = ConsoleColor.Red;
        Write(i);
        ResetColor();
        WriteLine("] {0}", opts[i]);
      }
      Write(Environment.UserName + " > ");
      int index;
      if (!int.TryParse(ReadLine(), out index)) {
        return opts[0];
      }
      return opts[index]; //fix later
    }
  }
}
