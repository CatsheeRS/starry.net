using Raylib_cs;
using Starry.NET.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Objects.Assets
{
    public class StImage : IAsset
    {
        internal Image RLImage;
        internal Texture2D RlTexture;

        internal void RefreshTexture()
        {
            RlTexture = Raylib.LoadTextureFromImage(RLImage);
        }

        public void Dispose()
        {
            Raylib.UnloadImage(RLImage);
        }

        public void Load(string Path)
        {
            RLImage = Raylib.LoadImage(Path);
            StLogging.Log("loaded rl image");
            RefreshTexture();
        }
    }
}
