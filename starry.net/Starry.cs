using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using Starry.NET.Objects;
using Starry.NET.Utils.Logging;

namespace Starry.NET
{
    public class Starry
    {
        public static StarrySettings Settings { get; internal set; }
        internal static string STLPath { get; private set; } = Path.GetFullPath("stl");

        private struct Vec2I
        {
            public int X;
            public int Y;

            public static implicit operator Vec2I((int, int) v)
            {
                return new() { X = v.Item1, Y = v.Item2 };
            }
        }

        public static void Load(StarrySettings settings)
        {
            Settings = settings;
            Log("Starting Starry.Net...");

            Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
            Raylib.InitWindow(800, 600, "Starry.NET");
            Log("Initalized window...");

            Font testFont = Raylib.LoadFont($"{STLPath}/Hanuman.ttf");

            Raylib.SetTextureFilter(testFont.Texture, TextureFilter.Trilinear);

            Raylib.SetTargetFPS(60);

            float size = 40;
            float spacing = 1;
            string str = "No cameras are currently rendering";

            settings.OnLoad?.Invoke();
            while (!Raylib.WindowShouldClose())
            {
                Vec2I screenCentre = (Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawFPS(0, 0);
                if (Camera.Current == null)
                {
                    Vector2 textEx = Raylib.MeasureTextEx(testFont, str, size, spacing) / 2;
                    Raylib.DrawTextPro(testFont, str, new Vector2(screenCentre.X - textEx.X, screenCentre.Y), new Vector2(0, 0), 0, size, spacing, Color.White);
                } else
                {
                    Raylib.BeginMode2D(Camera.Current.rlCamera);

                    Raylib.EndMode2D();
                }

                Raylib.EndDrawing();
            }
        }

        public static void Log(params object[] objs) => StLogging.Log(objs);
    }

}
