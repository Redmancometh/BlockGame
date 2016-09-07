using UnityEngine;
using System.Collections;

namespace StarColony {

public class TerrainGenerator : MonoBehaviour {
	
	protected Chunk chunk;
	protected int seed;
	
	public void InitializeGenerator () {
		
		// load seed if it's not loaded yet
		while (MasterEngine.getInstance().WorldSeed == 0) {
			MasterEngine.getInstance().GetSeed();
		}
		seed = MasterEngine.getInstance().WorldSeed;
		
		// get chunk component
		chunk = GetComponent<Chunk>();
		
		// generate data
		GenerateVoxelData ();
		
		// set empty
		chunk.Empty = true;
		foreach (ushort voxel in chunk.VoxelData) {
			if (voxel != 0) {
				chunk.Empty = false;
				break;
			}
		}
		
		// flag as done
		chunk.VoxelsDone = true;
	}
	
	public virtual void GenerateVoxelData () {
		
	}
}

}