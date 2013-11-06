using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using TowerDefence.GUI;
using TowerDefence.Resources;

namespace TowerDefence.Management
{
    public class WaveManager
    {
        private int numberOfWaves;
        private float timeSinceLastWave;
        public Queue<Wave> waves = new Queue<Wave>();
        private Player player;

        private bool waveFinished = false;
        public Trapshop shop;

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

        public bool WavesDone
        {
            get { return Textures.Waterenemies.Count == 0 && Textures.enemies.Count == 0; }
        }

        public WaveManager(Player player,Level level, int numberOfWaves)
        {
            this.numberOfWaves = numberOfWaves;
            this.level = level;
            this.player = player;
            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 1;
                int numberModifier = (i / 6) + 1;

                Wave wave = new Wave(player,i, initialNumberOfEnemies * numberModifier, level);
                waves.Enqueue(wave);
            }
        }

        private void StartNextWave()
        {
            //start volgende wave 
            if (waves.Count > 0)
            {
                waveFinished = false;
                waves.Peek().Start();
                timeSinceLastWave = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (GameManager.TimetillStart > 10)
            {
                CurrentWave.Update(gameTime);
            }
            
            if (WavesDone)
            {
                waveFinished = true;
            }

            if (waveFinished)
            {
                timeSinceLastWave += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (timeSinceLastWave >= 7.0f)
            {
                waves.Dequeue();
                StartNextWave();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentWave.Draw(spriteBatch);
        }
    }
}
