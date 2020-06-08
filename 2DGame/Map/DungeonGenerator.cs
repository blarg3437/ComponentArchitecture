using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Map
{
    class DungeonGenerator
    {
        
        public static int[,] GenerateNewDungeon(int width, int height, int tries = 100)
        {
            List<Room> Rooms = new List<Room>();
            int[,] temp = new int[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    temp[j, i] = 9;
                }
            }
            int counter = 0;
            
            while(counter < 30)
            {
                Room temproom = Room.GenerateNewRoom(width, height);
                Console.WriteLine("got here");
                //check collision against everyother room
                
              Rooms.Add(temproom);//if it is not colliding, add it to the list of valid rooms
                
                    Console.WriteLine(counter);
                    counter++;
                }

               

               
            

            foreach (Room item in Rooms)
            {
                for (int i = item.GetDims().Y; i < item.GetDims().Height + item.GetDims().Y; i++)
                {
                    for (int j = item.GetDims().X; j < item.GetDims().Width + item.GetDims().X; j++)
                    {
                        if (j >= 0 && j < width)
                        {
                            if (i >= 0 && i < height)
                            {
                                temp[j, i] = 0;
                            }
                        }
                    }
                }
            }
            return temp;
        }



        private static void UpdateWalls(int[,] map, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //these get checked throughout the following checks
                    bool isOpenBottom;
                    bool isOpenLeft;
                    bool isOpenRight;
                    bool isOpenTop;

                    if(map[x,y] != 0)
                    {
                        
                    }
                }
            }
        }
    }






    class Room
    {
        Rectangle room;
        int centerX;
        int centerY;
        
        private Room()
        {
            room = new Rectangle();
        }

        public static Room GenerateNewRoom(int boundsX, int boundsY, int minDims = 3, int maxDims = 20)
        {
            Random rand = Global.random;
            Room temp = new Room();
            temp.room.X = rand.Next(boundsX);
            temp.room.Y = rand.Next(boundsY);
            temp.room.Width = rand.Next(minDims, maxDims);
            temp.room.Height = rand.Next(minDims, maxDims);
            
            
            return temp;
        }
        
        public int GetCenterX() { return room.X + room.Width / 2; }
        public int getCenterY() { return room.Y + room.Height / 2; }
        public Rectangle GetDims() => room;
        
    
        public bool checkCollision(Room otherroom)
        {
            return room.Intersects(otherroom.room);          
        }

    }
    
}
