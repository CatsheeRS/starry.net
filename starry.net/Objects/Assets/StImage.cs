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

        internal Rectangle SourceRect;
        internal Rectangle DestRect;

        internal void RefreshTexture()
        {
            RlTexture = Raylib.LoadTextureFromImage(RLImage);
            SourceRect = new Rectangle(0, 0, RlTexture.Width, RlTexture.Height);
            DestRect = new Rectangle(0, 0, RlTexture.Width, RlTexture.Height);
        }

        public void Dispose()
        {
            Raylib.UnloadImage(RLImage);
        }

        public void Load(string Path)
        {
            RLImage = Raylib.LoadImage(Path);
            Starry.Log("loaded rl image");
            RefreshTexture();
        }

        public StImage()
        {
        }
    }
}
