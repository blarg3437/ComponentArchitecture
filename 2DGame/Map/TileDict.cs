using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Map
{
    class TileDict
    {

        //When adding a new texture rectangle, add the rectangle, then an enum reference based on GenTest.PNG
        static Dictionary<int, Rectangle> Sources;
        public enum names
        {
            EmptyFloor,
            LeftTopCornerIn,
            TopSideIn,
            RightTopCornerIn,
            LeftSideIn,
            RightSideIn,
            LeftBottomCornerIn,
            BottomSideIn,
            RightBottomCornerIn,
            MiddleWall,
        }
        static TileDict()
        {
            int tsize = Global.TextureSize;
            Sources = new Dictionary<int, Rectangle>();
            Sources.Add(0, new Rectangle(7, 0, tsize, tsize));//Empty Floor
            Sources.Add(1, new Rectangle(0, 0, tsize, tsize));//Left Top Corner In
            Sources.Add(2, new Rectangle(1, 0, tsize, tsize));//Top Side In
            Sources.Add(3, new Rectangle(2, 0, tsize, tsize));//Right Top Corner In
            Sources.Add(4, new Rectangle(0, 1, tsize, tsize));//Left Side In
            Sources.Add(5, new Rectangle(2, 1, tsize, tsize));//Right Side In
            Sources.Add(6, new Rectangle(0, 2, tsize, tsize));//Left Bottom Corner In
            Sources.Add(7, new Rectangle(1, 2, tsize, tsize));//Bottom Side In
            Sources.Add(8, new Rectangle(2, 2, tsize, tsize));//Right Bottom Corner In
            Sources.Add(9, new Rectangle(1, 1, tsize, tsize));//Middle Wall
        }


        public static Rectangle GetSourceByInt(int val1)
        {
            Rectangle temp = Sources[val1];
            temp.X *= Global.TextureSize;
            temp.Y *= Global.TextureSize;
            return temp;
        }
    }
}
