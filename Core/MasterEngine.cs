using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

namespace Colonist
{
    public class MasterEngine : MonoBehaviour
    {
        private static MasterEngine instance;
        private ChatManager chatEngine = new ChatManager();
        private VoxelManager voxelEngine { get; set; }
        private EntityManager entityEngine { get; set; }
        // file paths
        public string WorldName, WorldPath, BlocksPath;
        public int WorldSeed;
        public string lWorldName = "TestWorld";
        public string lBlocksPath;

        // voxels
        public GameObject[] Blocks;
        public GameObject[] lBlocks;

        // chunk spawn settings
        public int HeightRange, ChunkSpawnDistance, ChunkSideLength, ChunkDespawnDistance;
        public int lHeightRange, lChunkSpawnDistance, lChunkSideLength, lChunkDespawnDistance;

        // texture settings
        public float TextureUnit, TexturePadding;
        public float lTextureUnit, lTexturePadding;

        // performance settings
        public int TargetFPS, MaxChunkSaves, MaxChunkDataRequests;
        public int lTargetFPS, lMaxChunkSaves, lMaxChunkDataRequests;

        // global settings	

        public bool ShowBorderFaces, GenerateColliders, SendCameraLookEvents,
        SendCursorEvents, EnableMultiplayer, MultiplayerTrackPosition, SaveVoxelData, GenerateMeshes;

        public bool lShowBorderFaces, lGenerateColliders, lSendCameraLookEvents,
        lSendCursorEvents, lEnableMultiplayer, lMultiplayerTrackPosition, lSaveVoxelData, lGenerateMeshes;

        public float ChunkTimeout;
        public float lChunkTimeout;
        public bool EnableChunkTimeout;

        // other
        public int SquaredSideLength;
        public GameObject UniblocksNetwork;
        public MasterEngine EngineInstance;
        public ChunkManager ChunkManagerInstance;

        public Vector3 ChunkScale;

        public bool Initialized;

        /**
         * @return returns the singleton reference for the MasterEngine which is the entry point for the whole thing.
         **/
        public static MasterEngine getInstance()
        {
            return instance;
        }

        public ChatManager getChatEngine()
        {
            return chatEngine;
        }

        public void Start()
        {

        }

        public void initFields()
        {
            instance = this;
            voxelEngine = new VoxelManager();
            entityEngine = new EntityManager();
            Cursor.visible = false;
            EngineInstance = this;
            ChunkManagerInstance = GetComponent<ChunkManager>();

            WorldName = lWorldName;
            UpdateWorldPath();

            BlocksPath = lBlocksPath;
            Blocks = lBlocks;

            TargetFPS = lTargetFPS;
            MaxChunkSaves = lMaxChunkSaves;
            MaxChunkDataRequests = lMaxChunkDataRequests;

            TextureUnit = lTextureUnit;
            TexturePadding = lTexturePadding;
            GenerateColliders = lGenerateColliders;
            ShowBorderFaces = lShowBorderFaces;
            EnableMultiplayer = lEnableMultiplayer;
            MultiplayerTrackPosition = lMultiplayerTrackPosition;
            SaveVoxelData = lSaveVoxelData;
            GenerateMeshes = lGenerateMeshes;

            ChunkSpawnDistance = lChunkSpawnDistance;
            HeightRange = lHeightRange;
            ChunkDespawnDistance = lChunkDespawnDistance;

            SendCameraLookEvents = lSendCameraLookEvents;
            SendCursorEvents = lSendCursorEvents;

            ChunkSideLength = lChunkSideLength;
            SquaredSideLength = lChunkSideLength * lChunkSideLength;


        }

        // ==== initialization ====
        public void Awake()
        {
            initFields();
            ChunkDataFiles.LoadedRegions = new Dictionary<string, string[]>();
            ChunkDataFiles.TempChunkData = new Dictionary<string, string>();

            if (lChunkTimeout <= 0.00001f)
            {
                EnableChunkTimeout = false;
            }
            else
            {
                EnableChunkTimeout = true;
                ChunkTimeout = lChunkTimeout;
            }
            if (Application.isWebPlayer)
            {
                lSaveVoxelData = false;
                SaveVoxelData = false;
            }
            // set layer
            if (LayerMask.LayerToName(26) != "" && LayerMask.LayerToName(26) != "UniblocksNoCollide")
            {
                Debug.LogWarning("StarColony: Layer 26 is reserved for StarColony; it is automatically set to ignore collision with all layers.");
            }
            for (int i = 0; i < 31; i++)
            {
                Physics.IgnoreLayerCollision(i, 26);
            }
            if (dieFromErrors() || dieFromMaterialErrors())
            {
                breakAndLog();
            }
            checkQuality();
            Initialized = true;
        }

