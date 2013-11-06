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
    public class WaterWaveManager
    {
        private int numberOfWaves;
        private float timeSinceLastWave;

        public Queue<WaterWave> waves = new Queue<WaterWave>();


        private bool waveFinished = false;
        private Player player;
        private Level level;

        public WaterWave CurrentWave
        {
            get { return waves.Peek(); }
        }

        public List<Enemy> Enemies
        {
            get { return CurrentWave.Enemies; }
        }

        public bool WavesDone
        {
            get { return Textures.Waterenemies.Count == 0 && Textures.enemies.Count == 0; }
        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }

        public WaterWaveManager(Player player,Level level, int numberOfWaves)
        {
            this.numberOfWaves = numberOfWaves;
            this.level = level;
            this.player = player;
            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 2;
                int numberModifier = (i / 6) + 1;

                WaterWave wave = new WaterWave(player,1, initialNumberOfEnemies * numberModifier, level);
                waves.Enqueue(wave);
            }
        }

        private void StartNextWave()
        {
            if (waves.Count > 0)
            {
                waveFinished = false;
                waves.Peek().Start();
                timeSinceLastWave = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            //Starten van de waves en de pauzes daartussen
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
