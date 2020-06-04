using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Map
{
    
    class Level
    {
        int[,] generatedMap;
        int sizeX, sizeY;
        public Level(int sizeX, int sizeY)
        {
            generatedMap = new int[sizeX, sizeY];
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }

        public int getTileAt(int x, int y)
        {
            if(x >= 0 && x < sizeX)
            {
                if(y >= 0 && y < sizeY)
                {
                    return generatedMap[x, y];
                }
            }
            return -1;//-1 means that it is out of bounds
        }

        public void generateNewLevel()
        {
            //generate a map! Fun!
        }

        
    }
}