        public void checkQuality()
        {
            if (QualitySettings.antiAliasing > 0)
            {
                Debug.LogWarning("StarColony: Anti-aliasing is enabled. This may cause seam lines to appear between blocks. If you see lines between blocks, try disabling anti-aliasing, switching to deferred rendering path, or adding some texture padding in the engine settings.");
            }
        }

        public void breakAndLog()
        {
            Debug.Break();
            Debug.LogError("Fatal warning from engine!");

        }

        public bool dieFromMaterialErrors()
        {
            GameObject chunkPrefab = GetComponent<ChunkManager>().ChunkObject;
            int materialCount = chunkPrefab.GetComponent<Renderer>().sharedMaterials.Length - 1;
            for (ushort i = 0; i < Blocks.Length; i++)
            {

                if (Blocks[i] != null)
                {
                    Voxel voxel = Blocks[i].GetComponent<Voxel>();

                    if (voxel.VSubmeshIndex < 0)
                    {
                        Debug.LogError("StarColony: Voxel " + i + " has a material index lower than 0! Material index must be 0 or greater.");
                        Debug.Break();
                    }

                    if (voxel.VSubmeshIndex > materialCount)
                    {
                        Debug.LogError("StarColony: Voxel " + i + " uses material index " + voxel.VSubmeshIndex + ", but the chunk prefab only has " + (materialCount + 1) + " material(s) attached. Set a lower material index or attach more materials to the chunk prefab.");
                        Debug.Break();
                    }
                }
            }
            return false;
        }

        public bool dieFromErrors()
        {
            // check block array
            if (Blocks.Length < 1)
            {
                Debug.LogError("StarColony: The blocks array is empty! Use the Block Editor to update the blocks array.");
                Debug.Break();
            }
            // check settings
            if (ChunkSideLength < 1)
            {
                Debug.LogError("StarColony: Chunk side length must be greater than 0!");
                Debug.Break();
            }

            if (ChunkSpawnDistance < 1)
            {
                ChunkSpawnDistance = 0;
                Debug.LogWarning("StarColony: Chunk spawn distance is 0. No chunks will spawn!");
            }

            if (HeightRange < 0)
            {
                HeightRange = 0;
                Debug.LogWarning("StarColony: Chunk height range can't be a negative number! Setting chunk height range to 0.");
            }

            if (MaxChunkDataRequests < 0)
            {
                MaxChunkDataRequests = 0;
                Debug.LogWarning("StarColony: Max chunk data requests can't be a negative number! Setting max chunk data requests to 0.");
            }

            if (Blocks[0] == null)
            {
                Debug.LogError("StarColony: Cannot find the empty block prefab (id 0)!");
                Debug.Break();
                return false;
            }
            else if (Blocks[0].GetComponent<Voxel>() == null)
            {
                Debug.LogError("StarColony: Voxel id 0 does not have the Voxel component attached!");
                Debug.Break();
            }
            return false;
        }

        private void UpdateWorldPath()
        {
            WorldPath = Application.dataPath + "/world";                                                                      //WorldPath = "/mnt/sdcard/UniblocksWorlds/" + Engine.WorldName + "/"; // example mobile path for Android
        }

        public void SetWorldName(string worldName)
        {
            WorldName = worldName;
            WorldSeed = 0;
            UpdateWorldPath();
        }

        public void GetSeed()
        { // reads the world seed from file if it exists, else creates a new seed and saves it to file
            if (Application.isWebPlayer)
            { // don't save to file if webplayer			
                WorldSeed = Random.Range(ushort.MinValue, ushort.MaxValue);
                return;
            }

            if (File.Exists(WorldPath + "seed"))
            {
                StreamReader reader = new StreamReader(WorldPath + "seed");
                WorldSeed = int.Parse(reader.ReadToEnd());
                reader.Close();
            }
            else
            {
                while (WorldSeed == 0)
                {
                    WorldSeed = Random.Range(ushort.MinValue, ushort.MaxValue);
                }
                System.IO.Directory.CreateDirectory(WorldPath);
                StreamWriter writer = new StreamWriter(WorldPath + "seed");
                writer.Write(WorldSeed.ToString());
                writer.Flush();
                writer.Close();
            }
        }

