using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Animatie
{
    public class SpriteManager
    {
        public Texture2D Texture;
        public Vector2 CenterPosition;
        public Vector2 Position;
        public Vector2 Origin;
        public Rectangle Bounds;
        public SpriteEffects SpriteEffect;
        protected Dictionary<string, AnimationClass> Animations = new Dictionary<string, AnimationClass>();
        protected int FrameIndex = 0;
        
        public int height;
        public int width;

        private string animation;
        public string Animation
        {
            get { return animation; }
            set
            {
                animation = value;
                FrameIndex = 0;
            }
        }


        public SpriteManager(Texture2D Texture,int Frames,int animations)
        {
            //texture delen in frames 
            this.Texture = Texture;
            width = Texture.Width / Frames;
            height = Texture.Height / animations;

            CenterPosition = new Vector2(Position.X + width / 2, Position.Y + height / 2);
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, width, height);
            Origin = new Vector2(width / 2, height / 2);
        }

        public void AddAnimation(string name, int row,int frames,AnimationClass animation)
        {
            //animatie toevoegen
            Rectangle[] recs = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                recs[i] = new Rectangle(i * width, (row - 1) * height, width, height);
            }
           
            animation.Frames = frames;
            animation.Rectangles = recs;
            Animations.Add(name, animation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,CenterPosition,
                Animations[Animation].Rectangles[FrameIndex],
                Animations[Animation].Color,
                Animations[Animation].Rotation,Origin,
                Animations[Animation].Scale,
                Animations[Animation].SpriteEffect, 0f);
        }
    }
}
