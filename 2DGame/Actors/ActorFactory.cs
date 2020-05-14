using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;

namespace _2DGame.Actors
{
    /// <summary>
    /// this class will create all the unique actors in the world...
    /// </summary>
    static class ActorFactory
    {
        private static List<ActorBase> actors;

        static ActorFactory()
        {
            actors = new List<ActorBase>();
            populateEnemies();
            populateNPCS();
        }

        private static void populateNPCS()
        {
            actors.Add(new NPC(
                Vector2.Zero,
                1001,
                "Hello",
                "NPC1"
                ));
        }
        

        private static void populateEnemies()
        {

        }
    }
}
