using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;

using TowerDefence.GUI;
using TowerDefence.Resources;
using TowerDefence.Towers;

namespace TowerDefence.Management
{
    public class GameManager
    {
        private WaterWaveManager waterwaveManager;
        private WaveManager waveManager;
        public Trapshop shop;

        public static float TimetillStart;
        private float TimeSincelastWave;
        private List<Racoon> Racoons = new List<Racoon>();

        public bool wavesOver
        {
            get { return waveManager.CurrentWave.RoundOver && waterwaveManager.CurrentWave.RoundOver; }
        }

        public GameManager(Level level,WaterWaveManager watermanager, WaveManager normalmanager,Texture2D shopTexture)
        {
            this.waterwaveManager = watermanager;
            this.waveManager = normalmanager;
            shop = new Trapshop(shopTexture, new Vector2(910, 0));
        }

        private void Begin()
        {
            if (TimetillStart > 10 && TimetillStart < 11)
            {
                shop.hideShop();
            }

            if (TimetillStart < 10)
            {
                shop.showShop();
            }
        }
        
        private void StartNextWaves()
        {
            if (waveManager.waves.Count > 0 && waterwaveManager.waves.Count > 0)
            {
                shop.hideShop();
                waveManager.waves.Peek().Start();
                waterwaveManager.waves.Peek().Start();
                TimeSincelastWave = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            
            TimetillStart += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (TimetillStart < 12)
            {
                Begin();
            }

            shop.Update(gameTime);

            if (wavesOver)
            {
                Textures.enemies.Clear();
                Textures.Waterenemies.Clear();
                shop.showShop();
                TimeSincelastWave += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (TimeSincelastWave >= 17.0f)
            {
                StartNextWaves();
                shop.hideShop();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shop.Draw(spriteBatch);
        }


    }
}
