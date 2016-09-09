using Colonist;
using UnityEngine;
public class VoxelManager
{

    public bool raycastHasVoxel(RaycastHit hit)
    {
        if (hit.collider.GetComponent<Chunk>() != null || hit.collider.GetComponent<ChunkExtension>() != null)
        {
            return true;
        }
        return false;
    }
    // a raycast which returns the index of the hit voxel and the gameobject of the hit chunk
    public BlockInfo MasterRaycast(RaycastHit hit, Vector3 origin, Vector3 direction, float range, bool ignoreTransparent)
    {
        if (raycastHasVoxel(hit))
        { // check if we're actually hitting a chunk
            GameObject hitObject = hit.collider.gameObject;
            swapMesh(hitObject);
            Index hitIndex = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, false);
            if (ignoreTransparent)
            { // punch through transparent voxels by raycasting again when a transparent voxel is hit
                reCast(hitIndex, hitObject, hit, range);
            }
            return VoxelUtil.getVoxelInfo(hit, hitObject);
        }
        return null;
    }

    public void swapMesh(GameObject hitObject)
    {
        if (hitObject.GetComponent<ChunkExtension>() != null)
        {
            // if we hit a mesh container instead of a chunk
            // swap the mesh container for the actual chunk object
            hitObject = hitObject.transform.parent.gameObject;
        }
    }

    public BlockInfo getVoxelInfo(RaycastHit hit, float range, bool ignoreTransparent)
    {
        if (raycastHasVoxel(hit))
        {
            // check if we're actually hitting a chunk
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.GetComponent<ChunkExtension>() != null)
            { // if we hit a mesh container instead of a chunk
                hitObject = hitObject.transform.parent.gameObject; // swap the mesh container for the actual chunk object
            }
            Index hitIndex = hitObject.GetComponent<Chunk>().PositionToVoxelIndex(hit.point, hit.normal, false);
            if (ignoreTransparent)
            {
                reCast(hitIndex, hitObject, hit, range);
            }
            return VoxelUtil.getVoxelInfo(hit, hitObject);
        }
        return null;
    }

    public void reCast(Index hitIndex, GameObject hitObject, RaycastHit hit, float range)
    {
        // punch through transparent voxels by raycasting again when a transparent voxel is hit
        ushort hitVoxel = hitObject.GetComponent<Chunk>().GetVoxel(hitIndex.x, hitIndex.y, hitIndex.z);
        if (MasterEngine.getInstance().GetVoxelType(hitVoxel).VTransparency != Transparency.solid)
        { // if the hit voxel is transparent
            Vector3 newOrigin = hit.point;
            newOrigin.y -= 0.5f; // push the new raycast down a bit
            MasterEngine.getInstance().MasterRaycast(newOrigin, Vector3.down, range - hit.distance, true);
        }

    }


}
