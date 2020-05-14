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
    class Menu : IGameState
    {
        SpriteFont font;
        Texture2D spriteSheet;
        public Menu(params string[] menus)
        {
            //dont worry about implementation of the menu
        }
       

        public void Initialize()
        {
           
        }

        public void Load(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font");
            spriteSheet = content.Load<Texture2D>("Menu/continue_hovered");
        }

        public void Update(GameTime gametime)
        {
           
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(spriteSheet, Vector2.Zero, Color.White);
        }
    }
}
