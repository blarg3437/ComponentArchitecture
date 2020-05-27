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
using Editor.MapStuff;

namespace _2DGame.GameStates
{
    class GamePlayLoop:IGameState
    {
        //this base class will be for randomly generated ones, there should be a derived one for custom maps
        Texture2D texsheet;
        string contentPath;
        Map currentLevel;

       
        public GamePlayLoop(string contentPath, GraphicsDevice graphics)
        {
            this.contentPath = contentPath;
            
        }

        public void Initialize()
        {
            currentLevel = new Map(32,32);
            currentLevel.GenerateMap();
        }
        public void Load(ContentManager content)
        {
            texsheet = content.Load<Texture2D>(contentPath);
            
        }
        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texsheet, new Rectangle(0, 0, 64, 64), Color.White);
            //, new Rectangle(448, 191, 64, 64)
            
        }


    }
}
