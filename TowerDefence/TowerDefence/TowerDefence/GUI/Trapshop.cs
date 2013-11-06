using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using TowerDefence.Management;
using TowerDefence.Towers;
using TowerDefence.GUI;
using TowerDefence.Animatie;
using TowerDefence.Resources;

namespace TowerDefence.GUI
{
    public enum Visible
    {
        visible,
        invisible,
    }

    public class Trapshop : Sprite
    {
        private Visible status = Visible.invisible;

        public Trapshop(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
           
        }

        

        public void showShop()
        {
            Button.available = true;
            status = Visible.visible;
            position.Y = 350;
            position.X = 920;
        }

        public void hideShop()
        {
            position.Y = 250;
            position.X = 1000;
            Button.available = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (status == Visible.visible)
            {
                base.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
            
    }
}
