using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Colonist
{
    public class World
    {
        private Dictionary<KeyValuePair<int, int>, Chunk1> chunkMap = new Dictionary<KeyValuePair<int, int>, Chunk1>();
        private string worldName { get; set; }

        public Chunk1 getChunkAt(int x, int z)
        {
            return chunkMap[new KeyValuePair<int, int>(x, z)];
        }

        public Chunk1 getChunkAt(Location loc)
        {
            return getChunkAt(loc.x >> 4, loc.z >> 4);
        }


        public Block getBlockAt(int x, int y, int z)
        {
            return getChunkAt(x >> 4, z >> 4).getBlockAt(x, y, z);
        }
    }
}

