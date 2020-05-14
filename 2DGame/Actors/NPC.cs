using _2DGame.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Actors
{
    class NPC : ActorBase
    {

        public string Dialog { get; }
        public string name { get; }

        public NPC(Vector2 pos, int id, string dialog, string name):
            base(pos, id)
        {
            Dialog = dialog;
            this.name = name;
            base.AddComponent(CompTypes.Type.Animation);
        }

    }
}
