using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Linq;
using System;

namespace Ares
{
    public class MapLoader
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public TileInfo[] TilesInfo { get; protected set; }


        public MapLoader(string mapPath)
        {
            LoadMap(XElement.Load(mapPath));
        }

        public MapLoader(string mapPath, bool isSaveGame)
        {
            if (isSaveGame == false)
                LoadSaveGame(XElement.Load(mapPath));
            LoadMap(XElement.Load(mapPath));
        }

        public void LoadMap(XElement xmlFile)
        {
            Debug.Log(xmlFile.Name);

            XElement map = xmlFile.Element("Map");
            try
            {
                Width = int.Parse(map.Element("Width").Value);
                Height = int.Parse(map.Element("Height").Value);

            }
            catch(Exception ex)
            {
                Debug.LogError("MapLoader -- LoadMap: Could not load Width and Height from Map file");
                Debug.LogError(ex.GetType().ToString());
                Debug.LogError(ex.Message);
            }

            LoadTiles(map);
        }

        void LoadTiles(XElement xmlMap)
        {
            var tileQuery =
                from element in xmlMap.Elements()
                where element.Name == "Tiles"
                from tile in element.Elements()
                orderby tile.Name.ToString()
                select tile;

            TilesInfo = new TileInfo[tileQuery.Count()];
            Debug.Log(tileQuery.Count());
            try
            {
                for (int i = 0; i < tileQuery.Count(); i++)
                {
                    int x = int.Parse(tileQuery.ElementAt(i).Element("X").Value);
                    int y = int.Parse(tileQuery.ElementAt(i).Element("Y").Value);
                    int tileType = int.Parse(tileQuery.ElementAt(i).Element("Type").Value);

                    TileInfo info = new TileInfo(x, y, tileType);
                    TilesInfo[i] = info;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("MapLoader -- LoadTile: Could not load tiles from Map file");
                Debug.LogError(ex.GetType().ToString());
                Debug.LogError(ex.Message);
            }
        }

        void LoadSaveGame(XElement xmlMap)
        {

        }

    }
}
