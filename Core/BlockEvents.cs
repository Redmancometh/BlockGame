using UnityEngine;
using System.Collections;

// inherit from this class if you don't want to use the default events

namespace Colonist {

public class VoxelEvents : MonoBehaviour {

	public virtual void OnMouseDown ( int mouseButton, BlockInfo voxelInfo ) {
	    
	}
	
	public virtual void OnMouseUp ( int mouseButton, BlockInfo voxelInfo ) {
		
	}
	
	public virtual void OnMouseHold ( int mouseButton, BlockInfo voxelInfo ) {
		
	}
	
	public virtual void OnLook ( BlockInfo voxelInfo ) {
	
	}
	
	public virtual void OnBlockPlace ( BlockInfo voxelInfo ) {
		
	}
	public virtual void OnBlockPlaceMultiplayer ( BlockInfo voxelInfo, NetworkPlayer sender ) {
	
	}
	
	public virtual void OnBlockDestroy ( BlockInfo voxelInfo ) {
	
	}
	public virtual void OnBlockDestroyMultiplayer ( BlockInfo voxelInfo, NetworkPlayer sender ) {
	
	}
			
	public virtual void OnBlockChange ( BlockInfo voxelInfo ) {
	
	}
	public virtual void OnBlockChangeMultiplayer ( BlockInfo voxelInfo, NetworkPlayer sender ) {
	
	}
	
	public virtual void OnBlockEnter ( GameObject enteringObject, BlockInfo voxelInfo ) {
	
	}
	
	public virtual void OnBlockStay ( GameObject stayingObject, BlockInfo voxelInfo ) {
	
	}
}

}