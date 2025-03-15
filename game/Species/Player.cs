using Raylib_cs;
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
        private Sprite playerSprite;
        private int time;
        private Random rand = new();

        public override void Create()
        {
            playerSprite = new Sprite();
            playerSprite.Image = (StImage)Assets.Load<StImage>("player.png");

            Position = new Vector2(100, 100);
            AddComponent(playerSprite);
            Log("Player has been created");
        }

        public override void Update()
        {
            time++;
            if (time % 60 == 0)
            {
                Log("Updated player colour");
                playerSprite.Colour = new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255), 255);
                time = 0;
            }
        }
    }
}
