using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using TowerDefence.GUI;
using TowerDefence.Resources;

namespace TowerDefence.Management
{
    public class RacoonManager
    {
        public static List<Racoon> racoons = new List<Racoon>();
        private Texture2D racoon_tex;
        float spawnTimer = 0;
        private bool spawing_racoons;
        private Level level;
        private Player player;
        

        public RacoonManager(Level level,Texture2D tex,Player player)
        {
            this.player = player;
            this.level = level;
            this.racoon_tex = tex;
            Start();
        }

        private void SpawnRacoon()
        {
            Racoon racoon = new Racoon(Textures.RacoonTex, level, level.Plankwaypoints_left.Peek(),10,40,3, 9, 1);
            racoon.SetWayPoints(level.Plankwaypoints_left);
            racoons.Add(racoon);
            spawnTimer = 0;
            
        }

        public void Start()
        {
            spawing_racoons = true;
        }

        public void Stop()
        {
            spawing_racoons = false;
        }

        public void Update(GameTime gameTime)
        {
            //spawnen en verwijderen van de racoons
            if (spawing_racoons)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer > 20)
                    SpawnRacoon();
            }

            for (int i = 0; i < racoons.Count; i++)
            {
                Racoon racoon = racoons[i];
                racoon.Update(gameTime);
                
                if (racoon.IsDead)
                {
                    racoons.Remove(racoon);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Racoon racoon in racoons)
            {
                racoon.Draw(spritebatch);
            }
        }
    }
}
