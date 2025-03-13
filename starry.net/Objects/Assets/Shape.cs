using Raylib_cs;
using System.Numerics;

namespace Starry.NET.Objects.Assets
{
    public class Shape : IAsset
    {
        public enum ShapeType
        {
            Rectangle,
            Circle,
            Triangle
        }

        private ShapeType Type;
        public Color Colour;

        Shape(ShapeType Type, Color? Colour)
        {
            this.Type = Type;

            if (Colour != null)
                this.Colour = Colour.Value;
        }

        //public void Draw() TURN THIUS OVER TO SPRITE COMPONENT
        //{
        //    switch (Type)
        //    {
        //        case ShapeType.Rectangle:
        //            Raylib.DrawRectangle(Entity, 0, 100, 100, Colour);
        //            break;
        //        case ShapeType.Circle:
        //            Raylib.DrawCircle(100, 100, 50, Colour);
        //            break;
        //        case ShapeType.Triangle:
        //            Raylib.DrawTriangle(new Vector2(100, 100), new Vector2(200, 100), new Vector2(150, 200), Colour);
        //            break;
        //    }
        //}
    }
}
