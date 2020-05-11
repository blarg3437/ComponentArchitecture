using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Actors
{
    interface IComponentHolder
    {
         float GetX { get; }
         float GetY { get; }
    }
}
