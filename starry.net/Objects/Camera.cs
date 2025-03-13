using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Objects
{
    public class Camera
    {
        public static Camera? Current { get; internal set; }
        internal Camera2D rlCamera;

        public static Vector2 screenCentre => new(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

    }
}
