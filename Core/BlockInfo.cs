using UnityEngine;
using System.Collections;

namespace Colonist {

public class BlockInfo {

	public Index index;
	public Index adjacentIndex;
	
	public Chunk chunk;
	
	
	public BlockInfo ( int setX, int setY, int setZ, Chunk setChunk ) {
		this.index.x = setX;
		this.index.y = setY;
		this.index.z = setZ;
		
		this.chunk = setChunk;
	}
	
	public BlockInfo ( int setX, int setY, int setZ, int setXa, int setYa, int setZa, Chunk setChunk ) {
		this.index.x = setX;
		this.index.y = setY;
		this.index.z = setZ;
		
		this.adjacentIndex.x = setXa;
		this.adjacentIndex.y = setYa;
		this.adjacentIndex.z = setZa;
		
		this.chunk = setChunk;
	}
	
	public BlockInfo ( Index setIndex, Chunk setChunk ) {
		this.index = setIndex;
		
		this.chunk = setChunk;
	}
	
	public BlockInfo ( Index setIndex, Index setAdjacentIndex, Chunk setChunk ) {
		this.index = setIndex;
		this.adjacentIndex = setAdjacentIndex;
		
		this.chunk = setChunk;
	}
	
		
	public ushort GetVoxel () {
		return chunk.GetVoxel(index);
	}
	
	public Voxel GetVoxelType () {
		return MasterEngine.getInstance().GetVoxelType(chunk.GetVoxel(index));
	}
	
	public ushort GetAdjacentVoxel () {
		return chunk.GetVoxel(adjacentIndex);
	}
	
	public Voxel GetAdjacentVoxelType () {
		return MasterEngine.getInstance().GetVoxelType(chunk.GetVoxel(adjacentIndex));
	}
	
	public void SetVoxel ( ushort data, bool updateMesh ) {
		chunk.SetVoxel (index, data, updateMesh);
	}

}

}