using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Global
    {
        public static int TextureSize = 64;
        public static Game1 game;//just holding a reference to the game, so anyone can grab it
        public static Random random = new Random();

        public static void Initialize(Game1 game1)
        {
            game = game1;
        }
    }
}
