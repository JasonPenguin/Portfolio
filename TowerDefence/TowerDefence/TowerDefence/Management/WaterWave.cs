using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;

using TowerDefence.Resources;

namespace TowerDefence.Management
{
    public class WaterWave
    {
        private int numOfEnemies;
        private int waveNumber;
        private float spawnTimer = 0;
        private int enemiesSpawned = 0;
        private Player player;
        private bool enemyAtEnd;
        public static bool spawingEnemies;
        private Level level;

        public bool RoundOver
        {
            get { return Textures.Waterenemies.Count == 0 && enemiesSpawned == numOfEnemies; }
        }

        public int RoundNumber
        {
            get { return waveNumber; }
        }

        public bool EnemyAtEnd
        {
            get { return enemyAtEnd; }
            set { enemyAtEnd = value; }
        }

        public List<Enemy> Enemies
        {
            get { return Textures.Waterenemies; }
        }

        public WaterWave(Player player,int waveNumber, int numOfEnemies, Level level)
        {
            this.player = player;
            this.waveNumber = waveNumber;
            this.numOfEnemies = numOfEnemies;
            this.level = level;
        }

        private void AddEnemy()
        {
            Enemy waterenemy = new Enemy(Textures.FrogTex, level, level.WaterWaypoints.Peek(),40,15, 1, 9, 1);
            waterenemy.SetWaterWayPoints(level.WaterWaypoints);
            Textures.Waterenemies.Add(waterenemy);
            spawnTimer = 0;

            enemiesSpawned++;
        }

        public void Start()
        {
            spawingEnemies = true;
        }

        public void Stop()
        {
            spawingEnemies = false;
        }

        public void Restart()
        {
            enemiesSpawned = numOfEnemies;
        }

        public void Update(GameTime gameTime)
        {
            //enemy toevoegen aan de list
            if (enemiesSpawned == numOfEnemies)
            {
                spawingEnemies = false;
            }

            if (spawingEnemies)
            {
                spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (spawnTimer > 2)
                    AddEnemy();
            }



            //kijken of een enemy in de list dood is
            for (int i = 0; i < Textures.Waterenemies.Count; i++)
            {
                Enemy enemy = Textures.Waterenemies[i];
                enemy.Update(gameTime);
                if (enemy.IsDead)
                {
                    if (enemy.CurrentHealth > 0)
                    {
                        enemyAtEnd = true;
                        player.Lives -= 1;
                    }

                    else
                    {
                        player.Money += enemy.MoneyGiven;
                    }

                    Textures.Waterenemies.Remove(enemy);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Textures.Waterenemies)
            {
                enemy.Draw(spriteBatch);
            }

        }


    }
}
