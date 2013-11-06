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

namespace TowerDefence
{
    public class Sprite
    {
        //sprite properties
        protected Texture2D texture;
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

        public Sprite(Texture2D tex, Vector2 pos)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
        }

        public virtual void Update(GameTime gameTime)
        {
            //Middenpunt op zijn plek houden
            this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White, rotation,
                origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
