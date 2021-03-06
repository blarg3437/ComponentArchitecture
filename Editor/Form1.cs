﻿using Editor.ImageStuff;
using Editor.MapStuff;
using Editor.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        TextureManager manager;
        int mouseXOffset = 0;
        int mouseYOffset = 0;
        int zoom = 1;
        int layer = 0;
        string directory = @"C:\Users\Nicholas\Desktop\Save\Save.txt";
        Graphics g;

        public delegate void clickedWith();
        public event clickedWith clickedWithTex;

        public Form1()
        {
            InitializeComponent();
            manager = new TextureManager(this);
            map = new Map(32, 32);
            map.AddLayer();

            KeyPreview = true;
           
            MainDisplay.Enabled = false;//making sure you cant click before you load
            ImageHolder.VerticalScroll.Enabled = true;
            ImageHolder.AutoScroll = true;
            MainDisplay.AutoSize = true;
            

            addTexturesToolStripMenuItem.Click += new EventHandler(manager.AddTextureClick);
            tabControl1.SelectedIndexChanged += new EventHandler(manager.TabChangedHandler);            
            g = MainDisplay.CreateGraphics();
        }
        #region SomePropertiesOfControls
        public TabControl GetTabControl() => tabControl1;
        public Panel getMainDisplay() => MainDisplay;
        public Panel GetTexturePicker() => ImageHolder;
        
        public Graphics getGraphics() => g;
        #endregion      

        private void MainDisplay_Click(object sender, EventArgs e)
        {
            int MouseX = (MousePosition.X - Location.X - MainDisplay.Left - 6)  / manager.TextureSize * zoom;//6 and 34 represent the width and height of the border of the window
            int MouseY = (MousePosition.Y - Location.Y - MainDisplay.Top - 35)  / manager.TextureSize * zoom;
            Console.WriteLine("MouseY: " + MousePosition.Y + "LocationY: " + Location.Y + "Top:" + MainDisplay.Top + "Final: " + MouseY);

            map.ModifyLayer(layer, MouseX - mouseXOffset, MouseY - mouseYOffset, manager.currentTextureData);//make sure to put in collisiomn for the edge of the array
            clickedWithTex();

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
            g.TranslateTransform(xOffset * manager.TextureSize, yOffset * manager.TextureSize);//actually changing the position of the objects on the screen
            UpdateScreen();
            
        }

        private void UpdateScreen()
        {
            //just drawing the screen
            int TextureSize = manager.TextureSize;
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
                    if (map.GetTileAt(0,i, j) != 0)
                    {
                        g.DrawImage(manager.FindMyImage(map.GetTileAt(layer, i, j)),
                            new Rectangle((i) * TextureSize * zoom, (j) * TextureSize * zoom, TextureSize *zoom , TextureSize*zoom),
                                new Rectangle(0, 0, TextureSize, TextureSize), GraphicsUnit.Pixel);
                        
                    }
                }
            }
        }

        private void ImageHolder_Scroll(object sender, ScrollEventArgs e)
        {
            
            Console.WriteLine("Scroll");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = directory;
            sfd.Title = "Save Location";
            DialogResult dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                directory = sfd.FileName;
                StreamWriter writer = new StreamWriter(directory, false, Encoding.Default);
                map.Save(writer);
                manager.Save(writer);
                writer.Close();
            }
        }

        private void LayerSelector_Click(object sender, EventArgs e)
        {
            manager.TabSelected = LayerSelector.SelectedIndex; 
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = directory;
            ofd.Filter = "Save Files(*.txt)|*.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                directory = ofd.FileName;
            }

            StreamReader reader = new StreamReader(directory);         
            map = Map.Load(reader);           
            manager.Load(reader);
            UpdateScreen();
            reader.Close();
        }

        private void AddLayer_Click(object sender, EventArgs e)
        {
            
        }

        private void RemoveLayer_Click(object sender, EventArgs e)
        {           
            
        }
       
    }
}
