using UnityEngine;
using System.Collections;

namespace Colonist {

public class FlatTerrainGenerator : TerrainGenerator { // generates a flat terrain

	public override void GenerateVoxelData () {
	
		int chunky = chunk.ChunkIndex.y;
		int SideLength = MasterEngine.getInstance().ChunkSideLength;
		
		for (int x=0; x<SideLength; x++) {
			for (int y=0; y<SideLength; y++) {
				for (int z=0; z<SideLength; z++) { // for all voxels in the chunk
					
					int currentHeight = y+(SideLength*chunky); // get absolute height for the voxel
				
					if (currentHeight < 8) {
						chunk.SetVoxelSimple(x,y,z, 1); // set dirt
					}
					

				}
			}
		}
	}
}

}