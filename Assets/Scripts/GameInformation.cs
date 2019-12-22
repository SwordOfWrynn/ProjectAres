using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameInformation
{
    public string MapPath;
    public string LocalPlayerRace;

    public GameInformation(string mapPath, string localRace)
    {
        MapPath = mapPath;
        LocalPlayerRace = localRace;
    }
}
