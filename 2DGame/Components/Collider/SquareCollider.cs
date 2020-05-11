using _2DGame.Actors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Components.Collider
{
    class SquareCollider : BaseCollider
    {
        public SquareCollider(IComponentHolder parent, int width, int height, Vector2 upperLeftPos) : base(parent)
        {
            
        }
        private void createVertexes(int height, int width, Vector2 upperLeft)
        {
           /*
            * Summary: This takes the points and data provided, and makes a box
            * If there are any errors with the colliders, it is probably here, because this is untested.
            */


            vertexes.Add(upperLeft);
            var temp = new Vector2(upperLeft.X + width);
            vertexes.Add(temp);
            temp.Y += height;
            vertexes.Add(temp);
            temp.X -= width;
            vertexes.Add(temp);
        }

        private BaseCollider checkCollision()
        {

            //Find any nearby colliders that have collided with this one, and return a list of those colliders.
            //Later on, if I need to find out more detail about what collided, you can call the collider's parent and get them in trouble.
            //this needs work obviously
            if (false) {

                BaseCollider collidedwith;
                CallCollsionEvent(this, collidedwith);
                    }
            return null;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
