using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Colonist
{
    public class Location 
    {
        public string worldName;
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public Location(string worldName, int x, int y, int z)
        {
            this.worldName = worldName;
            this.z = x;
            this.y = y;
            this.z = z;
        }

        public bool isChunkLoaded(int x, int y)
        {
            return true;
        }
    }
}
