using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

namespace Ares.Editor
{
    public class MapFileManager : MonoBehaviour
    {
        [SerializeField]
        TMP_InputField pathInput;


        public void SaveMap(string savePath)
        {
            //Map currentMap = EditorManager.Instance.CurrentMap;
            //MapSaver saver = new MapSaver(currentMap.GetTileInfo());
            TileInfo[] tileInfo = new TileInfo[] { new TileInfo(0, 0, 0), new TileInfo(0, 1, 7), new TileInfo(1, 0, 1), new TileInfo(1, 1, 2) };

            MapSaver saver = new MapSaver(savePath, 2, 2, tileInfo);
            saver = null;

        }

        public void LoadMap(string mapPath)
        {
            Map map = new Map(mapPath);

            EditorManager.Instance.ChangeMap(map);

        }

        public void Save()
        {
            SaveMap(pathInput.text);
        }

        public void Load()
        {
            LoadMap(pathInput.text);
        }

    }
}
