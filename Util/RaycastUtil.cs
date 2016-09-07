using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastUtil
{
    // a raycast which returns the index of the hit voxel and the gameobject of the hit chunk
    public static RaycastHit createRayCast(Vector3 origin, Vector3 direction, float range)
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(origin, direction, out hit, range))
        {
            return hit;
        }
        return hit;
    }

    public static bool hasHit(Ray ray, float range)
    {
        if(Physics.Raycast(ray, range))
        {
            return true;
        }
        return false;
    }

    public static KeyValuePair<bool, RaycastHit> AABB(Ray ray, float range)
    {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 2))
        {
            return new System.Collections.Generic.KeyValuePair<bool, RaycastHit>(true, hit);
        }
        return new KeyValuePair<bool, RaycastHit>(false, hit);
    }
}
