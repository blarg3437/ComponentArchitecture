using _2DGame.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Components
{
    class BaseCollider : BaseComponent
    {
        public delegate void Collsion(BaseCollider object1, BaseCollider object2);
        public static event Collsion OnCollision;
        //change this to an array later for optimization          
        protected List<Vector2> vertexes;
        public BaseCollider(IComponentHolder parent) : base(parent)
        {
           
        }

        public void update(GameTime gametime) { }

        /// <summary>
        /// This function will draw the outline of the collision box
        /// </summary>
        /// <param name="D"></param>
        public virtual void DebugDraw(GraphicsDevice D)
        {
            //D.DrawPrimitives(PrimitiveType.)
        }

        protected void CallCollsionEvent(BaseCollider ob1, BaseCollider ob2)
        {
            OnCollision(ob1, ob2);
        }
    }
}
