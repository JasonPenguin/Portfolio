using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;

using TowerDefence.Management;
using TowerDefence.Resources;

namespace TowerDefence.GUI
{
    public class Toolbar
    {
        private Texture2D texture;
        private SpriteFont font;

        private Vector2 position;
        private Vector2 textPosition;
        


        public Toolbar(Texture2D texture, SpriteFont font, Vector2 position)
        {
            this.texture = texture;
            this.font = font;

            this.position = position;

            textPosition = new Vector2(70, position.Y + 20);
        }

        

        public void Draw(SpriteBatch spriteBatch, Player player)
        {
            spriteBatch.Draw(texture, position, Color.White);

            string text = string.Format(": {0}      lives : {1}",player.Money,player.Lives);
            spriteBatch.DrawString(font, text, textPosition, Color.White);
        }
    }
}
