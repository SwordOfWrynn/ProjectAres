using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public class TileSpriteController : MonoBehaviour
    {
        [SerializeField]
        Material defaultMaterial;
        [SerializeField]
        Sprite tileSprite;
        [SerializeField]
        Sprite tileRamp1Sprite;
        [SerializeField]
        Sprite tileCliff5Sprite;

        Dictionary<Tile, GameObject> tileToGameObjectDict;

        Map gameMap { get { return GameManager.Instance.GameMap; } }

        // Start is called before the first frame update
        void Start()
        {
            tileToGameObjectDict = new Dictionary<Tile, GameObject>();
            for(int x = 0; x < gameMap.Width; x++)
            {
                for(int y = 0; y < gameMap.Height; y++)
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
                    Sprite sprite;
                    switch (tileData.Type)
                    {
                        case (TileType.Ramp1):
                            sprite = tileRamp1Sprite;
                            break;
                        case (TileType.Cliff5):
                            sprite = tileCliff5Sprite;
                            break;
                        default:
                            sprite = tileSprite;
                            break;
                    }
                    sr.sprite = sprite;
                    sr.sortingLayerName = "Tiles";
                    sr.material = defaultMaterial;

                    //manually call callback for loading
                    //OnTileChanged(tile_data);

                }
            }
        }
    }
}    

