using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Chunk1
{

    private string worldName { get; set; }

    private Block[,,] blocks = new Block[256, 256, 256];
    private bool loaded = false;
    private CuboidBounds bounds;
    public Chunk1(CuboidBounds bounds)
    {
        this.bounds = bounds;
        for (int x = bounds.lowXBound; x <= bounds.highXBound; x++)
        {
            for (int y = bounds.lowYBound; y < bounds.highYBound; y++)
            {
                for (int z = bounds.lowZBound; z < bounds.highZBound; z++)
                {
                    blocks[x, y, z] = null;
                }
            }
        }
    }

    public bool isLoaded()
    {
        return loaded;
    }

    public void load()
    {

    }

    public void unLoad()
    {

    }

    public Block getBlockAt(int x, int y, int z)
    {
        if (x < bounds.lowXBound || x > bounds.highXBound || x < bounds.lowYBound || x > bounds.highYBound || x < bounds.lowZBound || x > bounds.highZBound)
        {
            throw new NotInChunkException();
        }
        else if (!loaded)
        {
            throw new NotLoadedException();
        }
        return blocks[x, y, z];
    }

    class NotInChunkException : Exception
    {
        
    }

    class NotLoadedException : Exception
    {

    }

}
