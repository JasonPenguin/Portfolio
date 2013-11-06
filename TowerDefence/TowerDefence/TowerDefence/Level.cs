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
using TowerDefence.Resources;

namespace TowerDefence
{
    public class Level
    {
        private Queue<Vector2>waypoints = new Queue<Vector2>();
        private Queue<Vector2> water_waypoints = new Queue<Vector2>();
        private Queue<Vector2> plankwaypoints = new Queue<Vector2>();
        private Queue<Vector2> plankwaypoints_2 = new Queue<Vector2>();
        private string waypointLvl;
        

        int[,] map = new int[,]
        {
 
            {0,0,0,0,0,3,0,0,0,0,0,2},
            {3,3,3,3,3,3,0,0,0,0,0,2},
            {0,0,0,0,3,3,3,3,0,0,0,2},
            {0,0,0,0,3,0,0,3,3,3,3,2},
            {0,3,3,3,3,3,3,0,0,0,0,2},
            {0,3,0,0,0,0,3,0,0,0,0,2},
            {0,3,0,0,0,0,3,0,0,0,0,2},
            {0,3,0,0,0,0,3,0,0,0,0,2},
        };

        public Level(string waypointLvl)
        {
            this.waypointLvl = waypointLvl;

            //waypoints posities
            if (this.waypointLvl == "level_01")
            {
                plankwaypoints.Enqueue(new Vector2(5, 0) * 84);
                plankwaypoints.Enqueue(new Vector2(5, 4) * 84);
                plankwaypoints.Enqueue(new Vector2(1, 4) * 84);
                plankwaypoints.Enqueue(new Vector2(1, 7) * 84);

                plankwaypoints_2.Enqueue(new Vector2(4, 0) * 84);
                plankwaypoints_2.Enqueue(new Vector2(4, 2) * 84);
                plankwaypoints_2.Enqueue(new Vector2(7, 2) * 84);
                plankwaypoints_2.Enqueue(new Vector2(7, 8) * 84);
                plankwaypoints_2.Enqueue(new Vector2(4, 0) * 84);
                plankwaypoints_2.Enqueue(new Vector2(4, 0) * 84);


                waypoints.Enqueue(new Vector2(8, 0) * 84);
                waypoints.Enqueue(new Vector2(8, 4) * 84);
                waypoints.Enqueue(new Vector2(10, 4) * 84);
                waypoints.Enqueue(new Vector2(10, 7) * 84);
                waypoints.Enqueue(new Vector2(6, 7) * 84);

                water_waypoints.Enqueue(new Vector2(1, 0) * 84);
                water_waypoints.Enqueue(new Vector2(1, 3) * 84);
                water_waypoints.Enqueue(new Vector2(4, 3) * 84);
                water_waypoints.Enqueue(new Vector2(4, 5) * 84);
                water_waypoints.Enqueue(new Vector2(6, 5) * 84);
                water_waypoints.Enqueue(new Vector2(6, 8) * 84);
                
            }

            if (this.waypointLvl == "level_02")
            {

            }

        }

        public int Width
        {
            get { return map.GetLength(1); }
        }

        public int Heigth
        {
            get { return map.GetLength(0); }
        }

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

        public Queue<Vector2> WaterWaypoints
        {
            get { return water_waypoints; }
        }

        public Queue<Vector2> Plankwaypoints_left
        {
            get { return plankwaypoints; }
        }

        public Queue<Vector2> Plankwaypoints_right
        {
            get { return plankwaypoints_2; }
        }

        public int GetIndex(int cellX, int cellY)
        {
            //zorgt dat niet uit het level kan klikken
            if (cellX < 0 || cellX > Width - 1|| cellY < 0 || cellY > Heigth - 1)
            {
                return 0;
            }

            return map[cellY, cellX];
        }
    }
}
