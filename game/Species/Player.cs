using Starry.NET.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Species
{
    public class Player : Entity
    {
        public override void Create()
        {
            AddComponent(new Sprite());
            Log("Player has been created");
        }

        public override void Update()
        {
            Log("Player is updating");
        }
    }
}
