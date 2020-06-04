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
using _2DGame.Items;

namespace _2DGame.GameStates
{
    class GamePlayLoop:IGameState
    {
        //this base class will be for randomly generated ones, there should be a derived one for custom maps
        Texture2D texsheet;
        string contentPath;
        Map currentLevel;

        List<BaseEntity> Entities;
       
        
        public GamePlayLoop(string contentPath, GraphicsDevice graphics)
        {
            this.contentPath = contentPath;
            Entities = new List<BaseEntity>();
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
            foreach (BaseEntity item in Entities)
            {
                item.Update(gametime);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (BaseEntity item in Entities)
            {
                spritebatch.Draw(texsheet, item.GetPosition() * Global.TextureSize, item.GetSource(), item.GetColor());
            }
            
        }


        public void AddEntity(BaseEntity newentity)
        {
            Entities.Add(newentity);
        }
    }
}
