using Starry.NET.Objects;
using Starry.NET.Objects.Assets;
using Starry.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game.Species
{
    public class Player : Entity
    {
        public override void Create()
        {
            Sprite sprite = new Sprite();
            sprite.Image = (StImage)Assets.Load<StImage>("player.png");

            Position = new Vector2(100, 100);
            AddComponent(sprite);
            Log("Player has been created");
        }

        public override void Update()
        {
        }
    }
}
