using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using Starry.NET.Objects;
using Starry.NET.Utils.Logging;
namespace Starry.NET
{
    public class Starry
    {
        
        private struct Vec2I
        {
            public int X;
            public int Y;

            public static implicit operator Vec2I((int, int) v)
            {
                return new() { X = v.Item1, Y = v.Item2 };
            }
        }

        public static void Load(string assetpath)
        {
            Log("Starting Starry.Net...");

            Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
            Raylib.InitWindow(800, 600, "Starry.NET");
            Log("Initalized window...");

            Vec2I screenCentre = (Raylib.GetScreenWidth() / 2, Raylib.GetRenderHeight() / 2);
            Font testFont = Raylib.LoadFont($"{assetpath}/Hanuman.ttf");

            Raylib.SetTextureFilter(testFont.Texture, TextureFilter.Trilinear);

            Raylib.SetTargetFPS(60);
            Vector2 measuredEx = Raylib.MeasureTextEx(testFont, "Test", 20, 1) / 2;
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                if (Camera.Current == null)
                {
                    float size = 40;
                    float spacing = 1;
                    string str = "No cameras are currently rendering";
                    Vector2 textEx = Raylib.MeasureTextEx(testFont, str, size, spacing) / 2;
                    Raylib.DrawTextPro(testFont, "No cameras are currently rendering", new Vector2(screenCentre.X - textEx.X, screenCentre.Y), new Vector2(0, 0), 0, size, spacing, Color.White);
                } else
                {
                    Raylib.DrawTextPro(testFont, "Cameras are currently rendering", new Vector2(0, 0), new Vector2(screenCentre.X, screenCentre.Y), 0, 20, 2, Color.White);
                }

                    Raylib.EndDrawing();
            }
        }

        public static void Log(params object[] objs) => StLogging.Log(objs);
    }

}
