using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.GameStates
{
    /// <summary>
    /// this will follow a singleton pattern, and keep track of the state the game is in.
    /// </summary>
    class StateController
    {
        //all of this makes this a singleton I guess...
        public static StateController instance;
        static StateController()
        {
        }
        private StateController()
        { }
        public static StateController Instance
        {
            get { return instance; }
        }
        //End of the singleton implimentation


        BaseState currentState;
        private List<BaseState> _states = new List<BaseState>(){
            new GameStates.GamePlayState(),
            new GameStates.LoadingState(),
        }; 
        public void changeState(BaseState newState)
        {
            currentState.UnloadContent();
            currentState = newState;
            currentState.LoadContent();
            
        }

        public void Initialize()
        {
            //a little bit of test code
            
        }

        public void LoadContent()
        {

        }

        public void Update(GameTime gametime)
        {
            currentState.Update(gametime);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentState.Draw(spritebatch);
        }

        
    }
}
