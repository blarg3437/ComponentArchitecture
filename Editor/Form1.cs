﻿using Editor.MapStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Editor
{
    public partial class Form1 : Form
    {
        //test file: C:\Users\Nicholas\Source\Repos\blarg3437\ComponentArchitecture\2DGame\Content\Levels\Standard\tilea4.png

        Map map;
        int TextureSize = 64;
        List<Image> textures;
        Dictionary<int, PictureBox> itemsinholder;       
        int mouseXOffset = 0;
        int mouseYOffset = 0;
        int columns;
        int heightofImageStack = 0;
        int oldoffset = 0;
        int currentTextureData = 0;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            map = new Map(32, 32);
            map.AddLayer();
            textures = new List<Image>();
            itemsinholder = new Dictionary<int, PictureBox>();
            KeyPreview = true;
            vScrollBar1.Enabled = false;
            MainDisplay.Enabled = false;//making sure you cant click before you load

            g = MainDisplay.CreateGraphics();
        }

        private void addTexturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextureImportForm newwindow = new TextureImportForm();
            newwindow.Submitted += ConsumeList;
            newwindow.Activate();
            newwindow.Show();

        }

        public void ConsumeList(List<Image> images, int texsize)
        {
            TextureSize = texsize;
            Console.WriteLine("Consumed!");
            textures = images;
            MainDisplay.Invalidate();
            MainDisplay.Enabled = true;
            vScrollBar1.Enabled = true;
            g.Clear(System.Drawing.Color.Black);

            int count = 0;
            //loading the sidebar full of the images
            foreach (Image item in textures)
            {
                PictureBox pb = new PictureBox();
                
                pb.Parent = ImageHolder;
                pb.Size = new System.Drawing.Size(TextureSize, TextureSize);
                pb.Image = item;
                pb.MouseClick += TextureClickHandler;
                itemsinholder.Add(count, pb);
                ImageHolder.Controls.Add(itemsinholder[count]);
                count++;
            }
            //draw the actual sidebar full of images
            int xover = 0;
            int yover = 0;
            columns = ImageHolder.Width / TextureSize;
            foreach (KeyValuePair<int, PictureBox> item in itemsinholder)
            {
                
                item.Value.Location = new System.Drawing.Point(
                    xover * TextureSize,
                    yover * TextureSize);
                
                item.Value.Show();
                

                if (xover % columns == 0 && xover != 0)
                {
                    xover = 0;
                    yover++;
                }
                else
                {
                    xover++;
                }
            }

            heightofImageStack = yover;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //the following code should be called after the texture is loaded in


        }

        private void MainDisplay_Click(object sender, EventArgs e)
        {
            int MouseX = (MousePosition.X - Location.X - MainDisplay.Left - 6) / TextureSize;//6 and 34 represent the width and height of the border of the window
            int MouseY = (MousePosition.Y - Location.Y - MainDisplay.Top - 35) / TextureSize;
            Console.WriteLine("MouseY: " + MousePosition.Y + "LocationY: " + Location.Y + "Top:" + MainDisplay.Top + "Final: " + MouseY);

            map.ModifyLayer(0, MouseX - mouseXOffset, MouseY - mouseYOffset, currentTextureData);//make sure to put in collisiomn for the edge of the array
            

            #region debug
            //This is all debugging-----------------------------
            //for (int y = 0; y < map.sizeY; y++)
            //{
            //    for (int x = 0; x < map.sizeX; x++)
            //    {
            //        Console.Write(map.GetTileAt(0,x, y));
            //    }
            //    Console.WriteLine();
            //}
            //--------------------------------------------------
            #endregion
            UpdateScreen();
        }

        public void TextureClickHandler(object sender, EventArgs e)
        {
            foreach (var item in itemsinholder)
            {               
                if(item.Value.Equals(sender))
                {
                    currentTextureData = item.Key;
                    return;
                }
            }
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int xOffset = 0;
            int yOffset = 0;
            switch (e.KeyCode)
            {
                case Keys.W:
                    Console.WriteLine("W!");
                    yOffset = 1;
                    break;
                case Keys.A:
                    Console.WriteLine("A!");
                    xOffset = 1;
                    break;
                case Keys.S:
                    Console.WriteLine("S!");
                    yOffset = -1;
                    break;
                case Keys.D:
                    Console.WriteLine("D!");
                    xOffset = -1;
                    break;

            }
            mouseXOffset += xOffset; //adding the values of 1 or -1 or 0 to the total mouse offset
            mouseYOffset += yOffset;
            g.TranslateTransform(xOffset * TextureSize, yOffset * TextureSize);//actually changing the position of the objects on the screen
            UpdateScreen();

        }

        private void UpdateScreen()
        {
            //just drawing the screen
            g.Clear(System.Drawing.Color.Black);
            for (int i = 0; i < map.sizeX; i++)
            {
                for (int j = 0; j < map.sizeY; j++)
                {
                   //if (map.GetTileAt(0, i, j) == 1)
                   //{
                   //    g.DrawImage(textures[0],
                   //        new Rectangle((i) * TextureSize, (j) * TextureSize, TextureSize, TextureSize),
                   //        new Rectangle(0, 0, TextureSize, TextureSize), GraphicsUnit.Pixel);
                   //}

                    g.DrawImage(textures[map.GetTileAt(0, i,j)], 
                        new Rectangle((i) * TextureSize, (j) * TextureSize, TextureSize, TextureSize),
                            new Rectangle(0, 0, TextureSize, TextureSize), GraphicsUnit.Pixel);
                }
            }
        }

        

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int yoffset = -TextureSize*(heightofImageStack * vScrollBar1.Value) / 100;
            foreach (var item in itemsinholder)
            {

                item.Value.Location = new System.Drawing.Point(item.Value.Location.X, item.Value.Location.Y - oldoffset + yoffset);
            }
            oldoffset = yoffset;
        }
    }
}
