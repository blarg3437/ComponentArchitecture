using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;

namespace _2DGame.GameStates
{
    class GamePlayLoop:IGameState
    {
        Texture2D texsheet;
        string contentPath;

        private TiledMap map;
        private TiledMapRenderer renderer;
        public GamePlayLoop(string contentPath, GraphicsDevice graphics)
        {
            this.contentPath = contentPath;
           
        }

        public void Initialize()
        {

        }
        public void Load(ContentManager content)
        {
            texsheet = content.Load<Texture2D>(contentPath);
            map = content.Load<TiledMap>("TestMonogmae");
        }
        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texsheet, new Rectangle(0, 0, 64, 64), Color.White);
            //, new Rectangle(448, 191, 64, 64)
            renderer.Draw(map);
        }


    }
}
