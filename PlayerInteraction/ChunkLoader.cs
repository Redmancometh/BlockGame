using UnityEngine;
using System.Collections;

// Triggers chunk spawning around the player.

namespace Colonist {

public class ChunkLoader : MonoBehaviour {

	private Index LastPos;
	private Index currentPos;
	
	void Awake () {
		
	}


	public void Update () {
		
		// don't load chunks if engine isn't initialized yet
		if (!MasterEngine.getInstance().Initialized || !ChunkManager.Initialized) {
			return;
		}
		
		// don't load chunks if multiplayer is enabled but the connection isn't established yet
		if (MasterEngine.getInstance().EnableMultiplayer) {
			if (!Network.isClient && !Network.isServer) {
				return;
			}
		}
				
					
							
		// track which chunk we're currently in. If it's different from previous frame, spawn chunks at current position.
		
		currentPos = MasterEngine.getInstance().PositionToChunkIndex (transform.position);

		if (currentPos.IsEqual(LastPos) == false) {
			ChunkManager.SpawnChunks(currentPos.x, currentPos.y, currentPos.z);
			
			// (Multiplayer) update server position
			if (MasterEngine.getInstance().EnableMultiplayer && MasterEngine.getInstance().MultiplayerTrackPosition && MasterEngine.getInstance().UniblocksNetwork != null) {
				UniblocksClient.UpdatePlayerPosition (currentPos);
			}
		}
		
		LastPos = currentPos;	
		
	}

	// multiplayer
	public void OnConnectedToServer () {
		if (MasterEngine.getInstance().EnableMultiplayer && MasterEngine.getInstance().MultiplayerTrackPosition) {
			StartCoroutine (InitialPositionAndRangeUpdate());
		}
	}
	
	IEnumerator InitialPositionAndRangeUpdate () {
		while (MasterEngine.getInstance().UniblocksNetwork == null) {
			yield return new WaitForEndOfFrame ();
		}
		UniblocksClient.UpdatePlayerPosition (currentPos);
		UniblocksClient.UpdatePlayerRange (MasterEngine.getInstance().ChunkSpawnDistance);
	}
}

}