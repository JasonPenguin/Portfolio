using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

using TowerDefence.Animatie;
using TowerDefence.Management;
using TowerDefence.Resources;
using TowerDefence.GUI;

namespace TowerDefence
{
    public class AnimateSprite
    {
        protected Texture2D texture;
        public SpriteAnimation animation;
        protected AnimationClass anime;
        public Rectangle bounds;
        protected Vector2 position;
        protected Vector2 velocity;

        protected Vector2 center;
        protected Vector2 origin;

        protected float rotation;

        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public Vector2 Center
        {
            get { return center; }
        }

        public AnimateSprite(Texture2D tex, Vector2 pos,int frames,int animations)
        {
            texture = tex;
            //position = pos;
            velocity = Vector2.Zero;

            anime = new AnimationClass();
            animation = new SpriteAnimation(texture,frames,animations);
            animation.Position = pos;
            animation.AddAnimation("normal",1,frames,anime.Copy());
            animation.Animation = "normal";
            bounds = animation.Bounds;
            origin = new Vector2(animation.width / 2, animation.height / 2);
            //bounds = new Rectangle((int)position.X, (int)position.Y, animation.width,animation.height);
        }

        public virtual void Update(GameTime gameTime)
        {
            animation.CenterPosition = new Vector2(animation.Position.X + animation.width / 2, animation.Position.Y + animation.height / 2);
            animation.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
        }
    }
}
