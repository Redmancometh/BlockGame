using UnityEngine;
using System.Collections;

// stores the currently held block, and switches it with 1-9 keys

namespace Colonist
{
    public class ExampleInventory : MonoBehaviour
    {
        public static ushort HeldBlock;
        public void Update()
        {
            // change held block with 1-9 keys
            for (ushort i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown(i.ToString()))
                {
                    if (MasterEngine.getInstance().GetVoxelType(i) != null)
                    {
                        ExampleInventory.HeldBlock = i;
                        Debug.Log("Held block is now:" + i.ToString());
                    }
                }
            }

        }
    }

}