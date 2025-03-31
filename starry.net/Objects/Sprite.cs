using Raylib_cs;
using Starry.NET.Objects.Assets;
using System.Numerics;

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

            Vector2 origin = new Vector2(Image.DestRect.Width / 2, Image.DestRect.Height / 2);

            if (Entity.Scale != Image.DestRect.Size)
            {
                Image.DestRect.Width = Image.RlTexture.Width * Entity.Scale.X;
                Image.DestRect.Height = Image.RlTexture.Height * Entity.Scale.Y;
            }

            Raylib.DrawTexturePro(
                Image.RlTexture,
                Image.SourceRect,
                Image.DestRect,
                origin,
                Entity.Rotation,
                Colour
            );
        }
    }
}
