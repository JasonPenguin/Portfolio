﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    /*Deze Bullet Class word niet meer gebruikt*/

    public class Bullet : Sprite
    {
        private int damage;
        private int age;
        private int speed;

        public int Damage
        {
            get { return damage; }
        }

        public bool IsDead()
        {
            return age > 100;
        }

        public void Kill()
        {
            this.age = 200;
        }


        public Bullet(Texture2D texture,Vector2 position,Vector2 velocity,int speed,int damage)
            :base(texture,position)
        {
            this.rotation = rotation;
            this.damage = damage;

            this.speed = speed;
            this.velocity = velocity * speed;
        }

        public void SetRotation(float value)
        {
            rotation = value;

            velocity = Vector2.Transform(new Vector2(0, -speed), Matrix.CreateRotationZ(rotation));
        }
        public override void Update(GameTime gameTime)
        {
            age++;
            position += velocity;

            base.Update(gameTime);
        }
    }
}
