using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemMap : Dictionary<int, InventoryItem>
{
    public InventoryItem getItemAt(int index)
    {
        if(this.Count >= index)
        {
            throw new SlotDoesntExistException();
        }
        else if(this[index]==null)
        {
            return null;
        }
        return this[index];
    }
}
