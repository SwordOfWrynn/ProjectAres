using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public class Unit : PlayerObject
    {
        //Used for creating units
        public Unit(float Xpos, float Ypos, UnitPrototype prototype)
        {

        }
        //Used for loading units
        public Unit(UnitInfo unitInfo)
        {

        }
    }
    /// <summary>
    /// Info for Unit saving and loading
    /// </summary>
    public struct UnitInfo
    {
        float X;
        float Y;
        //rotation
        //some sort of Unit type
        int CurrentHealth;
        int CurrentEnergy;
        //info on unit's task
        //info on buffs/debuffs
    }

}
