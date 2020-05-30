using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void AddLayer()
        {
            MapLayers.Add(new Layers(sizeX, sizeY, MapLayers.Count));//this creates the layer with knowledge on its level from 1-inf, not 0-inf
        }

        public void RemoveLayer(int index)
        {
            if(index < MapLayers.Count)
            {
                MapLayers.RemoveAt(index);
            }
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

        public void Save(StreamWriter writer)
        {
            writer.WriteLine(sizeX);//SizeX
            writer.WriteLine(sizeY);//SizeY
            writer.WriteLine(MapLayers.Count);//NumberOfLayers
            foreach (var item in MapLayers)
            {
                item.WriteLayer(writer);               
            }
        }

        public static Map Load(StreamReader reader)
        {
            int sX = int.Parse(reader.ReadLine());
            int sY = int.Parse(reader.ReadLine());
            Console.WriteLine("Sx " + sX);
            Map temp = new Map(sX, sY);
            int layers = int.Parse(reader.ReadLine());
            for (int i = 0; i < layers; i++)
            {
                temp.AddLayer();
                
            }
            foreach (var item in temp.MapLayers)
            {
                item.LoadLayer(reader);
            }
            return temp;
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
                    writer.Write(",");
                }
                writer.WriteLine();

            }
            writer.WriteLine(";");
        }

        public void LoadLayer(StreamReader reader)
        {
            //reading the lines into a list           
            string[] lines = new string[sizeY];
            for (int i = 0; i < sizeY; i++)
            {
                lines[i] = reader.ReadLine();
            }

            string[][] set = new string[sizeY][];
            for (int i = 0; i < sizeY; i++)
            {
                set[i] = lines[i].Split(',');
            }

            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    terrainData[j, i] = int.Parse(set[i][j]);
                    Console.Write(set[i][j]);
                }
                Console.WriteLine();//getting past the ;
            }

            reader.ReadLine();
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
