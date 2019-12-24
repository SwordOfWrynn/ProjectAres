using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Ares
{
    public class MapSaver
    {

        const string XML_TOP_LINE = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \n\n";

        public MapSaver(string path, int width, int height, TileInfo[] tileInfo)
        {
            XElement mapXML = new XElement("MapFile",
                new XElement("Map",
                new XElement("Name", "TestMap"),
                new XElement("TerrainType", 0),
                new XElement("Width", width),
                new XElement("Height", height),
                    new XElement("Tiles",
                        from info in tileInfo
                        select new XElement("Tile",
                            new XElement("X", info.X),
                            new XElement("Y", info.Y),
                            new XElement("Type", info.TileType)
                            )
                        )
                     )
                );

            SaveFile(mapXML, path);
        }

        void SaveFile(XElement mapFile, string path)
        {
            string xml = XML_TOP_LINE + mapFile.ToString();

            File.WriteAllText(path, xml);

            Debug.Log("Map Saved!");
        }

    }
}
