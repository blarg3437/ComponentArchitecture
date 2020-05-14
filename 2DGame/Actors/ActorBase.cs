using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using _2DGame.Components;
using Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DGame.Actors
{
    class ActorBase : IComponentHolder
    {
        protected Vector2 position;
        public int ID { get; protected set; }
        public Rectangle sourceRec;
        public float GetX => position.X;
        public float GetY => position.Y;

        //this is where the magic happens. Within this dictionary, are all of the component that will make up this actor
        protected Dictionary<CompTypes.Type, BaseComponent> _Components;

        public ActorBase(Vector2 pos, int id)
        {
            position = pos;
            ID = id;
           
        }
        public void AddComponent(CompTypes.Type typetocreate)
        {
            //Im just gonna say i, I dont really like how this method is witten, I think that it could be handled better, I want to rewrite it in the future...
            if (!_Components.ContainsKey(typetocreate))
            {
                switch (typetocreate)
                {
                    case CompTypes.Type.Animation:
                        _Components.Add(typetocreate, new Animation(this));
                        break;

                    default:
                        return;
                }
            }
        }
        public void RemoveComponent(CompTypes.Type typetodelete)
        {
            if (_Components.ContainsKey(typetodelete))
            {
                _Components.Remove(typetodelete);
            }
        }

        

    }
}
