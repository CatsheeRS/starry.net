using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Starry.NET.Objects
{
    public class Camera
    {
        public static Camera? Current { get; internal set; }
        internal Camera2D rlCamera;

        public static Vector2 screenCentre => new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

        public Camera()
        {
            if (Current == null)
            {
                Current = this;
                rlCamera = new Camera2D
                {
                    Target = new Vector2(0, 0),
                    Offset = new Vector2(screenCentre.X, screenCentre.Y),
                    Rotation = 0,
                    Zoom = 1
                };
            }
        }
    }
}
