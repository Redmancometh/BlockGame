using UnityEngine;
using System.Collections;

// inherit from this class if you want to use the default events as well as custom ones

namespace StarColony
{
    public class DefaultVoxelEvents : VoxelEvents
    {
        public override void OnMouseDown(int mouseButton, VoxelInfo voxelInfo)
        {
            if (mouseButton == 0)
            {
                Block.DestroyBlock(voxelInfo);
                return;
            }
            if (voxelInfo.GetVoxel() == 8)
            {
                Block.PlaceBlock(voxelInfo, ExampleInventory.HeldBlock);
                return;
            }
            VoxelInfo newInfo = new VoxelInfo(voxelInfo.adjacentIndex, voxelInfo.chunk); // use adjacentIndex to place the block
            Block.PlaceBlock(newInfo, ExampleInventory.HeldBlock);
        }

        public override void OnLook(VoxelInfo voxelInfo)
        {

            // move the selected block ui to the block that's being looked at (convert the index of the hit voxel to absolute world position)
            GameObject blockSelection = GameObject.Find("selected block graphics");
            if (blockSelection == null)
            {
                return;
            }
            blockSelection.transform.position = voxelInfo.chunk.VoxelIndexToPosition(voxelInfo.index);
            blockSelection.GetComponent<Renderer>().enabled = true;
            blockSelection.transform.rotation = voxelInfo.chunk.transform.rotation;
        }

        public override void OnBlockPlace(VoxelInfo voxelInfo)
        {

            // if the block below is grass, change it to dirt
            Index indexBelow = new Index(voxelInfo.index.x, voxelInfo.index.y - 1, voxelInfo.index.z);

            if (voxelInfo.GetVoxelType().VTransparency == Transparency.solid
            && voxelInfo.chunk.GetVoxel(indexBelow) == 2)
            {
                voxelInfo.chunk.SetVoxel(indexBelow, 1, true);
            }
        }

        public override void OnBlockDestroy(VoxelInfo voxelInfo)
        {
            // if the block above is tall grass, destroy it
            Index indexAbove = new Index(voxelInfo.index.x, voxelInfo.index.y + 1, voxelInfo.index.z);
            if (voxelInfo.chunk.GetVoxel(indexAbove) == 8)
            {
                voxelInfo.chunk.SetVoxel(indexAbove, 0, true);
            }
        }

        public override void OnBlockEnter(GameObject enteringObject, VoxelInfo voxelInfo)
        {
            Debug.Log("OnBlockEnter at " + voxelInfo.chunk.ChunkIndex.ToString() + " / " + voxelInfo.index.ToString());
        }

    }

}

