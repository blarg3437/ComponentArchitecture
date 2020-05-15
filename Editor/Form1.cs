using Editor.MapStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Editor
{
    public partial class Form1 : Form
    {
        Image nelson;
        Map map;
        int TextureSize = 64;
        public Form1()
        {
            InitializeComponent();
            nelson = Bitmap.FromFile(@"C:\Users\Nicholas\Pictures\photo.jpg");
            map = new Map(32,32);
            map.AddLayer();
        }

        private void addTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //the following code should be called after the texture is loaded in
            
            
        }

        private void MainDisplay_Paint(object sender, PaintEventArgs e)
        {
            //have one of these for every single dayum 
            for (int i = 0; i < map.sizeX; i++)
            {
                for (int j = 0; j < map.sizeY; j++)
                {
                    if(map.GetTileAt(0, i,j) == 1)
                    {
                        e.Graphics.DrawImage(nelson, new Rectangle(i * TextureSize, j * TextureSize, TextureSize, TextureSize), new Rectangle(0, 0, 48, 48), GraphicsUnit.Pixel);
                    }
                }
            }
        }

        private void MainDisplay_Click(object sender, EventArgs e)
        {
            int MouseX = MousePosition.X - Location.X - MainDisplay.Location.X;
            int MouseY = MousePosition.Y - Location.Y - MainDisplay.Location.Y;
            
            
            map.ModifyLayer(0, (int)Math.Truncate((double)MouseX /TextureSize), (int)Math.Truncate((double)MouseY / TextureSize), 1);
            MainDisplay.Invalidate();//updating the window
        }

        private void TextureList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
