using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET
{
    public class StarrySettings
    {
        public required Action OnLoad;
        public required string AssetPath;
        public required string GameTitle;
    }
}
