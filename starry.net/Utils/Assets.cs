﻿using StarryNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNet.Utils
{
    public static class Assets
    {
        internal static IAsset[] LoadedAssets = new IAsset[0];

        public static T Load<T>(string path) where T : IAsset, new()
        {
            if (LoadedAssets.Any(asset => asset.GetType() == typeof(T)))
                return (T)LoadedAssets.First(asset => asset.GetType() == typeof(T));

            T asset = new();

            asset.Load(Path.Combine(Starry.Settings.AssetPath, path));
            LoadedAssets.Append(asset);

            return asset;
        }
    }
}
