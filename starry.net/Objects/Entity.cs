using Starry.NET.Utils.Entities;
using Starry.NET.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Starry.NET.Objects
{
    public class Entity
    {
        internal Component[] Components = Array.Empty<Component>();
        public EntityState State { get; internal set; }

        //TRANSDFORMATIONLOAIWEIYIINONOO STUFF
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; } = new Vector2(1,1);

        public virtual void Create() { }
        public virtual void Update() { }

        public Component AddComponent(Component component)
        {
            component.Entity = this;
            Components = [.. Components, component];
            component.Create();

            return component;
        }

        public T? GetComponent<T>() where T : Component
        {
            return Components.FirstOrDefault(c => c is T) as T;
        }

        protected static void Log(System.Drawing.Color color, params object[] objs) => Starry.Log(color, objs);
        protected static void Log(params object[] objs) => Starry.Log(objs);
    }
}
