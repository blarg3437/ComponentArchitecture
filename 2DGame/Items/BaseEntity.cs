using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Items
{
    class BaseEntity
    {
        private Vector2 position;
        Rectangle SourceRec;
        Color DrawColor;
        public Vector2 GetPosition() => position;
        public Rectangle GetSource() => SourceRec;
        public Color GetColor() => DrawColor;
        public void Update(GameTime gametime)
        {
        
        }

        public void Load()
        {

        }
        public void Draw(SpriteBatch spritebatch)
        {
           
        }
    }
}
