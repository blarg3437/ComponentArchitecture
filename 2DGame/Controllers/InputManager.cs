using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Controllers
{
    class InputManager
    {
        public delegate void InputObtained(Keys pressed);
        public event InputObtained OnInputPressed;

        KeyboardState Keystate;
        public void Update(GameTime gametime)
        {
            Keystate = Keyboard.GetState();
                  
        }
    }

  
    
}
