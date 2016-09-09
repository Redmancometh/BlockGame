using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private BlockType type;

    public void setType(BlockType type)
    {
        this.type = type;
    }
}
