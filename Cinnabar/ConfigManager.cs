using System;
using System.IO;
using System.Linq;
using Cinnabar.Data;
using System.Text.Json;
using System.Collections.Generic;
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
      if (!Directory.Exists(CinnabarConfigDir)) {
        LogInfo("Config dir does not exist: making one > " + CinnabarConfigDir);
        CheckDir(CinnabarConfigDir);
        CheckDir(WebhooksDir);
      }
    }
    public static List<WebhookUser> GetWebhookUsers() {
      List<WebhookUser> users = new List<WebhookUser>();
      string[] files = GetUserFiles();
      foreach (string file in files) {
        try {
          string content = File.ReadAllText(file);
          WebhookUser usr = JsonSerializer.Deserialize<WebhookUser>(content);
          users.Add(usr);
        }
        catch {

        }
      }
      return users;
    }
    public static string[] GetUserFiles() {
      if (!Directory.Exists(WebhooksDir)) {
        LogError("Webhook user folder not exists");
        return new string[0];
      }
      string[] files = Directory.GetFiles(WebhooksDir);
      return files.Where(x => x.EndsWith(".json")).ToArray();
    }
  }
}
