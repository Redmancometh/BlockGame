using UnityEngine;
using System.Collections;
using StarColony;

public class VoxelUtil
{
    public static VoxelInfo getVoxelInfo(RaycastHit hit, GameObject hitObject)
    {
        Index voxelIndex = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, false);
        Index voxelIndexAdjacent = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, true);
        Chunk chunk = hitObject.GetComponent<Chunk>();
        return new VoxelInfo(voxelIndex , voxelIndexAdjacent,  chunk);
    }
}
