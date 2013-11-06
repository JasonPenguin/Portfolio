using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

using TowerDefence.Animatie;
using TowerDefence.Tiles;
using TowerDefence.Resources;

namespace TowerDefence
{
    public class Level
    {
        private Queue<Vector2>waypoints = new Queue<Vector2>();
        private Queue<Vector2> water_waypoints = new Queue<Vector2>();
        private Vector2 tile_position;
        public Tile tile;
        public Texture2D tex;

        private string waypointLvl;
        private Rectangle bounds;

        int[,] map = new int[,]
        {
            //level.AddTexture(pad);//0
            //level.AddTexture(Water);//1

            //level.AddTexture(lily1);//2
            //level.AddTexture(lily2);//3
           
            //level.AddTexture(PadH);//4
            //level.AddTexture(PadV);//5

            {0,0,0,0,0,1,1,1,0,1,0,0},
            {0,0,0,0,1,1,1,1,0,1,0,0},
            {0,0,0,0,1,0,1,0,0,1,0,0},
            {0,0,0,0,1,0,1,1,1,1,0,0},
            {0,0,1,1,1,1,1,1,1,1,0,0},
            {0,0,1,0,0,1,0,1,1,0,0,0},
            {0,0,1,0,0,1,0,1,0,0,0,0},
            {0,0,1,0,0,1,0,1,0,0,0,0},
        };

        public Level(string waypointLvl)
        {
            this.waypointLvl = waypointLvl;

            if (this.waypointLvl == "level_01")
            {
                waypoints.Enqueue(new Vector2(7, 0) * 84);
                waypoints.Enqueue(new Vector2(7, 1) * 84);
                waypoints.Enqueue(new Vector2(4, 1) * 84);
                waypoints.Enqueue(new Vector2(4, 4) * 84);
                waypoints.Enqueue(new Vector2(5, 4) * 84);
                waypoints.Enqueue(new Vector2(5, 7) * 84);

                water_waypoints.Enqueue(new Vector2(9, 0) * 84);
                water_waypoints.Enqueue(new Vector2(9, 4) * 84);
                water_waypoints.Enqueue(new Vector2(2, 4) * 84);
                water_waypoints.Enqueue(new Vector2(2, 7) * 84);

                
            }

            if (this.waypointLvl == "level_02")
            {

            }

        }

        /*public void AddTexture(Texture2D texture)
        {
            TileTextures.Add(texture);
        }*/

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Heigth
        {
            get { return map.GetLength(0); }
        }

        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

        public Queue<Vector2> WaterWaypoints
        {
            get { return water_waypoints; }
        }

   

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Heigth; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = Textures.TileTextures[textureIndex];
                    bounds = new Rectangle(x * 84, y * 84, 84, 84);
                    SpriteManager.Position = tile_position;
                    tile_position.X = x * 84;
                    tile_position.Y = y * 84;
                    
                    tile = new Tile(texture, tile_position);
                    tile.Draw(batch);

                }
            }
        }

        public int GetIndex(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > Width - 1|| cellY < 0 || cellY > Heigth - 1)
            {
                return 0;
            }

            return map[cellY, cellX];
        }
    }
}
