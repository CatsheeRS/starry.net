using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Objects
{
    public class Component
    {
        public Entity Entity { get; internal set; }
        public bool Enabled { get; set; } = true;

        public virtual void Create() { }
        internal virtual void EarlyUpdate() { }
        public virtual void Update() { }
    }
}
