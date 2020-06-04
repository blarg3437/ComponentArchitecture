using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Environment
{
    class Particle
    {
        float temperature;
        float velocity;
        Screen screen;
        int positionX, positionY;

        public float GetTemperature() => temperature;
        public float GetVelocity() => velocity;
        public Particle(Screen sc, int posX, int posY)
        {
            screen = sc;
            temperature = 0;
            velocity = 0;
            positionX = posX;
            positionY = posY;
        }

        public void Update()
        {

        }


        private void MoveUp()
        {
            Particle[,] MainArray = screen.getArray();
            if (positionY - 1 < 0)
            {
                if (MainArray[positionX, positionY - 1].GetTemperature() < this.temperature)
                {
                    Particle tempPart = MainArray[positionX, positionY - 1];
                    MainArray[positionX, positionY - 1] = this;
                    MainArray[positionX, positionY] = tempPart;
                    positionY = positionY - 1;
                    //update velocity
                }
            }

        }


    }
}
