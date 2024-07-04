using System;
using static System.Console;

namespace Cinnabar {
  public class Logs {
    private static void Log(string log_type, ConsoleColor color, string msg) {
      Write("[");
      ForegroundColor = color;
      Write(log_type);
      ResetColor();
      WriteLine("] {0}", msg);
    }
    public static void LogInfo(string msg) => 
      Log("Info", ConsoleColor.DarkGray, msg);

    public static void LogError(string msg) =>
      Log("Error", ConsoleColor.Red, msg);
    
    public static void LogWarn(string msg) =>
      Log("Warn", ConsoleColor.Yellow, msg);
  }
}
