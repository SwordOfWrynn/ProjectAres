using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    //All objects in the world, units, buildings, resources, doodads, etc.
    public abstract class WorldObject
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }

    }
}
