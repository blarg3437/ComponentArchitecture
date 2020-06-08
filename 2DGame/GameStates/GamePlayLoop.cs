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
using _2DGame.Items;
using _2DGame.Map;
using MonoGame.Extended.Sprites;
using Microsoft.Xna.Framework.Input;


namespace _2DGame.GameStates
{
    class GamePlayLoop:IGameState
    {
        //this base class will be for randomly generated ones, there should be a derived one for custom maps
        Texture2D texsheet;
        string contentPath;
        Dungeon currentLevel;

        List<BaseEntity> Entities;
        int cx = 0;
        int cy = 0;
        int speed = 10;
        
        public GamePlayLoop(string contentPath, GraphicsDevice graphics)
        {
            this.contentPath = contentPath;
            Entities = new List<BaseEntity>();
            currentLevel = new Dungeon(4);
        }

        public void Initialize()
        {
            
            currentLevel.StartNewLevel();

        }
        public void Load(ContentManager content)
        {
            texsheet = content.Load<Texture2D>(contentPath);
            currentLevel.setTextures(texsheet);
        }
        public void Update(GameTime gametime)
        {
            KeyboardState state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.W))
            {
                cy--;
            }
            if (state.IsKeyDown(Keys.A))
            {
                cx--;
            }
            if (state.IsKeyDown(Keys.S))
            {
                cy++;
            }
            if (state.IsKeyDown(Keys.D))
            {
                cx++;
            }
            if(state.IsKeyDown(Keys.G))
            {
                currentLevel.StartNewLevel();
            }
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

            currentLevel.Draw(spritebatch,cx,cy);
        }


        public void AddEntity(BaseEntity newentity)
        {
            Entities.Add(newentity);
        }
    }
}
