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
using TowerDefence.Resources;
using TowerDefence.GUI;
using TowerDefence.Management;

namespace TowerDefence
{
    public enum Updating
    {
        update,
        Notupdate,
    }

    public class Player
    {
        private int money = 100;
        public static int lives = 10;
        private Level level;
        private int pathttype;
        public static List<Tower> towers = new List<Tower>();

        private MouseState mouseState;
        private MouseState oldState;
        private Texture2D[] towerTextures;

        private string newTowerType;
        private Updating status = Updating.update;

        public string NewTowerType
        {
            set { newTowerType = value; }
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public Player(Level level,Texture2D[] towerTextures)
        {
            this.level = level;
            this.towerTextures = towerTextures;
        }

        private int cellX;
        private int cellY;

        private int tileX;
        private int tileY;
        
        public void Update(GameTime gameTime, List<Enemy> enemies,List<Enemy> waterenemies)
        {
            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 84);
            cellY = (int)(mouseState.Y / 84);

            tileX = cellX * 84;
            tileY = cellY * 84;

            if (status == Updating.update)
            {
                
                if (Button.available == true)
                {
                    if (mouseState.LeftButton == ButtonState.Released &&
                    oldState.LeftButton == ButtonState.Pressed)
                    {
                        //als NewTowerType text bevat
                        if (string.IsNullOrEmpty(newTowerType) == false)
                            AddTower();
                    }
                }
                oldState = mouseState;
                
            }

            foreach (Tower tower in towers)
            {
                if (tower.HasTarget == false)
                {
                    tower.GetClosestEnemy(enemies);
                    tower.GetClosestEnemy(waterenemies);
                }
                tower.Update(gameTime);
            }
        }

        public void AddTower()
        {
            Tower towerToAdd = null;

            switch (newTowerType)
            {
                case "Bear Trap":
                    {
                        towerToAdd = new Beartrap(towerTextures[0], new Vector2(tileX, tileY), 9, 1);
                        pathttype = 1;
                        break;
                    }
                case "Fence":
                    {
                        towerToAdd = new Beartrap(towerTextures[1], new Vector2(tileX, tileY), 6, 1);
                        pathttype = 3;
                        break;
                    }
                case "Fly Trap":
                    {
                        towerToAdd = new Beartrap(towerTextures[2], new Vector2(tileX, tileY), 7, 1);
                        pathttype = 1;
                        break;
                    }
                case "BaseballBat":
                    {
                        towerToAdd = new Beartrap(towerTextures[3], new Vector2(tileX, tileY), 4, 1);
                        pathttype = 1;
                        break;
                    }

                    
            }

            if (IsCellClear(pathttype) == true && towerToAdd.Cost <= money)
            { 
                towers.Add(towerToAdd);
                money -= towerToAdd.Cost;

                newTowerType = string.Empty;
            }
   
        }

        private bool IsCellClear(int pathtype)
        {
            bool inBounds = cellX >= 0 && cellY >= 0 &&
                cellX < level.Width && cellY < level.Heigth;

            bool spaceClear = true;

            foreach (Tower tower in towers)
            {
                spaceClear = (tower.animation.Position != new Vector2(tileX, tileY));
                
                if (!spaceClear)
                    break;
            }

            this.pathttype = pathtype;

            bool onPath = (level.GetIndex(cellX,cellY) != pathtype && level.GetIndex(cellX,cellY) != 2);

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
