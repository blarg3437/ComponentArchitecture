using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Controllers
{
    class Camera
    {
        float Cx;
        float Cy;

        int Cwidth = Global.game.GraphicsDevice.Viewport.Width;
        int CHeight = Global.game.GraphicsDevice.Viewport.Height;
    }
}
