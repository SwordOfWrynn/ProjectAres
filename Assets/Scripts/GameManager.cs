using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; protected set; }

        [SerializeField] TileSpriteController m_tileSpriteController;

        public static MatchInfo GameInfo { get; protected set; }

        public Map GameMap { get; protected set; }

       

        // Start is called before the first frame update
        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one GameManager in the scene!");
            }
            Instance = this;

            //Testing
            GameInfo = new MatchInfo(@"E:\ComputerScience\UnityProjects\ProjectAres\Assets\StreamingAssets\Base\Maps\BasicMap.xml", "");

            GameMap = new Map(GameInfo.MapPath);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void SetGameInfo(MatchInfo gameInfo)
        {
            GameInfo = gameInfo;
        }

    }
}
