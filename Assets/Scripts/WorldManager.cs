using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public abstract class WorldManager : MonoBehaviour
    {
        public static WorldManager Instance { get; protected set; }

        public virtual Map GameMap { get; protected set; }
    }
}
