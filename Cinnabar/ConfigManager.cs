using System;
using System.IO;
using static Cinnabar.Logs;

namespace Cinnabar {
  public class ConfigManager {

    private static readonly string CinnabarConfigDir =  
      Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.config/cinnabar/";
    private static readonly string WebhooksDir = CinnabarConfigDir + "users/";

    private static void CheckDir(string dir) {
      if (!Directory.Exists(dir)) {
        Directory.CreateDirectory(dir);
      }
    }
    ///<summary>Creates .config/cinnabar/ dir if not exists</summary)>
    public static void MKConfigDir() {
      Console.WriteLine(CinnabarConfigDir);
      if (!Directory.Exists(CinnabarConfigDir)) {
        LogInfo("Config dir does not exist: making one > " + CinnabarConfigDir);
        CheckDir(CinnabarConfigDir);
        CheckDir(WebhooksDir);
      }
    }
  }
}
