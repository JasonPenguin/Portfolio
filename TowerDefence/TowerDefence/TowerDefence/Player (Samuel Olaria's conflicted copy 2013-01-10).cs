using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using TowerDefence.Animatie;
using TowerDefence.Towers;
using TowerDefence.Tiles;
using TowerDefence.Resources;

namespace TowerDefence
{
    public class Player
    {
        private int money = 300;
        private int lives = 30;
        private Level level;

        private List<Tower> towers = new List<Tower>();

        private MouseState mouseState;
        private MouseState oldState;
        private Texture2D[] towerTextures;
        private Texture2D[] bulletTextures;

        private string newTowerType;

        public string NewTowerType
        {
            set { newTowerType = value; }
        }

        public int Money
        {
            get { return money; }
        }

        public int Lives
        {
            get { return lives; }
        }

        public Player(Level level,Texture2D[] towerTextures,Texture2D[] bulletTextures)
        {
            this.level = level;
            this.towerTextures = towerTextures;
            this.bulletTextures = bulletTextures;
        }

        private int cellX;
        private int cellY;

        private int tileX;
        private int tileY;

        public void Update(GameTime gameTime, List<Enemy> enemies)
        {

            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 84);
            cellY = (int)(mouseState.Y / 84);

            tileX = cellX * 84;
            tileY = cellY * 84;

            if (mouseState.LeftButton == ButtonState.Released &&
                oldState.LeftButton == ButtonState.Pressed)
            {
                //als NewTowerType text bevat
                if (string.IsNullOrEmpty(newTowerType) == false)
                    AddTower();
            }

            oldState = mouseState;

            foreach (Tower tower in towers)
            {
                if (tower.HasTarget == false)
                {
                    tower.GetClosestEnemy(enemies);
                }
                tower.Update(gameTime);
            }
        }

        public void AddTower()
        {
            Tower towerToAdd = null;

            switch (newTowerType)
            {
                case "Arrow Tower":
                    {
                        towerToAdd = new PoisonGas(towerTextures[0], bulletTextures[0], new Vector2(tileX, tileY));
                        break;
                    }
                case "Poison Gas":
                    {
                        towerToAdd = new PoisonGas(towerTextures[1],bulletTextures[0],new Vector2(tileX,tileY));
                        break;
                    }
                    
            }

            if (IsCellClear() == true && towerToAdd.Cost <= money)
            { 
                towers.Add(towerToAdd);
                money -= towerToAdd.Cost;

                newTowerType = string.Empty;
            }
   
        }

        private bool IsCellClear()
        {
            bool inBounds = cellX >= 0 && cellY >= 0 &&
                cellX < level.Width && cellY < level.Heigth;

            bool spaceClear = true;

            foreach (Tower tower in towers)
            {
                spaceClear = (tower.Position != new Vector2(tileX, tileY));
                
                if (!spaceClear)
                    break;
            }

            bool onPath = (level.GetIndex(cellX,cellY) != -1);

            return inBounds && spaceClear && onPath;
        }

        public void ResetTowers()
        {
            towers.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tower tower in towers)
            {
                tower.Draw(spriteBatch);
            }

        }
    }
}
