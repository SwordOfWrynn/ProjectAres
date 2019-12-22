using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System;

namespace Ares
{
    public class Map
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public int Terrain { get; protected set; }

        Tile[,] tiles;

        public Map(string mapFilePath)
        {
            MapLoader loader = new MapLoader(mapFilePath);
            Width = loader.Width;
            Height = loader.Height;
            tiles = new Tile[Width, Height];

            foreach(var tileInfo in loader.TilesInfo)
            {
                TileType type = TileType.Ground;

                if(Enum.IsDefined(typeof(TileType), tileInfo.TileType) == false)
                    Debug.LogError(string.Format("Map: Invalid TileType! {0} is not valid.", tileInfo.TileType));

                type = (TileType)tileInfo.TileType;
                tiles[tileInfo.X, tileInfo.Y] = new Tile(tileInfo.X, tileInfo.Y, type);
            }

           /* Width = 20;
            Height = 50;
            tiles = new Tile[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new Tile(x, y);
                    //tiles[x, y].RegisterTileTypeChangedCallback(OnTileChanged);
                }
            }*/
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
