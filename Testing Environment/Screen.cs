using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Environment
{
    class Screen
    {
        Particle[,] particles;
        int sX;
        int sY;
        public Screen(int sizeX, int sizeY)
        {
            particles = new Particle[sizeX, sizeY];
            sX = sizeX;
            sY = sizeY;
        }

        public Particle[,] getArray() => particles;
        public void GenerateMap()
        {
            for (int i = 0; i < sY; i++)
            {
                for (int j = 0; j < sX; j++)
                {
                    particles[j, i] = new Particle(this);
                }
            }
        }

        public void UpdateMap()
        {
            for (int i = 0; i < sY; i++)
            {
                for (int j = 0; j < sX; j++)
                {
                    particles[j, i].Update();
                }
            }
        }
    }
}
