using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;

namespace TowerDefence
{
    public class Wave
    {
        private int numOfEnemies;
        private int waveNumber;
        private float spawnTimer = 0;
        private int enemiesSpawned = 0;

        private bool enemyAtEnd;
        private bool spawingEnemies;
        private Level level;
        private Texture2D enemyTexture;
        public List<Enemy> enemies = new List<Enemy>();

        public bool RoundOver
        {
            get { return enemies.Count == 0 && enemiesSpawned == numOfEnemies; }
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
            get { return enemies; }
        }

        public Wave(int waveNumber, int numOfEnemies, Level level, Texture2D enemyTexture)
        {
            this.waveNumber = waveNumber;
            this.numOfEnemies = numOfEnemies;
            this.level = level;
            this.enemyTexture = enemyTexture;
        }

        private void AddEnemy()
        {
            Enemy enemy = new Enemy(level,enemyTexture,level.Waypoints.Peek(), 50, 1,1);
            enemy.SetWayPoints(level.Waypoints);
            Enemy waterenemy = new Enemy(level,enemyTexture, level.WaterWaypoints.Peek(), 50, 1,3);
            waterenemy.SetWaterWayPoints(level.WaterWaypoints);
            enemies.Add(waterenemy);
            enemies.Add(enemy);
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
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Update(gameTime);
                if (enemy.IsDead)
                {
                    if (enemy.CurrentHealth > 0)
                    {
                        enemyAtEnd = true;
                    }

                    enemies.Remove(enemy);
                    i--;
                }
            }         
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }

        }


    }
}
