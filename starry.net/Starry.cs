using System.Diagnostics;
using System.Numerics;
using Raylib_cs;
using Starry.NET.Objects;
using Starry.NET.Objects.Assets;
using Starry.NET.Utils.Entities;
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
            StSaving.Delete("log.txt");
            Log("Starting Starry.NET");

            Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
            Raylib.InitWindow(800, 600, Settings.GameTitle);

            Log("Initalized window");
            Font testFont = Raylib.LoadFont($"{STLPath}/Hanuman.ttf");
            Raylib.SetTextureFilter(testFont.Texture, TextureFilter.Bilinear);

            Log("Loaded STL");

            Raylib.SetTargetFPS(60);

            float size = 40;
            float spacing = 1;
            string str = "No cameras are currently rendering";

            settings.OnLoad?.Invoke();
            while (!Raylib.WindowShouldClose())
            {
                Vec2I screenCentre = (Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

                if (Raylib.IsKeyDown(KeyboardKey.W))
                    Camera.Current.rlCamera.Target -= Vector2.UnitY;
                if (Raylib.IsKeyDown(KeyboardKey.S))
                    Camera.Current.rlCamera.Target += Vector2.UnitY;
                if (Raylib.IsKeyDown(KeyboardKey.A))
                    Camera.Current.rlCamera.Target -= Vector2.UnitX;
                if (Raylib.IsKeyDown(KeyboardKey.D))
                    Camera.Current.rlCamera.Target += Vector2.UnitX;

                if (Raylib.GetMouseWheelMove() > 0)
                    Camera.Current.rlCamera.Zoom += 0.1f;
                if (Raylib.GetMouseWheelMove() < 0)
                    Camera.Current.rlCamera.Zoom -= 0.1f;

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
                    Entities.Update();

                    Raylib.EndMode2D();
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        public static void Log(params object[] objs) => StLogging.Log(objs);
    }

}
