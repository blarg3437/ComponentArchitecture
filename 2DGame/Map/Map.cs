using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Editor.MapStuff
{
    class Map
    {
        public int sizeX { get; }
        public int sizeY { get; }
        List<Layers> MapLayers;
        public Map(int sizex, int sizey)
        {
            sizeX = sizex;
            sizeY = sizey;
            MapLayers = new List<Layers>();
        }

        public static Map ReadInMap(StreamReader stream)
        {
            try
            {
                //first read in the size of the map...
                int sX = Int16.Parse(stream.ReadLine());
                int sY = Int16.Parse(stream.ReadLine());
                for (int i = 0; i < sX * sY; i++)
                {

                }
            }
            catch
            {
                return null;
            }

        }
        public void AddLayer()
        {
            MapLayers.Add(new Layers(sizeX, sizeY, MapLayers.Count));//this creates the layer with knowledge on its level from 1-inf, not 0-inf
        }

        public bool ModifyLayer(int layer, int x, int y, int data)
        {
            if (MapLayers[layer].ChangeTile(x, y, data))
            {
                return true;
            }
            return false;
        }

        public int GetTileAt(int layer, int x, int y)
        {
            return MapLayers[layer].GetTileAt(x, y);
        }

        public void GenerateMap()
        {
            Random rand = new Random();
            //This method will contain a random map generator, which should eventually take some values to determine how this will look.
            //ie: contains water, contains lakes, etc
            if(MapLayers.Count == 0)
            {
                AddLayer();
            }
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    ModifyLayer(0, x, y, rand.Next(5));//between 0 and 5
                }
            }
        }

        public void drawMap(SpriteBatch spritebatch)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {

                }
            }
        }



        public void Save(StreamWriter writer)
        {
            writer.WriteLine(sizeX);
            writer.WriteLine(sizeY);
            foreach (var item in MapLayers)
            {
                item.WriteLayer(writer);               
            }
        }

        
    }

    internal class Layers
    {
        private int sizeX;
        private int sizeY;
        public int layerDepth;
        int[,] terrainData;
        public Layers(int Sizex, int SizeY, int LayerDepth)
        {
            sizeX = Sizex;
            sizeY = SizeY;
            layerDepth = LayerDepth;

            terrainData = new int[sizeX, sizeY];
        }

        public int[,] SaveLayer => terrainData;
        public void WriteLayer(StreamWriter writer)
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    writer.Write(terrainData[j, i]);
                }
                writer.WriteLine();

            }
        }
        public bool ChangeTile(int x, int y, int data)
        {
            if (CheckCollisionAt(x, y))
            {
                terrainData[x, y] = data;
                return true;
            }
            return false;


        }

        public int GetTileAt(int x, int y)
        {
            if (CheckCollisionAt(x, y))
            {
                return terrainData[x, y];
            }
            return 0;
        }
     
        private bool CheckCollisionAt(int x, int y)
        {
            if (x > 0 && x < sizeX)
            {
                if (y > 0 && y < sizeY)
                {
                    return true;
                }
            }
            return false;
        }

       
    }
}
