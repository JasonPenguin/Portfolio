using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TowerDefence.GUI
{
    public class TrapMenu:Sprite
    {
        private Texture2D[] traptextures;

        public bool showMenu;
        public bool hideMenu;

        public TrapMenu(Texture2D texture,Vector2 position,Texture2D[] traptextures)
            :base(texture,position)
        {
            this.position = position;
            this.texture = texture;
            this.traptextures = traptextures;
        }

        public void ShowMenu()
        {
            if (showMenu)
            {
                position.X = 0;
                if (position.X <= 0)
                {
                    position.X = 0;
                }
            }

        }

        public void HideMenu()
        {
            if (hideMenu)
            {
                position.X = -100;
            }
        }

        /*public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (showMenu)
            {
                ShowMenu();
            }
            if (hideMenu)
            {
                HideMenu();
            }
            
        }*/

        
    }
}
