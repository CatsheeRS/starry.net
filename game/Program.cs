using Game.Species;
using Starry.NET;
using Starry.NET.Objects;
using Starry.NET.Utils.Entities;
using static Starry.NET.Starry;
namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Load(new StarrySettings
            {
                OnLoad = () => {
                    Camera cam = new();
                    Entities.Create(new Player());
                },
                AssetPath = Path.GetFullPath("assets"),
                GameTitle = "spacestuff"
            });
        }
    }
}
