using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    static class TEXTURECONSTS
    {
        //16x16 Item Sprites
        public enum ItemTextures
        {
            RING_GREY,
            RING_WHITE,
            CLUMP_COPPER,
            CLUMP_IRON,
            SHOVEL_IRON,
            PICK_IRON,
            BOOK_GREEN,
            BOOK_RED,
            GEM_RED,
            GEM_BLUE,
            INGOT_COPPER,
            INGOT_IRON,
            BATTLEAXE_IRON,
            SPEAR, IRON,
            BOOK_PURPLE,
            BOOK_YELLOW
        }

        public static Rectangle GetItemRect16(ItemTextures itemId)
        {
            //this is a terrible method, it is only temporary...
            int y = 0;
            int x = 0;
            if ((int)itemId >= 8)
            {
                y = 1;
                x = (int)itemId - 8;
            }
            else
            {
                x = (int)itemId;
            }
            return new Rectangle(x * 16, y * 16, 16, 16);

        }
    }
}