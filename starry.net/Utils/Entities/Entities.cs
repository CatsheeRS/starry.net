using StarryNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryNet.Utils.Entities
{
    public static class Entities
    {
        internal static Entity[] EntityList = Array.Empty<Entity>();

        public static void Create(Entity entity)
        {
            entity.State = EntityState.Borning;
            EntityList = [.. EntityList, entity];
            entity.Create();

            entity.State = EntityState.Living;
        }

        public static void Update()
        {
            Parallel.ForEach(EntityList, entity =>
            {
                foreach (var component in entity.Components)
                {
                    component.EarlyUpdate();
                }

                entity.Update();
                foreach (var component in entity.Components)
                {
                    component.Update();
                }
            });
        }
    }

    public enum EntityState
    {
        Borning,
        Living,
        Dying
    }
}
