using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNet.Utils.Logging
{
    internal static class StSaving
    {
        public static void Save(string path, string data)
        {
            string fullDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.GameTitle);
            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            File.WriteAllText(Path.Join(fullDir, path), data);
        }

        public static void Delete(string path)
        {
            string fullDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.GameTitle);
            if (Directory.Exists(fullDir))
                File.Delete(Path.Join(fullDir, path));
        }

        public static void Add(string path, string data)
        {
            string fullDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.GameTitle);
            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            File.AppendAllText(Path.Join(fullDir, path), data);
        }

        public static string Load(string path)
        {
            return File.ReadAllText(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.GameTitle, path));
        }
    }
}
