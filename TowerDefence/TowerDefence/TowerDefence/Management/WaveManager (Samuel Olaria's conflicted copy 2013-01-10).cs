using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using TowerDefence.GUI;

namespace TowerDefence.Management
{
    public class WaveManager
    {
        private int numberOfWaves;
        private float timeSinceLastWave;

        private Queue<Wave> waves = new Queue<Wave>();

        private Texture2D enemyTexture;
        private bool waveFinished = false;

        private Level level;

        public Wave CurrentWave
        {
            get { return waves.Peek(); }
        }

        public List<Enemy> Enemies
        {
            get { return CurrentWave.Enemies; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }

        public WaveManager(Level level, int numberOfWaves, Texture2D enemyTexture,Texture2D menutex)
        {
            this.numberOfWaves = numberOfWaves;
            this.enemyTexture = enemyTexture;
            this.level = level;

            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 5;
                int numberModifier = (i / 6) + 1;

                Wave wave = new Wave(8, initialNumberOfEnemies * numberModifier, level, enemyTexture);
                //trapmenu = new TrapMenu(menutex,new Vector2(-100,0),traptextures);
                waves.Enqueue(wave);
            }

            waves.Peek().Start();
        }


        private void StartNextWave()
        {
            if (waves.Count > 0)
            {
                waves.Peek().Start();
                
                timeSinceLastWave = 0;
                waveFinished = false;
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentWave.Update(gameTime);
            //trapmenu.Update(gameTime);
            if (CurrentWave.RoundOver)
            {
                waveFinished = true;
            }

            if (waveFinished)
            {
                timeSinceLastWave += (float)gameTime.ElapsedGameTime.TotalSeconds;   
            }

            if (timeSinceLastWave > 5.0f)
            {
                waves.Dequeue();
                StartNextWave();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //trapmenu.Draw(spriteBatch);
            CurrentWave.Draw(spriteBatch);
        }
    }
}
