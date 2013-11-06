using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;

namespace TowerDefence.Resources
{
    public class Globals
    {
        //global variablen
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
        public static SpriteBatch SpriteBatch;
        public static GameTime GameTime;
        public static Boolean WindowsFocused;
        public static Vector2 GameSize;
        public static RenderTarget2D BackBuffer;

    }
}
