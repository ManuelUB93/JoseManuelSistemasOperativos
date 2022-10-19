using System.IO;

namespace IdentificadorWeb
{
  public class ServicioDireccion
  {
    public static string EncontrarDirCompleta(string dir1)
    {
        FileInfo dirRoot = new FileInfo(typeof(Program).Assembly.Location);
        string DirFolder = dirRoot.Directory.FullName;
        string DirCompleta = Path.Combine(DirFolder, dir1);
        return DirCompleta;
    }
  }
}