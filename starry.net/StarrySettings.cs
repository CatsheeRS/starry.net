using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET
{
    public class StarrySettings
    {
        public required Action onLoad;
        public required string assetPath;
        public required string gameTitle;
    }
}
