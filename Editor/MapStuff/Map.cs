using System;
using System.Collections.Generic;
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
            if (x > 0 && x <= sizeX)
            {
                if (y > 0 && y <= sizeY)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
