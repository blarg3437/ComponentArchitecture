using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.GameStates
{
    class GamePlayLoop:IGameState
    {
        Texture2D texsheet;
        public GamePlayLoop()
        {

        }

        public void Initialize()
        {

        }
        public void Load(ContentManager content)
        {
            texsheet = content.Load<Texture2D>("Levels/Standard/tilea4");
        }
        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texsheet, new Rectangle(0, 0, 64, 64), new Rectangle(448, 191, 64, 64), Color.White);
            
        }

       
    }
}
