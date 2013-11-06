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
        public static WaterWaveManager waterWavemanager;
        public static Toolbar toolbar;
        public static MenuScreen menuScreen;
        public static Button arrowButton;
        public static Button PsnGasButton;
        public static Tile waterTestTile;
        public static Texture2D[] TileTextures;
        public static List<Tile> tiles = new List<Tile>();
        public static AnimateSprite blabla;
        public static Texture2D[] FrogTextures;
        public static Texture2D[] BatTextures;
        public static Texture2D blatex;
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Enemy> Waterenemies = new List<Enemy>();
        public static GameManager gamemanager;
        public static RacoonManager racoonmanager;

        public static void Load()
        {
            Texture2D grass = Globals.Content.Load<Texture2D>("grass");
            Texture2D pad = Globals.Content.Load<Texture2D>("pad");
            Texture2D Water = Globals.Content.Load<Texture2D>("GFX\\Tiles\\Waterp");

            Texture2D PadV = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp");
            Texture2D PadH = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp2");

            Texture2D lily1 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb");
            Texture2D lily2 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb2");

            Texture2D StatsWindow = Globals.Content.Load<Texture2D>("GUI\\Currency\\StatsWindow");
            Texture2D Enter2Play = Globals.Content.Load<Texture2D>("Enter");
            Texture2D Trapmenu = Globals.Content.Load<Texture2D>("GUI\\TrapMenu\\BuyTab");

            Texture2D arrowNormal = Globals.Content.Load<Texture2D>("GUI\\Toren");
            Texture2D arrowHover = Globals.Content.Load<Texture2D>("GUI\\arrow_hover");
            Texture2D arrow_pressed = Globals.Content.Load<Texture2D>("GUI\\arrow_pressed");

            Texture2D gasTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\Trap_Poinsion_gas");
            Texture2D fenceTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\fence");

            Texture2D PsnNormal = Globals.Content.Load<Texture2D>("Traps\\spike tower");
            Texture2D PsnHover = Globals.Content.Load<Texture2D>("Traps\\spike hover");
            Texture2D PsnPressed = Globals.Content.Load<Texture2D>("Traps\\spike tower");
            blatex = Globals.Content.Load<Texture2D>("grastiles");
            
            SpriteFont font = Globals.Content.Load<SpriteFont>("Fonts\\Arial");

            level.AddTexture(pad);
            level.AddTexture(Water);

            level.AddTexture(lily1);
            level.AddTexture(lily2);
            
            level.AddTexture(PadH);
            level.AddTexture(PadV);
  
            Texture2D[] towertextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Traps\\GasTrap\\gas1"),
                Globals.Content.Load<Texture2D>("GFX\\Traps\\Trap_Poinsion_gas")
            };

            Texture2D[] bullettextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Traps\\GasTrap\\G13")
            };

            TileTextures = new Texture2D[]
            {
                /*Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb"),
                Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb2"),
                Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp"),
                Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp2")*/

                Globals.Content.Load<Texture2D>("watertiles"),
                Globals.Content.Load<Texture2D>("grastiles")
            };

            FrogTextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0001"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0002"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0003"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0004"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0005"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0006"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0007"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0008"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0009"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\frogfront0010"),
            };

            BatTextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0001"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0002"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0003"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0004"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0005"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0006"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0007"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0008"),
                Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Bat0009")
            };
            
            waveManager = new WaveManager(level, 10, FrogTextures[0]);
            waterWavemanager = new WaterWaveManager(level,10, BatTextures[0]);
            player = new Player(level, towertextures, bullettextures);
            toolbar = new Toolbar(StatsWindow, font, new Vector2(500,550));
            menuScreen = new MenuScreen(Enter2Play, new Vector2(400, 300));
            arrowButton = new Button(grass,grass,grass, new Vector2(925,20),player,"Arrow Tower");
            PsnGasButton = new Button(grass,grass,grass, new Vector2(925,1), player,"Poison Gas");
            gamemanager = new GameManager(level,waterWavemanager, waveManager, Trapmenu);
            blabla = new AnimateSprite(blatex, new Vector2(100, 100),8,1);
            racoonmanager = new RacoonManager(level, blatex,player);
        }

        public static void Update(GameTime gametime)
        {
            blabla.Update(gametime);
        }

    }
}
