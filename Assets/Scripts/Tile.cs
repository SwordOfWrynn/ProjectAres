using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ares
{
    public enum TileType
    {
        Ground,
        //Ramps and cliffs go clockwise 0 at 12:00 (e.g. Ramp0 faces away from cam, ramp6 towards)
        Ramp1,
        Ramp3,
        Ramp5,
        Ramp7,

        Cliff1,
        Cliff3,
        Cliff5,
        Cliff7,
    }

    public struct TileInfo
    {
        public int X;
        public int Y;
        public int TileType;

        public TileInfo(int x, int y, int tileType)
        {
            X = x;
            Y = y;
            TileType = tileType;
        }
    }

    public class Tile : WorldObject
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public TileType Type { get; protected set; }

        public Tile(int x, int y, TileType tileType)
        {
            X = x;
            Y = y;
            Type = tileType;
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
