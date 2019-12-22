using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

namespace Ares
{
    public class Map
    {
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public int Terrain { get; protected set; }

        Tile[,] tiles;

        public Map(string mapFile)
        {
            Height = 10;
            Width = 10;
            tiles = new Tile[Height, Width];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new Tile(x, y);
                    //tiles[x, y].RegisterTileTypeChangedCallback(OnTileChanged);
                }
            }
        }

        public Tile GetTileAt(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0)
            {
                //Debug.LogError("Tile (" + x + "," + y + ") is out of range");
                return null;
            }
            return tiles[x, y];
        }

        public void LoadMap(XElement xmlMap)
        {

        }

    }
}
