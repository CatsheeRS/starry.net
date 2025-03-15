using Raylib_cs;
using Starry.NET.Objects.Assets;
using Starry.NET.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Objects
{
    public class Sprite : Component
    {
        public StImage Image { get; set; }
        public Color Colour { get; set; } = Color.White;

        internal override void EarlyUpdate()
        {
            if (Image == null)
                return;

            Raylib.DrawTexture(Image.RlTexture, (int)Entity.Position.X, (int)Entity.Position.Y, Colour);
        }
    }
}
