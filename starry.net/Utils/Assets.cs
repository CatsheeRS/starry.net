using Starry.NET.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Utils
{
    public static class Assets
    {
        internal static IAsset[] LoadedAssets = [];

        public static IAsset Load<T>(string path) where T : IAsset
        {
            if (LoadedAssets.Any(asset => asset.GetType() == typeof(T)))
                return LoadedAssets.First(asset => asset.GetType() == typeof(T));

            T asset = Activator.CreateInstance<T>(); //no idea what the fuck this is but

            asset.Load(Path.Combine(Starry.Settings.AssetPath, path));
            LoadedAssets = [.. LoadedAssets, asset];

            return asset;
        }
    }
}
