﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2DGame.GameStates
{
    class StateController
    {
        Stack<IGameState> theStack;
        Dictionary<string, IGameState> gamestates;
        GraphicsDeviceManager graphics;
        public StateController(GraphicsDeviceManager g)
        {
            gamestates = new Dictionary<string, IGameState>();         
            theStack = new Stack<IGameState>();
            graphics = g;
        }

        public void Initialize()
        {
            gamestates.Add("level1", new GamePlayLoop("Levels/Test/GenTest", graphics.GraphicsDevice));            
            gamestates.Add("MainMenu", new Menu("Load"));

            theStack.Push(gamestates["level1"]);
            theStack.Peek().Initialize();
        }
        public void Load(ContentManager content)
        {
            foreach (var item in gamestates)
            {
                item.Value.Load(content);
            }
        }

        public void Update(GameTime gametime)
        {
            KeyboardState keys = Keyboard.GetState();        
            
            theStack.Peek().Update(gametime);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            theStack.Peek().Draw(spritebatch);
        }

        //------------------------------------------------------------------------------------------------------\\

        public void Push(IGameState newstate)
        {
            theStack.Push(newstate);
        }
 
        public void Pop()
        {
            theStack.Pop();
        }
    }
}
