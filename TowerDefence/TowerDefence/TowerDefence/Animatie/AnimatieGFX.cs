using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using TowerDefence.Animatie;
using TowerDefence.Resources;

namespace TowerDefence.Animatie
{
    
    public class AnimatieGFX
    {
        protected Rectangle bounds;
        protected SpriteAnimation animatie;
        protected AnimationClass anime;
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 center;


        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public Vector2 Position
        {
            get { return position; }
        }


        public AnimatieGFX(Texture2D tex,Vector2 pos)
        {
            this.texture = tex;
            this.position = pos;
            
            animatie = new SpriteAnimation(texture, 8, 1);
            anime = new AnimationClass();

            animatie.AddAnimation("flow", 1, 8, anime.Copy());
            animatie.Animation = "flow";
        }
        
        public virtual void Update(GameTime gameTime)
        {
            animatie.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            animatie.Draw(spriteBatch);
        }
    }

    
}
