using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public class Tile : WorldObject
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        //Not sure if these should be here or TileSpriteController? or elsewhere?

        public static (float, float) CartToIso(float x, float y)
        {
            float isoX = (x - y)/2;
            float isoY = (x + y)/4;

            return (isoX, isoY);
        }

        public static (int, int) IsoToCart(float x, float y)
        {
            int cartX = (int)(2.0f * (y*4 + x*2) * 0.5f);
            int cartY = (int)(2.0f * (y*4 - x*2) * 0.5f);

            return (cartX, cartY);
        }

    }
}
