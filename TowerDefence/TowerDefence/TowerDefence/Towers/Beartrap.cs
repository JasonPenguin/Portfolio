using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TowerDefence.Resources;
using TowerDefence.Management;

namespace TowerDefence.Towers
{
    public enum TrapStatus
    {
        On,
        Of,
        Available,
    }

    public class Beartrap : Tower
    {
        private Vector2[] directions = new Vector2[8];
        private List<Enemy> targets = new List<Enemy>();
        private List<Racoon> Racoontargets = new List<Racoon>();
        private MouseState previousState;

        public Beartrap(Texture2D texture, Vector2 position,int frames,int animations)
            : base(texture, position,frames,animations)
        {
            this.damage = 20;
            this.cost = 40;
            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.radius = 1000;
            this.bulletTexture = bulletTexture;
        }

        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            MouseState mouseState = Mouse.GetState();
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;
               
                foreach(Enemy enemy in Textures.enemies)
                {
                    targets.Add(enemy);
                }

                foreach (Enemy enemy in Textures.Waterenemies)
                {
                    targets.Add(enemy);
                }

                foreach(Racoon racoon in RacoonManager.racoons)
                {
                    Racoontargets.Add(racoon);
                }
                
                //loop door de verschillende enemies en geeft damage
                for (int t = 0; t < Textures.enemies.Count; t++)
                {
                    if (Vector2.Distance(animation.Position, Textures.enemies[t].animation.Position) < 3)
                    {
                        Textures.enemies[t].CurrentHealth -= damage;
                        break;
                    }
                }

                for (int w = 0; w < Textures.Waterenemies.Count; w++)
                {
                    if (Vector2.Distance(animation.Position, Textures.Waterenemies[w].animation.Position) < 6)
                    {
                        Textures.Waterenemies[w].CurrentHealth -= damage;
                        break;
                    }
                }

                for (int j = 0; j <RacoonManager.racoons.Count; j++)
                {
                    if (Vector2.Distance(animation.Position, RacoonManager.racoons[j].animation.Position) < 4)
                    {
                        RacoonManager.racoons[j].CurrentHealth -= damage;
                        break;
                    }
                }
                
                base.Update(gameTime);

                previousState = mouseState;
            
        }
    }
}
