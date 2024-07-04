using static System.Console;

namespace Cinnabar.TUI {
  public class OptionSelector {
    public OptionSelector() {
      
    }
    public string Select(string[] opts) {
      WriteLine("Select a option:");
      for (int i = 0; i < opts.Length; i++) {
        WriteLine("\t[{0}] {1}", i, opts[i]);
      }
      Write("> ");
      return opts[int.Parse(ReadLine())]; //fix later
    }
  }
}
