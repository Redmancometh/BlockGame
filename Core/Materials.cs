using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Colonist
{
    public class Materials
    {
        public static Dictionary<int, MaterialType> materialMap = new Dictionary<int, MaterialType>();

        public void addMaterialType(MaterialType type)
        {
            materialMap[materialMap.Count + 1] = type;
        }

        public void setMaterialType(int index, MaterialType type)
        {
            materialMap[index] = type;
        }
    }
}
