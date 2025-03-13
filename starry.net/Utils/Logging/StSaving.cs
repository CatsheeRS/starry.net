using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Utils.Logging
{
    internal static class StSaving
    {
        public static void Save(string path, string data)
        {
            string fullDir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.gameTitle);
            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            File.WriteAllText(Path.Join(fullDir, path), data);
            Starry.Log($"Saved data to {fullDir}");
        }

        public static string Load(string path)
        {
            return File.ReadAllText(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Starry.Settings.gameTitle, path));
        }
    }
}
