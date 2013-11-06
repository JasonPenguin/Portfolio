using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence.Resources
{
    public class Fonts
    {
        public static SpriteFont Arial;

        public static void Load()
        {
            Arial = Globals.Content.Load<SpriteFont>("Fonts\\Arial");
        }
    }
}
