﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace TowerDefence
{
    public enum VisibleStatus
    {
        Visible,
        Invisible,
    }

    public class Enemy:Sprite
    {
        protected float startHealth;
        protected float currentHealth;

        protected bool alive = true;

        protected int speed = 5;
        protected int moneyGiven;

        private Rectangle bounds;

        private VisibleStatus status = VisibleStatus.Visible;
        private Level level;

        private Queue<Vector2> waypoints = new Queue<Vector2>();

        
        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public bool IsDead
        {
            get { return !alive; }
        }

        public int MoneyReward
        {
            get { return moneyGiven; }
        }

        public Enemy(Level level, Texture2D texture, Vector2 position, float health, int moneyGiven, int speed)
            : base(texture, position)
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

            this.position = this.waypoints.Dequeue();
        }

        public void SetWaterWayPoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            this.position = this.waypoints.Dequeue();
        }

        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < speed)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                    
                }

                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();

                    velocity = Vector2.Multiply(direction, speed);
                    position += velocity;
                }
            }
            else
                alive = false;
            if (currentHealth <= 0)
                alive = false;

            if (bounds.Intersects(level.Bounds))
            {
                status = VisibleStatus.Invisible;
                
            }
                
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (status == VisibleStatus.Visible)
            {
                base.Draw(spriteBatch);
            }
            
        }
    }
}
