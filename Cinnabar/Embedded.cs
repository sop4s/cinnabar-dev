using System;
using System.IO;
using System.Reflection;

namespace Cinnabar {
  public class Embedded {
    private static string ReadEmbeddedResource(string resourceName) {
      Assembly asm = Assembly.GetExecutingAssembly();
      using (Stream stream = asm.GetManifestResourceStream(resourceName)) {
        if (stream == null)
          throw new ArgumentException($"Can't found embedded resource \"{resourceName}\""); 
        using (StreamReader reader = new StreamReader(stream)) {
          return reader.ReadToEnd();
        }
      }
    }
    private static readonly string BannerResourceName = "Cinnabar.banner.txt";
    public static readonly string Banner = ReadEmbeddedResource(BannerResourceName);
  }
}
