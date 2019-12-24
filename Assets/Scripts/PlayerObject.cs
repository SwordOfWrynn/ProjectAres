using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    //Units and buildings
    public abstract class PlayerObject : WorldObject
    {

        public Player Owner { get; protected set; }

    }
}
