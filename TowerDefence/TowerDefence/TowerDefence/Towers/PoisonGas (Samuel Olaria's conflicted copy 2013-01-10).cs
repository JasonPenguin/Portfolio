using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Towers
{
    public class PoisonGas : Tower
    {
        private Vector2[] directions = new Vector2[8];
        private Texture2D poisonTexture;
        private List<Enemy> targets = new List<Enemy>();

        public override bool HasTarget
        {
            get
            {
                return false;
            }
        }
        public PoisonGas(Texture2D texture, Texture2D poisonTexture, Vector2 position)
            : base(texture, poisonTexture, position)
        {
            this.damage = 20;
            this.cost = 40;

            this.radius = 100;
            this.poisonTexture = poisonTexture;

            directions = new Vector2[]
            {
                new Vector2(-1,-1),
                new Vector2(0,-1),
                new Vector2(1,-1),
                new Vector2(-1,0),
                new Vector2(1,0),
                new Vector2(-1,1),
                new Vector2(0,1),
                new Vector2(1,1),
            };
        }

        public override void GetClosestEnemy(List<Enemy> enemies)
        {
            targets.Clear();

            foreach (Enemy enemy in enemies)
            {
                if(IsInRange(enemy.Center))
                {
                    targets.Add(enemy);
                }
            }
            base.GetClosestEnemy(enemies);
        }

        public override void Update(GameTime gameTime)
        {
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //kijken of het tijd is om te schieten
            if (bulletTimer >= 1.0f && targets.Count != 0)
            {
                for (int i = 0; i < directions.Length; i++)
                {
                    Bullet bullet = new Bullet(poisonTexture, Vector2.Subtract(center, new Vector2(poisonTexture.Width / 2)), directions[i], 1, damage);
                    bulletList.Add(bullet);
                }

                bulletTimer = 0;
            }

            //loop door de bullet list heen
            for (int i = 0; i < bulletList.Count; i++)
            {
                Bullet bullet = bulletList[i];
                bullet.Update(gameTime);

                if (!IsInRange(bullet.Center))
                {
                    bullet.Kill();
                }

                for (int t = 0; t < targets.Count; t++)
                {
                    if (targets[t] != null && Vector2.Distance(bullet.Center, targets[t].Center) < 12)
                    {
                        targets[t].CurrentHealth -= bullet.Damage;
                        bullet.Kill();
                        break;
                    }
                }

                if (bullet.IsDead())
                {
                    bulletList.Remove(bullet);
                    i--;
                }
            }
            base.Update(gameTime);
        }
    }
}
