using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TowerDefence.Resources;
using TowerDefence.Animatie;
using Microsoft.Xna.Framework;

namespace TowerDefence
{
    public class Enemy:AnimateSprite
    {
        protected float startHealth;
        protected float currentHealth;

        protected bool alive = true;

        protected int speed = 5;
        protected int moneyGiven;
      
        private Level level;
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        public static Texture2D[] texs;
        //private Texture2D[] textures;
        
        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public bool IsDead
        {
            get { return !alive; }
        }

        public int MoneyGiven
        {
            get { return moneyGiven; }
        }

        public Enemy(Texture2D texture, Level level, Vector2 position,float health, int moneyGiven, int speed,int frames,int animations)
            : base(texture, position,frames,animations)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.moneyGiven = moneyGiven;
            this.speed = speed;
            this.level = level;
            
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void SetWayPoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            
            animation.Position = this.waypoints.Dequeue();
           
        }

        public void SetWaterWayPoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            animation.Position = this.waypoints.Dequeue();
            
        }

        public float DistanceToDestination
        {
            get { return Vector2.Distance(animation.Position, waypoints.Peek()); }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (waypoints.Count > 0)
            {
                //als er nog waypoints zijn worden ze gevold door enemy
                if (DistanceToDestination < speed)
                {
                    animation.Position = waypoints.Peek();
                    waypoints.Dequeue();
                }

                
                else
                {
                    Vector2 direction = waypoints.Peek() - animation.Position;
                    direction.Normalize();

                    velocity = Vector2.Multiply(direction, speed);
                    animation.Position += velocity;
                }
            }
                //als er geen waypoints meer over zijn worden ze voor Dood verklaart
            else
                alive = false;
            if (currentHealth <= 0)
            {
                alive = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
            
        }

       
    }
}
