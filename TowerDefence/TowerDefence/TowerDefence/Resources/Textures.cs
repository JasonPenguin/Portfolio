using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using TowerDefence.Management;
using TowerDefence.Towers;
using TowerDefence.GUI;
using TowerDefence.Animatie;

namespace TowerDefence.Resources
{
    /*in deze class worden variablen 
     * gedefineerdt en worden de textures geladen
     * */
    public class Textures
    {
        public static Level level = new Level("level_01");
        public static Player player;
        public static WaveManager waveManager;
        public static WaterWaveManager waterWavemanager;
        public static Toolbar toolbar;
        public static Button Flytrap;
        public static Button BearTrap;
        public static Button ElecFence;
        public static Button BaseballBat;
        public static Texture2D FrogTex;
        public static Texture2D RacoonTex;
        public static Texture2D BatTex;
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Enemy> Waterenemies = new List<Enemy>();
        public static GameManager gamemanager;
        public static RacoonManager racoonmanager;
        public static Texture2D life;
        public static Song IngameMusic;
        public static Texture2D Livedecay;
        public static Texture2D background;
        public static Texture2D foreground;
        public static Texture2D lose;
        public static Texture2D win;
        public static Texture2D startscherm;


        public static void Load()
        {
            background = Globals.Content.Load<Texture2D>("Map\\BG\\OtherLayer");
            foreground = Globals.Content.Load<Texture2D>("Map\\BG\\Planklayer");
            IngameMusic = Globals.Content.Load<Song>("Hillbilly Bill");

            lose = Globals.Content.Load<Texture2D>("GFX\\screens\\lose");
            win = Globals.Content.Load<Texture2D>("GFX\\screens\\win");
            startscherm = Globals.Content.Load<Texture2D>("GFX\\screens\\startscherm");

            MediaPlayer.Volume = 0.5f;
            
            MediaPlayer.Play(IngameMusic);
            MediaPlayer.IsRepeating = true;
            
            Texture2D life = Globals.Content.Load<Texture2D>("GUI\\Lifes\\HouseDecay");
            Texture2D grass = Globals.Content.Load<Texture2D>("GUI\\path");
            Texture2D pad = Globals.Content.Load<Texture2D>("pad");
            Texture2D Water = Globals.Content.Load<Texture2D>("GFX\\Tiles\\Waterp");

            Texture2D PadV = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp");
            Texture2D PadH = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testp2");

            Texture2D lily1 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb");
            Texture2D lily2 = Globals.Content.Load<Texture2D>("GFX\\Tiles\\testb2");

            Texture2D StatsWindow = Globals.Content.Load<Texture2D>("GUI\\Currency\\StatWindow3");
            Texture2D Enter2Play = Globals.Content.Load<Texture2D>("Enter");
            Texture2D Trapmenu = Globals.Content.Load<Texture2D>("GUI\\TrapMenu\\BuyTab3");

            Texture2D arrowNormal = Globals.Content.Load<Texture2D>("GUI\\Toren");
            Texture2D arrowHover = Globals.Content.Load<Texture2D>("GUI\\arrow_hover");
            Texture2D arrow_pressed = Globals.Content.Load<Texture2D>("GUI\\arrow_pressed");

            Texture2D gasTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\Trap_Poinsion_gas");
            Texture2D fenceTrap = Globals.Content.Load<Texture2D>("GFX\\Traps\\fence");
            Livedecay = Globals.Content.Load<Texture2D>("GUI\\Currency\\HouseDecay");
            Texture2D PsnNormal = Globals.Content.Load<Texture2D>("Traps\\spike tower");
            Texture2D PsnHover = Globals.Content.Load<Texture2D>("Traps\\spike hover");
            Texture2D PsnPressed = Globals.Content.Load<Texture2D>("Traps\\spike tower");
            FrogTex = Globals.Content.Load<Texture2D>("GFX\\Mobs\\Frog\\Frogspripfront");
            RacoonTex = Globals.Content.Load<Texture2D>("GFX\\Mobs\\Racoon\\RacoonStrip");
            BatTex = Globals.Content.Load<Texture2D>("GFX\\Mobs\\Bat\\Batstripfront_84bij122");
            SpriteFont font = Globals.Content.Load<SpriteFont>("Fonts\\Arial");

            
            MediaPlayer.Volume = 0.9f;

  
            Texture2D[] towertextures = new Texture2D[]
            {
                Globals.Content.Load<Texture2D>("GFX\\Traps\\Beartrap\\waffle_trap_strip"),
                Globals.Content.Load<Texture2D>("GFX\\Traps\\FenceTrap\\electricfence_sheet"),
                Globals.Content.Load<Texture2D>("GFX\\Traps\\FlyTrap\\fly_trap_168x256"),
                Globals.Content.Load<Texture2D>("GFX\\Traps\\Baseballbat\\baseball"),
            };

           
            
            player = new Player(level, towertextures);
            waveManager = new WaveManager(player,level, 25);
            waterWavemanager = new WaterWaveManager(player,level,25);
            toolbar = new Toolbar(StatsWindow, font, new Vector2(10,2));
            ElecFence = new Button(grass, grass, grass, new Vector2(940, 360), player, "BaseballBat");
            Flytrap = new Button(grass, grass, grass, new Vector2(940, 433), player, "Fly Trap");
            BearTrap = new Button(grass, grass, grass, new Vector2(940, 495), player, "Fence");
            BaseballBat = new Button(grass, grass, grass, new Vector2(940, 575), player, "Bear Trap");
            gamemanager = new GameManager(level,waterWavemanager, waveManager, Trapmenu);
            racoonmanager = new RacoonManager(level,RacoonTex,player);
        }

    }
}
