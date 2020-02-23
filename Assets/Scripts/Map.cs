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

        Tile[,] Tiles;

        public Map(string mapFilePath)
        {
            //Just make a generic test map for now

            GenericMap(100, 100);

            //MapLoader loader = new MapLoader(mapFilePath);
            //Width = loader.Width;
            //Height = loader.Height;
            //Tiles = new Tile[Width, Height];


            //foreach(var tileInfo in loader.TilesInfo)
            //{
            //    TileType type = TileType.Ground;

            //    if(Enum.IsDefined(typeof(TileType), tileInfo.TileType) == false)
            //        Debug.LogError(string.Format("Map: Invalid TileType! {0} is not valid.", tileInfo.TileType));

            //    type = (TileType)tileInfo.TileType;
            //    Tiles[tileInfo.X, tileInfo.Y] = new Tile(tileInfo.X, tileInfo.Y, type);
            //}
        }



        public Tile GetTileAt(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0)
            {
                //Debug.LogError("Tile (" + x + "," + y + ") is out of range");
                return null;
            }
            return Tiles[x, y];
        }

        public TileInfo[] GetTileInfo()
        {
            TileInfo[] tileInfo = new TileInfo[Width * Height];

            int count = 0;
            for (int x = 0; x < Width; x++)
            {
                for(int y = 0; y < Height; y++)
                {
                    Tile tile = Tiles[x, y];
                    TileInfo info = new TileInfo((int)tile.X, (int)tile.Y, (int)tile.Type);
                    tileInfo[count] = info;
                }
            }

            return tileInfo;
        }

        /// <summary>
        /// Creates a flat map for testing
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        void GenericMap(int xSize, int ySize)
        {
            Width = xSize;
            Height = ySize;

            Tiles = new Tile[xSize, ySize];
            TileType type = TileType.Ground;

            for (int i = 0; i < xSize; i++) {
                for (int j = 0; j < ySize; j++)
                {
                    Tiles[i, j] = new Tile(i, j, type);
                }
            }
        }

    }
}
