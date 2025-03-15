using Raylib_cs;
using System.Numerics;

namespace Starry.NET.Objects.Assets
{
    public class Shape : IAsset
    {
        public enum ShapeType
        {
            Rectangle,
            Circle
        }

        private ShapeType Type;
        public Color Colour;
        public Vector2 Position;
        public Vector2 Size;

        public Shape(ShapeType Type, Color? Colour)
        {
            this.Type = Type;

            if (Colour != null)
                this.Colour = Colour.Value;
        }

        public void Draw() //TURN THIUS OVER TO SPRITE COMPONENT
        {
            switch (Type)
            {
                case ShapeType.Rectangle:
                    Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, Colour);
                    break;
                case ShapeType.Circle:
                    Raylib.DrawCircle((int)Position.X, (int)Position.Y, Size.X * Size.Y, Colour);
                    break;
            }
}

        public void Load(string Path)
        {
        }

        public void Dispose()
        {
        }
    }
}
