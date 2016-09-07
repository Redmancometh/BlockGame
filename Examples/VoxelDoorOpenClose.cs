using UnityEngine;
using System.Collections;
namespace StarColony {
	

public class VoxelDoorOpenClose : DefaultVoxelEvents {

	public override void OnMouseDown (int mouseButton, VoxelInfo voxelInfo) {
	
		if (mouseButton == 0) {
			Block.DestroyBlock (voxelInfo);	// destroy with left click
		}
		
		else if (mouseButton == 1) { // open/close with right click
		
			if (voxelInfo.GetVoxel() == 70) { // if open door
				Block.ChangeBlock (voxelInfo, 7); // set to closed
			}
			
			else if (voxelInfo.GetVoxel() == 7) { // if closed door
				Block.ChangeBlock (voxelInfo, 70); // set to open
			}	

		}
	}

}

}