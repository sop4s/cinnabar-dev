using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace Cinnabar.TUI {
  public class OptionSelector {
    public List<string> Options { get; private set; } = new List<string>();    
    
    public delegate void ChangeEventHandler(string option);
    public event ChangeEventHandler OnChange;
    
    public OptionSelector(string[] opts) {
      Options = opts.ToList();
    }
    public OptionSelector() {}
    public void Add(string option) {
      Options.Add(option);
    }
    public string Select() {
      int cursorInit = CursorTop;
      int currentIndex = 0;
      while (true) {     
        CursorTop = cursorInit;
        CursorLeft = 0;
        for (int i = 0; i < Options.Count; i++) {
          Write("[");
          ForegroundColor = ConsoleColor.Red;
          Write(currentIndex == i ? "#":" ");
          ResetColor();
          WriteLine("] {0}", Options[i]);
        }
        OnChange?.Invoke(Options[currentIndex]);
        switch (ReadKey().Key) {
          case ConsoleKey.W:
          case ConsoleKey.UpArrow:
            currentIndex--;
            if (currentIndex < 0) 
              currentIndex = Options.Count - 1;
            //OnChange?.Invoke(Options[currentIndex]);
            break;
          case ConsoleKey.S:
          case ConsoleKey.DownArrow:
            currentIndex++;
            if (currentIndex >= Options.Count)
              currentIndex = 0;
            //OnChange?.Invoke(Options[currentIndex]);
            break;
          case ConsoleKey.Enter:
          case ConsoleKey.D:
          case ConsoleKey.RightArrow:
            CursorLeft = 0;
            WriteLine("    ");
            return Options[currentIndex];
        }
        CursorLeft = 0;
        Write("    ");
      }
    }
  }
}
