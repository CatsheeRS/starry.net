using Raylib_cs;
using StarryNet;
using StarryNet.Objects;
using StarryNet.Objects.Assets;
using StarryNet.Utils;
using StarryNet.Utils.Networking;
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

        private bool addingScale = true;
        public override void Create()
        {
            playerSprite = new Sprite();
            playerSprite.Image = Assets.Load<StImage>("player.png");

            Scale = new Vector2(0.01f, 0.01f);
            Position = new Vector2(100, 100);
            AddComponent(playerSprite);
            Log("Player has been created");
            Log("Trying to connect to server...");

            Client.Connect("127.0.0.1", Starry.NET.Starry.Settings.Port);

            Log("Should have connected to server wowie :D");
        }

        public override void Update()
        {
            if (Rotation >= 360)
                Rotation = 0;

            Rotation++;
            Scale += new Vector2(.001f, .001f);

            if (Raylib.IsKeyDown(KeyboardKey.F) && Client.Connected())
            {
                Client.SendMessage("player.sayHi", "meow");
            }
        }
    }
}
