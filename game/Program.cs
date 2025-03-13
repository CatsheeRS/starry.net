using Starry.NET;
using Starry.NET.Objects;
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
                },
                AssetPath = Path.GetFullPath("assets"),
                GameTitle = "spacestuff"
            });
        }
    }
}
