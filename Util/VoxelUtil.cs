using UnityEngine;
using System.Collections;
using Colonist;

public class VoxelUtil
{
    public static BlockInfo getVoxelInfo(RaycastHit hit, GameObject hitObject)
    {
        Index voxelIndex = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, false);
        Index voxelIndexAdjacent = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, true);
        Chunk chunk = hitObject.GetComponent<Chunk>();
        return new BlockInfo(voxelIndex , voxelIndexAdjacent,  chunk);
    }
}
