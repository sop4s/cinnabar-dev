using System;
using static System.Console;

namespace Cinnabar.TUI {
  public class OptionSelector {
    public OptionSelector() {}
    public string Select(string[] opts) {
      int cursorInit = CursorTop;
      int currentIndex = 0;
      while (true) {     
        CursorTop = cursorInit;
        CursorLeft = 0;
        for (int i = 0; i < opts.Length; i++) {
          Write("[");
          ForegroundColor = ConsoleColor.Red;
          Write(currentIndex == i ? "#":" ");
          ResetColor();
          WriteLine("] {0}", opts[i]);
        }
        switch (ReadKey().Key) {
          case ConsoleKey.W:
          case ConsoleKey.UpArrow:
            currentIndex--;
            if (currentIndex < 0)
              currentIndex = opts.Length - 1;
            break;
          case ConsoleKey.S:
          case ConsoleKey.DownArrow:
            currentIndex++;
            if (currentIndex >= opts.Length)
              currentIndex = 0;
            break;
          case ConsoleKey.Enter:
          case ConsoleKey.D:
          case ConsoleKey.RightArrow:
            CursorLeft = 0;
            WriteLine("    ");
            return opts[currentIndex];
        }
        CursorLeft = 0;
        Write("    ");
      }
    }
  }
}
