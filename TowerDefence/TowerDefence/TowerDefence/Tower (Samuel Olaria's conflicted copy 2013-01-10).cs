using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{

    public class Tower: Sprite
    {
        protected int cost;
        protected int damage;
        protected float radius;
        protected Enemy target;
        protected bool isAiming;
        protected Texture2D bulletTexture;

        protected float bulletTimer;
        protected List<Bullet> bulletList = new List<Bullet>();

        public Enemy Target
        {
            get { return target; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public float Radius
        {
            get { return radius; }
        }

        public virtual bool HasTarget
        {
            get { return target != null; }
        }

        public Tower(Texture2D texture,Texture2D bulletTexture,Vector2 position)
            : base(texture, position)
        {
            this.bulletTexture = bulletTexture;
        }

        public bool IsInRange(Vector2 position)
        {
            return Vector2.Distance(center, position) <= radius;
        }

        public virtual void GetClosestEnemy(List<Enemy> enemies)
        {
            target = null;
            float smallestRange = radius;

            foreach (Enemy enemy in enemies)
            {
                if (Vector2.Distance(center, enemy.Center) < smallestRange)
                {
                    smallestRange = Vector2.Distance(center, enemy.Center);
                    target = enemy;
                }
            }
        }

        protected void Facetarget()
        {
             Vector2 direction = center - target.Center;
             direction.Normalize();

             //rotation = (float)Math.Atan2(-direction.X, direction.Y);
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (target != null)
            {
                Facetarget();

                if (!IsInRange(target.Center)||target.IsDead)
                {
                    target = null;
                    bulletTimer = 0;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
