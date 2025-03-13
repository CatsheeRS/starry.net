using Starry.NET;
using static Starry.NET.Starry;
namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Load(new StarrySettings
            {
                onLoad = () => { 

                },
                assetPath = Path.GetFullPath("assets"),
                gameTitle = "spacestuff"
            });
        }
    }
}
