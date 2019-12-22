using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public class TileSpriteController : MonoBehaviour
    {
        [SerializeField]
        Sprite tileSprite;

        Dictionary<Tile, GameObject> tileToGameObjectDict;

        Map gameMap { get { return GameManager.Instance.GameMap; } }

        // Start is called before the first frame update
        void Start()
        {
            tileToGameObjectDict = new Dictionary<Tile, GameObject>();
            for(int x = 0; x < gameMap.Height; x++)
            {
                for(int y = 0; y < gameMap.Width; y++)
                {
                    Tile tileData = gameMap.GetTileAt(x, y);

                    GameObject tile_GO = new GameObject();

                    tileToGameObjectDict.Add(tileData, tile_GO);

                    tile_GO.name = "Tile_" + x + "," + y;

                    (float, float) isoPos = Tile.CartToIso(tileData.X, tileData.Y);

                    tile_GO.transform.position = new Vector3(isoPos.Item1, isoPos.Item2, 0);
                    tile_GO.transform.SetParent(transform, true);

                    //add a sprite renderer
                    SpriteRenderer sr = tile_GO.AddComponent<SpriteRenderer>();
                    sr.sprite = tileSprite;
                    sr.sortingLayerName = "Tiles";

                    //manually call callback for loading
                    //OnTileChanged(tile_data);

                }
            }
        }
    }
}    

