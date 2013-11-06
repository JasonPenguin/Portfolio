using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using TowerDefence.Management;
using TowerDefence.Towers;
using TowerDefence.GUI;
using TowerDefence.Screens;
using TowerDefence.Animatie;
using TowerDefence.Tiles;

namespace TowerDefence.Resources
{
    public class Textures
    {
        public static Level level = new Level("level_01");
        public static Player player;
        public static WaveManager waveManager;
        public static Toolbar toolbar;
        public static MenuScreen menuScreen;
        public static Button arrowButton;
        public static Button PsnGasButton;
        public static Tile waterTestTile;
        public static Texture2D[] TileTextures;
        public static List<Tile> tiles = new List<Tile>();
        

        public static void Load()
        {
            Texture2D grass = Globals.Content.Load<Texture2D>("grass");
            Texture2D pad = Globals.Content.Load<Texture2D>("pad");
            Texture2D Water = Globals.Content.Load<Texture2D>("GFX\\Tiles\\Waterp");

            Texture2D PadV = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp");
            Texture2D PadH = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp2");

            Texture2D lily1 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb");
            Texture2D lily2 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb2");

            Texture2D enemyTexture = Globals.Content.Load<Texture2D>("GFX\\Mobs\\bug");

            Texture2D Bar = Globals.Content.Load<Texture2D>("Bar");
            Texture2D Enter2Play = Globals.Content.Load<Texture2D>("Enter");
            Texture2D Trapmenu = Globals.Content.Load<Texture2D>("GUI\\TrapMenu\\Menubar");

            Texture2D arrowNormal = Globals.Content.Load<Texture2D>("GUI\\Toren");
            Texture2D arrowHover = Globals.Content.Load<Texture2D>("GUI\\arrow_hover");
            Texture2D arrow_pressed = Globals.Content.Load<Texture2D>("GUI\\arrow_pressed");

            Texture2D gasTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\Trap_Poinsion_gas");
            Texture2D fenceTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\fence");

            Texture2D PsnNormal = Globals.Content.Load<Texture2D>("Traps\\spike tower");
            Texture2D PsnHover = Globals.Content.Load<Texture2D>("Traps\\spike hover");
            Texture2D PsnPressed = Globals.Content.Load<Texture2D>("Traps\\spike tower");

            SpriteFont font = Globals.Content.Load<SpriteFont>("Fonts\\Arial");

            /*level.AddTexture(pad);//1
            level.AddTexture(Water);//2

            level.AddTexture(lily1);//3
            level.AddTexture(lily2);//4
            
            level.AddTexture(PadH);//5
            level.AddTexture(PadV);//6*/

            Texture2D[] towertextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Traps\\fence"),
                Globals.Content.Load<Texture2D>("GFX\\Traps\\Trap_Poinsion_gas")
            };

            Texture2D[] bullettextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("Bulletsprite")
            };

            TileTextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("watertiles"),
                Globals.Content.Load<Texture2D>("grastiles")
            };



            waveManager = new WaveManager(level, 5, enemyTexture,Trapmenu);
            player = new Player(level, towertextures, bullettextures);
            toolbar = new Toolbar(Bar, font, new Vector2(0, level.Heigth * 84));
            menuScreen = new MenuScreen(Enter2Play, new Vector2(400, 300));
            arrowButton = new Button(fenceTrap, fenceTrap, fenceTrap, new Vector2(84,684),player,"Arrow Tower");
            PsnGasButton = new Button(gasTrap, gasTrap, gasTrap, new Vector2(0,684), player,"Poison Gas");
            waterTestTile = new Tile(TileTextures[0], new Vector2(200, 200));
        }

        public static void Animate()
        {
            for (int i = 0; i < 50; i++)
            {
                Tile tile = new Tile(TileTextures[0], new Vector2(200, 200));
                tiles.Add(tile);
            }

            foreach (Tile t in tiles)
            {
                t.Update(Globals.GameTime);
            }
        }
    }
}
