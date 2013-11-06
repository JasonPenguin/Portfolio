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

    public class Tower: AnimateSprite
    {
        protected int cost;
        protected int damage;
        protected float radius;
        protected Enemy target;
        protected bool isAiming;
        protected Texture2D bulletTexture;
        protected float cooldown;
        protected float traptimer;

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

        public Tower(Texture2D texture,Vector2 position,int frames,int animations)
            : base(texture, position,frames,animations)
        {

        }

        public bool IsInRange(Vector2 position)
        {
            return Vector2.Distance(animation.Position, position) <= radius;
        }

        public virtual void GetClosestEnemy(List<Enemy> enemies)
        {
            target = null;
            float smallestRange = radius;
            //pakt de dichtsbijzijnde enemy en neemt het als target
            foreach (Enemy enemy in enemies)
            {
                if (Vector2.Distance(animation.Position, enemy.animation.Position) < 15)
                {
                    smallestRange = Vector2.Distance(animation.Position, enemy.animation.Position);
                    target = enemy;
                }
            }
        }


        protected void Facetarget()
        {
            //draai naar target toe
             Vector2 direction = animation.Position - target.animation.Position;
             direction.Normalize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;           
            if (target != null)
            {
                Facetarget();
                //als target uit range is of als target dood is
                
                if (!IsInRange(target.animation.Position)||target.IsDead)
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
                //teken bullets die in de bulletlist zitten
                bullet.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
