using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Components
{
    abstract class BaseComponent
    {
       protected Actors.IComponentHolder Parent;


       public BaseComponent(Actors.IComponentHolder parent)
        {
            Parent = parent;
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw() { }

    }
}
