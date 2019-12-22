using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MatchInfo
{
    public string MapPath;
    public string LocalPlayerRace;

    public MatchInfo(string mapPath, string localRace)
    {
        MapPath = mapPath;
        LocalPlayerRace = localRace;
    }
}
