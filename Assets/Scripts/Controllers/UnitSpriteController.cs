using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares {
    public class UnitSpriteController : MonoBehaviour
    {

        Dictionary<Unit, GameObject> UnitToGameObjectDict;

        // Start is called before the first frame update
        void Start()
        {
            UnitToGameObjectDict = new Dictionary<Unit, GameObject>();
        }

        void OnUnitCreated(Unit unit)
        {
            if (UnitToGameObjectDict.ContainsKey(unit) == true)
            {
                Debug.LogError("UnitSpriteController -- OnUnitCreated: Unit is already in Dictionary!");
                return;
            }
        }

        void OnUnitChanged(Unit unit)
        {
            if(UnitToGameObjectDict.ContainsKey(unit) == false)
            {
                Debug.LogError("UnitSpriteController -- OnUnitChanged: Unit is not in Dictionary!");
                return;
            }
            GameObject unitGO = UnitToGameObjectDict[unit];

            unitGO.transform.position = new Vector3(unit.X, unit.Y, 0);
        }
    }
}