        public void SaveWorld()
        { // saves the data over multiple frames
            EngineInstance.StartCoroutine(ChunkDataFiles.SaveAllChunks());
        }

        public void SaveWorldInstant()
        {
            ChunkDataFiles.SaveAllChunksInstant();
        }

        // ==== other ====	


        public GameObject GetVoxelGameObject(ushort voxelId)
        {
            try
            {
                if (voxelId == ushort.MaxValue) voxelId = 0;
                GameObject voxelObject = Blocks[voxelId];
                if (voxelObject.GetComponent<Voxel>() == null)
                {
                    Debug.LogError("StarColony: Voxel id " + voxelId + " does not have the Voxel component attached!");
                    return Blocks[0];
                }
                else
                {
                    return voxelObject;
                }

            }
            catch (System.Exception)
            {
                Debug.LogError("StarColony: Invalid voxel id: " + voxelId);
                return Blocks[0];
            }
        }

        public Voxel GetVoxelType(ushort voxelId)
        {
            try
            {
                if (voxelId == ushort.MaxValue) voxelId = 0;
                Voxel voxel = Blocks[(int)voxelId].GetComponent<Voxel>();
                if (voxel == null)
                {
                    Debug.LogError("StarColony: Voxel id " + voxelId + " does not have the Voxel component attached!");
                    return null;
                }
                else
                {
                    return voxel;
                }

            }
            catch (System.Exception)
            {
                Debug.LogError("StarColony: Invalid voxel id: " + voxelId);
                return null;
            }
        }



        // a raycast which returns the index of the hit voxel and the gameobject of the hit chunk
        public void MasterRaycast(Vector3 origin, Vector3 direction, float range, bool ignoreTransparent)
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(origin, direction, out hit, range))
            {
                //Engine Prescedence set here
                if (voxelEngine.raycastHasVoxel(hit))
                {
                    voxelEngine.MasterRaycast(hit, origin, direction, range, ignoreTransparent);
                }
                if (entityEngine.rayCastHitEntity(hit))
                {

                }
            }
        }

        public VoxelManager getVoxelEngine()
        {
            return voxelEngine;
        }

        public EntityManager getEntityEngine()
        {
            return entityEngine;
        }

        public Index PositionToChunkIndex(Vector3 position)
        {
            Index chunkIndex = new Index(Mathf.RoundToInt(position.x / ChunkScale.x) / ChunkSideLength,
                                          Mathf.RoundToInt(position.y / ChunkScale.y) / ChunkSideLength,
                                          Mathf.RoundToInt(position.z / ChunkScale.z) / ChunkSideLength);
            return chunkIndex;
        }

        public GameObject PositionToChunk(Vector3 position)
        {
            Index chunkIndex = new Index(Mathf.RoundToInt(position.x / ChunkScale.x) / ChunkSideLength,
                                          Mathf.RoundToInt(position.y / ChunkScale.y) / ChunkSideLength,
                                          Mathf.RoundToInt(position.z / ChunkScale.z) / ChunkSideLength);
            return ChunkManager.GetChunk(chunkIndex);

        }

        public BlockInfo PositionToVoxelInfo(Vector3 position)
        {
            GameObject chunkObject = PositionToChunk(position);
            if (chunkObject != null)
            {
                Chunk chunk = chunkObject.GetComponent<Chunk>();
                Index voxelIndex = chunk.PositionToVoxelIndex(position);
                return new BlockInfo(voxelIndex, chunk);
            }
            else
            {
                return null;
            }
        }

        public Vector3 VoxelInfoToPosition(BlockInfo voxelInfo)
        {
            return voxelInfo.chunk.GetComponent<Chunk>().VoxelIndexToPosition(voxelInfo.index);
        }




        // ==== mesh creator ====

        public Vector2 GetTextureOffset(ushort voxel, Facing facing)
        {
            Voxel voxelType = GetVoxelType(voxel);
            Vector2[] textureArray = voxelType.VTexture;
            if (textureArray.Length == 0)
            { // in case there are no textures defined, return a default texture
                Debug.LogWarning("StarColony: Block " + voxel.ToString() + " has no defined textures! Using default texture.");
                return new Vector2(0, 0);
            }
            else if (voxelType.VCustomSides == false)
            { // if this voxel isn't using custom side textures, return the Up texture.
                return textureArray[0];
            }
            else if ((int)facing > textureArray.Length - 1)
            { // if we're asking for a texture that's not defined, grab the last defined texture instead
                return textureArray[textureArray.Length - 1];
            }
            return textureArray[(int)facing];
        }
    }

}